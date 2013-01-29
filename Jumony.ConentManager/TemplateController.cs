using Ivony.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Jumony.ConentManager
{
  public class TemplateController : Controller
  {

    private SqlDbUtility dbUtility = SqlDbUtility.Create( "DataBase" );

    private const string templatePath = "~/Templates";

    public ActionResult List()
    {

      return View( "List", dbUtility.Data( "SELECT virtualPath FROM Templates" ).Column<string>() );

    }

    public ActionResult Refresh()
    {
      var directory = HostingEnvironment.VirtualPathProvider.GetDirectory( VirtualPathUtility.ToAbsolute( templatePath ) );

      var data = new HashSet<string>( dbUtility.Data( "SELECT virtualPath FROM Templates " ).Column<string>(), StringComparer.OrdinalIgnoreCase );

      var local = new HashSet<string>( SearchFiles( directory ).Select( f => VirtualPathUtility.ToAppRelative( f.VirtualPath ) ) );

      foreach ( var virtualPath in local.Except( data ) )
        dbUtility.NonQuery( "INSERT INTO Templates ( virtualPath ) VALUES ( {0} )", virtualPath );

      foreach ( var virtualPath in data.Except( local ) )
        dbUtility.NonQuery( "DELETE Templates WHERE virtualPath = {0}", virtualPath );

      return RedirectToAction( "List" );
    }

    private static IEnumerable<VirtualFile> SearchFiles( VirtualDirectory directory )
    {
      foreach ( VirtualFile file in directory.Files )
        yield return file;

      foreach ( VirtualDirectory d in directory.Directories )
      {
        foreach ( VirtualFile f in SearchFiles( d ) )
          yield return f;
      }
    }

  }
}

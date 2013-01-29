using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Jumony.ConentManager
{
  public class GenericController : Controller
  {

    public void DataListView( string dataSource, string template )
    {

      var data = DataSource.GetData( dataSource );
      return View( template, data );

    }


  }
}

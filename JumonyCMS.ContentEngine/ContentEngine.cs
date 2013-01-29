using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumonyCMS.ContentEngine
{
  public class ContentEngine
  {

    public void RenderContent( DataContext data, string virtualPath )
    {
      var template = LoadTemplate( virtualPath );
      template.Render( data );
    }

    private ContentTemplate LoadTemplate( string virtualPath )
    {
      throw new NotImplementedException();
    }

  }
}

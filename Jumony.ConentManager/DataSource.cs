using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumony.ConentManager
{
  public static class DataSource
  {
    public static IEnumerable GetData( string dataSourceId )
    {

      var dataSource = GetDataSource( dataSourceId );
      return dataSource.GetData();

    }

    public static IDataSource GetDataSource( string dataSourceId )
    {
      throw new NotImplementedException();
    }

    private Dictionary<string, IDataSource> _dataSources;

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricebook.Database {
  public class INVGROUP {
    public string GROUP { get; set; }
    public string DESCRIP { get; set; }
    
    private static string SQL() {
      return @"
SELECT 
[GROUP],
[CATG],
[DESCRIP]
FROM [AJP].[dbo].[INVGROUP]
";
    }
  }
}

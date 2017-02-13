using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricebook.Database {
  public class APVENDOR {
    public string VENDORID { get; set; }
    public string COMPANYNM { get; set; }

    public static string SQL() {
      return @"
SELECT
[VENDORID],
[COMPANYNM]
FROM [AJP].[dbo].[APVENDOR]
";
    }
  }
}

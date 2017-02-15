using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricebook.Database {
  public class ARCUST {
    public string CUSTNO { get; set; }
    public string COMPANYNM { get; set; }
    public string ADDRESS1 { get; set; }
    public string CITY { get; set; }
    public string STATE { get; set; }
    public string ZIP { get; set; }
    public string PERSON { get; set; }
    public string PHONE { get; set; }
    public string FAX { get; set; }
    public string EMAIL { get; set; }

    private string SQL() {
      return @"
Select 
CUSTNO,
COMPANYNM,
ADDRESS1,
CITY,
STATE,
Zip,
PERSON,
PHONE,
FAX,
EMAIL
From ARCUST
WHERE 
ARCUST.INACTIVETF = 0
AND
ISNUMERIC(CUSTNO) = 1
";
    }

  }
}

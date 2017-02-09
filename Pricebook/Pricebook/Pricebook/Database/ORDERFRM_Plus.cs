using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricebook.Database {
  public class ORDERFRM_Plus {
    public string ITEMNO { get; set; }
    public string SHIPCUSTNO { get; set; }
    public string LastSellNetnet { get; set; }
    public string EntryDate { get; set; }
    public string CATG { get; set; }
    public string GROUP { get; set; }
    public string DESCRIP { get; set; }
    public string DESCRIP2 { get; set; }
    public string DESCRIP3 { get; set; }


    private string SQL() {
      return @"
SELECT
ORDERFRM.ITEMNO, 
ORDERFRM.SHIPCUSTNO, 
ORDERFRM.LastSellNetnet, 
ORDERFRM.EntryDate, 
INVMAS.CATG, 
INVMAS.[GROUP], 
INVMAS.DESCRIP, 
INVMAS.DESCRIP2, 
INVMAS.DESCRIP3
FROM
ORDERFRM INNER JOIN
	INVMAS ON ORDERFRM.ITEMNO = INVMAS.ITEMNO

WHERE ISNUMERIC(ORDERFRM.ITEMNO) = 1
";
    }


  }
}

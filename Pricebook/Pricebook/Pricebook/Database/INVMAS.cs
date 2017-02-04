using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricebook.Database {
  class INVMAS {

    public string ITEMNO { get; set; }
    public string CATG { get; set; }
    public string GROUP { get; set; }
    public string SUPERGROUP { get; set; }
    public string DESCRIP { get; set; }
    public string DESCRIP2 { get; set; }
    public string DESCRIP3 { get; set; }



    public double W_AVG_COST { get; set; }
    public double LINECOST { get; set; }
    public double DEADNET { get; set; }
    public double LOADEDCOST { get; set; }
    public short ONORDER { get; set; }
    public int ORDERQTY { get; set; }
    public string VENDORID { get; set; }
    public string VENDORITEM { get; set; }
    public int DELIV_DAYS { get; set; }
    public int DAYS_OH { get; set; }
    public int FLAG_PDAYS { get; set; }



    ////public DateTime LASTDATE { get; set; }

    public string LASTDATE { get; set; }



    public string WHSE_LOC { get; set; }
    public string WHSE_BIN { get; set; }
    public string RTDESC1 { get; set; }
    public string RTDESC2 { get; set; }


    public int SELLROUND { get; set; }

    public string SELLUOM { get; set; }
    public string BUY_UOM { get; set; }
    public string ITEMSTATUS { get; set; }


    public int PRBK_SEQ { get; set; }


    public string SELL_CALC1 { get; set; }
    public string SELL_CALC2 { get; set; }
    public string SELL_CALC3 { get; set; }
    public string SELL_CALC4 { get; set; }
    public string SELL_CALC5 { get; set; }
    public string SELL_CALC6 { get; set; }
    public string SELL_CALC7 { get; set; }
    public string SELL_CALC8 { get; set; }
    public string SELL_CALC9 { get; set; }


    public static string SQLQuery() {
      return @"
SELECT 
SELECT 
[ITEMNO]
,[CATG]
,[GROUP]
,[SUPERGROUP]
,[DESCRIP]
,[DESCRIP2]
,[DESCRIP3]
,[W_AVG_COST]
,[LINECOST]
,[DEADNET]
,[LOADEDCOST]
,[ONORDER]
,[ORDERQTY]
,[VENDORID]
,[VENDORITEM]
,[DELIV_DAYS]
,[DAYS_OH]
,[FLAG_PDAYS]
,[LASTDATE]
,[BACKORDTF]
,[WHSE_LOC]
,[WHSE_BIN]
,[RTDESC1]
,[RTDESC2]
,[SELLROUND]
,[SELLUOM]
,[BUY_UOM]
,[ITEMSTATUS]
,[PRBK_SEQ]
,[SELL_CALC1]
,[SELL_CALC2]
,[SELL_CALC3]
,[SELL_CALC4]
,[SELL_CALC5]
,[SELL_CALC6]
,[SELL_CALC7]
,[SELL_CALC8]
,[SELL_CALC9]
FROM [AJP].[dbo].[INVMAS]
WHERE DO_NOT_USE = 0
";
    }


    public INVMAS() { }

  }
}

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
    public string BUYUOMCOST { get; set; }
    public string BUYUOMCOST2 { get; set; }
    public string W_AVG_COST { get; set; }
    public string LINECOST { get; set; }
    public string UNITFRGHT { get; set; }
    public string DEADNET { get; set; }
    public string COSTBASIS { get; set; }
    public string LOADEDCOST { get; set; }
    public string LOADGROUP { get; set; }
    public string ONORDER { get; set; }
    public string ORDERQTY { get; set; }
    public string VENDORID { get; set; }
    public string VENDORITEM { get; set; }
    public string DELIV_DAYS { get; set; }
    public string DAYS_OH { get; set; }
    public string FLAG_PDAYS { get; set; }
    public string LASTDATE { get; set; }
    public string BACKORDTF { get; set; }
    public string WHSE_LOC { get; set; }
    public string WHSE_BIN { get; set; }
    public string RTDESC1 { get; set; }
    public string RTDESC2 { get; set; }
    public string RTDESC3 { get; set; }
    public string RETAILUOM { get; set; }
    public string RETAILVALU { get; set; }
    public string SELLROUND { get; set; }
    public string SELLUOM { get; set; }
    public string BUY_UOM { get; set; }
    public string ITEMSTATUS { get; set; }
    public string PRBK_SEQ { get; set; }
    public string DO_NOT_USE { get; set; }
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
[ITEMNO]
,[CATG]
,[GROUP]
,[SUPERGROUP]
,[DESCRIP]
,[DESCRIP2]
,[DESCRIP3]
,[BUYUOMCOST]
,[BUYUOMCOST2]
,[W_AVG_COST]
,[LINECOST]
,[UNITFRGHT]
,[DEADNET]
,[COSTBASIS]
,[LOADEDCOST]
,[LOADGROUP]
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
,[RTDESC3]
,[RETAILUOM]
,[RETAILVALU]
,[SELLROUND]
,[SELLUOM]
,[BUY_UOM]
,[ITEMSTATUS]
,[PRBK_SEQ]
,[DO_NOT_USE]
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
";
    }


    public INVMAS() { }

  }
}

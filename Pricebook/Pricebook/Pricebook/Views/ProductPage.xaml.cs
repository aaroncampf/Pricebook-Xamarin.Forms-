using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class ProductPage : ContentPage {
    public Database.INVMAS SelectedProduct { get; private set; }

    public ProductPage(Database.INVMAS SelectedProduct) {
      InitializeComponent();
      this.BindingContext = this;
      this.SelectedProduct = SelectedProduct;

      var htmlSource = new HtmlWebViewSource();
      htmlSource.Html = $@"
                          <h1>{SelectedProduct.DESCRIP}</h1>
                          <p>ITEMNO: {SelectedProduct.ITEMNO}</p>
                          <p>CATG: {SelectedProduct.CATG}</p>
                          <p>GROUP: {SelectedProduct.GROUP}</p>
                          <p>SUPERGROUP: {SelectedProduct.SUPERGROUP}</p>
                          <p>DESCRIP: {SelectedProduct.DESCRIP}</p>
                          <p>DESCRIP2: {SelectedProduct.DESCRIP2}</p>
                          <p>DESCRIP3: {SelectedProduct.DESCRIP3}</p>
                          <p>LINECOST: {SelectedProduct.LINECOST}</p>
                          <p>DEADNET: {SelectedProduct.DEADNET}</p>
                          <p>LOADEDCOST: {SelectedProduct.LOADEDCOST}</p>
                          <p>VENDORID: {SelectedProduct.VENDORID}</p>
                          <p>DELIV_DAYS: {SelectedProduct.DELIV_DAYS}</p>
                          <p>DAYS_OH: {SelectedProduct.DAYS_OH}</p>
                          <p>LASTDATE: {SelectedProduct.LASTDATE:D}</p>
                          <p>Location: {SelectedProduct.WHSE_LOC} - {SelectedProduct.WHSE_BIN}</p>
                          <p>SELLUOM: {SelectedProduct.SELLUOM}</p>
                          <p>BUY_UOM: {SelectedProduct.BUY_UOM}</p>
                          <p>PRBK_SEQ: {SelectedProduct.PRBK_SEQ}</p>
                          <p>SELL_CALC1: {SelectedProduct.SELL_CALC1}</p>
                          <p>ITEMNO: {SelectedProduct.SELL_CALC1}</p>
                          <p>SELL_CALC2: {SelectedProduct.SELL_CALC2}</p>
                          <p>SELL_CALC3: {SelectedProduct.SELL_CALC3}</p>
                          <p>SELL_CALC4: {SelectedProduct.SELL_CALC4}</p>
                          <p>SELL_CALC5: {SelectedProduct.SELL_CALC5}</p>
                          <p>SELL_CALC6: {SelectedProduct.SELL_CALC6}</p>
                          <p>SELL_CALC7: {SelectedProduct.SELL_CALC7}</p>
                          <p>SELL_CALC8: {SelectedProduct.SELL_CALC8}</p>
                          <p>SELL_CALC9: {SelectedProduct.SELL_CALC9}</p>

                          <p>...</p>
                          <h2>Special Prices</h2>
";


      webMain.Source = htmlSource;
    }



  }
}

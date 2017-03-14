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
                          <p>DESCRIP: {SelectedProduct.DESCRIP}</p>";

      if (!string.IsNullOrEmpty(SelectedProduct.DESCRIP2))
        htmlSource.Html += $"<p>DESCRIP2: {SelectedProduct.DESCRIP2}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.DESCRIP3))
        htmlSource.Html += $"<p>DESCRIP3: {SelectedProduct.DESCRIP3}</p>";

      htmlSource.Html += $@"
                          <p>LINECOST: {SelectedProduct.LINECOST}</p>
                          <p>DEADNET: {SelectedProduct.DEADNET}</p>
                          <p>LOADEDCOST: {SelectedProduct.LOADEDCOST}</p>
                          <p>VENDORID: {SelectedProduct.VENDORID}</p>
                          <p>Location: {SelectedProduct.WHSE_LOC} - {SelectedProduct.WHSE_BIN}</p>
                          <p>SELLUOM: {SelectedProduct.SELLUOM}</p>";


      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC1))
        htmlSource.Html += $"<p>SELL_CALC1: {SelectedProduct.SELL_CALC1}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC2))
        htmlSource.Html += $"<p>SELL_CALC2: {SelectedProduct.SELL_CALC2}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC3))
        htmlSource.Html += $"<p>SELL_CALC3: {SelectedProduct.SELL_CALC3}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC4))
        htmlSource.Html += $"<p>SELL_CALC4: {SelectedProduct.SELL_CALC4}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC5))
        htmlSource.Html += $"<p>SELL_CALC5: {SelectedProduct.SELL_CALC5}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC6))
        htmlSource.Html += $"<p>SELL_CALC6: {SelectedProduct.SELL_CALC6}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC7))
        htmlSource.Html += $"<p>SELL_CALC7: {SelectedProduct.SELL_CALC7}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC8))
        htmlSource.Html += $"<p>SELL_CALC8: {SelectedProduct.SELL_CALC8}</p>";
      if (!string.IsNullOrEmpty(SelectedProduct.SELL_CALC9))
        htmlSource.Html += $"<p>SELL_CALC9: {SelectedProduct.SELL_CALC9}</p>";      

      htmlSource.Html += "<h2>Special Prices</h2>";
      webMain.Source = htmlSource;
    }
  }
}

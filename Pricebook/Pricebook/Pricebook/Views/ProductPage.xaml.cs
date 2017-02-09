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
                          <p>...</p>
                          <h2>Special Prices</h2>
";


      webMain.Source = htmlSource;
    }



  }
}

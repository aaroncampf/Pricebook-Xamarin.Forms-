using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class ProductPage : ContentPage {
    public Database.INVMAS SelectedProduct { get; set; }

    public ProductPage() {
      InitializeComponent();
      this.BindingContext = this;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace Pricebook.Views {
  public partial class TabsPage : TabbedPage {
    public TabsPage() {
      InitializeComponent();
    }


    public static Func<System.Xml.Linq.XElement> GetXML { get; set; }
    public static Action UpdateXML { get; set; }



    private void tbiUpdateManually_Clicked(object sender, EventArgs e) {
      string path = "/storage/emulated/0/Aaron";
      //Storage/Pricebook_XamarinForms_Debug.xml



      UpdateXML();




      //var T1 = FileSystem.Current;

      //var File = T1.GetFileFromPathAsync("Pricebook_XamarinForms_Debug.xml").Result;


      //var DFile = Database.Passwords.DBox.Files.DownloadAsync("/Storage/Pricebook_XamarinForms_Debug.xml").Result;
      //var Data = DFile.GetContentAsStringAsync().Result;

      //var F1 = T1.LocalStorage.CreateFileAsync("Pricebook_XamarinForms_Debug.xml", PCLStorage.CreationCollisionOption.ReplaceExisting).Result;

      //T1.LocalStorage.CreateFileAsync("Pricebook_XamarinForms_Debug.xml", PCLStorage.CreationCollisionOption.ReplaceExisting).Wait();






      this.DisplayAlert("Warning", "This feature is not ready yet and thus does nothing", "Ok");
    }
  }
}

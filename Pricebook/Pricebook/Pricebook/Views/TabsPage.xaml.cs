using PCLStorage;
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



    //public async Task CreateRealFileAsync() {
    //  // get hold of the file system
    //  IFolder rootFolder = FileSystem.Current.LocalStorage;

    //  // create a folder, if one does not exist already

    //  var T1 = rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists).Result;

    //  IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists).ConfigureAwait(false);



    //  // create a file, overwriting any existing file
    //  IFile file = await folder.CreateFileAsync("MyFile.txt", CreationCollisionOption.ReplaceExisting);

    //  // populate the file with some text
    //  await file.WriteAllTextAsync("Sample Text...");
    //}

    public async Task CreateRealFileAsync() {
      // get hold of the file system
      IFolder rootFolder = FileSystem.Current.LocalStorage;

      // create a folder, if one does not exist already
      IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists);

      // create a file, overwriting any existing file
      IFile file = await folder.CreateFileAsync("MyFile.txt", CreationCollisionOption.ReplaceExisting);

      // populate the file with some text
      await file.WriteAllTextAsync("Sample Text...");
    }







    private void tbiUpdateManually_Clicked(object sender, EventArgs e) {
      string path = "/storage/emulated/0/Aaron";
      //Storage/Pricebook_XamarinForms_Debug.xml


      CreateRealFileAsync().Wait();



      var T1 = FileSystem.Current;

      var File = T1.GetFileFromPathAsync("Pricebook_XamarinForms_Debug.xml").Result;


      var DFile = Database.Passwords.DBox.Files.DownloadAsync("/Storage/Pricebook_XamarinForms_Debug.xml").Result;
      var Data = DFile.GetContentAsStringAsync().Result;

      var F1 = T1.LocalStorage.CreateFileAsync("Pricebook_XamarinForms_Debug.xml", PCLStorage.CreationCollisionOption.ReplaceExisting).Result;

      T1.LocalStorage.CreateFileAsync("Pricebook_XamarinForms_Debug.xml", PCLStorage.CreationCollisionOption.ReplaceExisting).Wait();





      F1.WriteAllTextAsync(Data).Wait();


      this.DisplayAlert("Warning", "This feature is not ready yet and thus does nothing", "Ok");
    }
  }
}

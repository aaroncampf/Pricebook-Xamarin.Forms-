using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Pricebook.Droid {
  [Activity(Label = "Pricebook", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {





    protected override void OnCreate(Bundle bundle) {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);



      Views.TabsPage.GetXML = () => {
        return System.Xml.Linq.XElement.Load($"{Android.OS.Environment.ExternalStorageDirectory.Path}/Aaron/Pricebook_XamarinForms_Debug.xml");
      };

      Views.TabsPage.UpdateXML = () => {
        DownloadData("Pricebook_XamarinForms_Debug.xml", 0);
      };



      DownloadData("Pricebook_XamarinForms_Debug.xml", 0);




      Window.SetSoftInputMode(SoftInput.AdjustResize);
      AndroidBug5497WorkaroundForXamarinAndroid.assistActivity(this);


      global::Xamarin.Forms.Forms.Init(this, bundle);
      LoadApplication(new App());
    }

    protected bool DownloadData(string FileNameWithExtension, double DaysToWaitForUpdate, string DefaultFolder = "Storage") {
      var Folder = $"{Android.OS.Environment.ExternalStorageDirectory.Path}/Aaron";
      var file = new System.IO.FileInfo(Folder + "/" + FileNameWithExtension);

      //try {
      if (!System.IO.Directory.Exists(Folder)) {
        System.IO.Directory.CreateDirectory(Folder);
      }
      if (!System.IO.File.Exists(Folder + "/" + FileNameWithExtension)) {
        file.Create().Close();

        using (var output = System.IO.File.OpenWrite($"{Folder}/{FileNameWithExtension}")) {
          try {
            Passwords.DBox.GetFile($"{DefaultFolder}/{FileNameWithExtension}", null, output, null);
          }
          catch (Exception ex) {

            throw ex;
          }
        }

        return true;
      }
      else if (System.IO.File.GetCreationTime(Folder + $"/{FileNameWithExtension}") < DateTime.Now.AddDays(-DaysToWaitForUpdate)) {
        //try {
        file.Delete();
        file.Create().Close();
        //}
        //catch (Exception ex) {
        //System.Diagnostics.Debugger.Break();
        //  throw;
        //}
        using (var output = System.IO.File.OpenWrite($"{Folder}/{FileNameWithExtension}")) {
          Passwords.DBox.GetFile($"{DefaultFolder}/{FileNameWithExtension}", null, output, null);
        }

        return true;
      }
      //}
      //catch (Exception ex) {
      //  new AlertDialog.Builder(this).SetTitle(ex.Message).SetMessage(ex.ToString()).Show();
      //  System.Diagnostics.Debugger.Break();
      //  throw ex;
      //}

      return false;
      //return System.Xml.Linq.XElement.Load($"{Folder}/{FileNameWithExtension}");
    }
  }
}
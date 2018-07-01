using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodPicker.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Welcome : Page
    {
        public Welcome()
        {
            this.InitializeComponent();
        }

        

        private void About_Application(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(About_Page), true);
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register), true);
        }

        private void Profile_App(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginForProf), true);
        }

        Selected mailPass = new Selected();

        private async void LogMeIn(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadingIndicator.IsActive = true;
                var UserStuff = App.MobileService.GetTable<UserStuff>();
                var result = await UserStuff.Where(x => x.mail == mail.Text && x.password == password.Password).ToListAsync();
                if (result.Count == 0)
                {
                    MessageDialog message = new MessageDialog("Wrong Username/Password");
                    mailPass.mail = " ";
                    message.ShowAsync();
                    LoadingIndicator.IsActive = false;
                }
                else
                {
                    mailPass.mail = mail.Text;
                    this.Frame.Navigate(typeof(SelectPage), mailPass);

                }




            }
            catch (Exception x)
            {

            }



        }
    }
}

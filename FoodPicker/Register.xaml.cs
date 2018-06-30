using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using FoodPicker.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private  void Register_New_User(object sender, RoutedEventArgs e)
        {
            if(password.Password==password2.Password)
            {
                IMobileServiceTable<UserStuff> usertoadd = App.MobileService.GetTable<UserStuff>();
                try
                {
                    LoadingIndicator.IsActive = true;
                    UserStuff toadd = new UserStuff();
                    toadd.mail = mail.Text;
                    toadd.password = password.Password;
                    toadd.first = first.Text;
                    toadd.last = last.Text;
                    usertoadd.InsertAsync(toadd);
                    MessageDialog msgDialog = new MessageDialog("Thanks For Registration");
                    this.Frame.Navigate(typeof(Welcome),true);
                    msgDialog.ShowAsync();

                }
                catch(Exception x)
                {
                    LoadingIndicator.IsActive = false;
                    MessageDialog message = new MessageDialog("Error");
                    message.ShowAsync();
                }
            }else
            {
                LoadingIndicator.IsActive = false;
                MessageDialog message = new MessageDialog("Password Missmatch");
                message.ShowAsync();
            }
        }
    }
}

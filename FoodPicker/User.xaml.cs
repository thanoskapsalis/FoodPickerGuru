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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class User : Page
    {
        public User()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (Selected)e.Parameter;
            mail.Text = parameters.mail;
            Load_Info();
        }

        public async void Load_Info()
        {


            try
            {

               
                var UserTable = App.MobileService.GetTable<UserStuff>();
                var result = await UserTable.Where(x => x.mail == mail.Text).ToListAsync();
                var item = result.FirstOrDefault();
                first.Text = item.first;
                Last.Text = item.last;
               
            }
            catch (Exception x)
            {

            }
            Load_Favorites();




        }
        public async void Load_Favorites()
        {
            try
            {
                var FavoritesTable = App.MobileService.GetTable<Favorites>();
                var returned = await FavoritesTable.Where(x => x.mail == mail.Text).ToListAsync();
                StudentsList.ItemsSource = returned;
                List<string> item = new List<string>();
                foreach(var i in returned)
                {
                    item.Add(i.title);
                }
                StudentsList.ItemsSource = item;







            }
            catch(Exception x)
            {

            }
           

        }

        private void ClickItemList(object sender, ItemClickEventArgs e)
        {
            string clickedName = e.ClickedItem.ToString();
            Selected transfer = new Selected();
            transfer.title = clickedName;
            this.Frame.Navigate(typeof(UserRecipe), transfer);

        }
    }
}

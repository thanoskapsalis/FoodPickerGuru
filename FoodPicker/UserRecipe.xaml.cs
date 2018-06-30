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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserRecipe : Page
    {
        public UserRecipe()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameters = (Selected)e.Parameter;
            recipeName.Text = parameters.title;

            Load_Info();
        }


        public async void Load_Info()
        {


            try
            {

                LoadingIndicator.IsActive = true;
                var UserTable = App.MobileService.GetTable<FoodData>();
                var result = await UserTable.Where(x => x.Title==recipeName.Text).ToListAsync();
                
                var item = result.FirstOrDefault();
                recipeName.Text = item.Title;


                foodPick.Source = new BitmapImage(new Uri(item.ImageLink));
                Phase1.Text = item.Phase1;
                Phase2.Text = item.Phase2;
                Phase3.Text = item.Phase3;
                Phase4.Text = item.Phase4;
                Phase5.Text = item.Phase5;
                Phase6.Text = item.Phase6;


            }
            catch (Exception x)
            {

            }
            finally
            {
                FirstPanel.Visibility = 0;
                LoadingIndicator.IsActive = false;
            }




        }
    }
}

using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FoodPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecpitPage : Page
    {
        public RecpitPage()
        {
            this.InitializeComponent();
           

        }
        List<string> ClassClone = new List<string>();
       protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameters = (Selected)e.Parameter;
            ClassClone.Add(parameters.ingredient1);
            ClassClone.Add(parameters.ingredient2);
            ClassClone.Add(parameters.ingredient3);
            ClassClone.Add(parameters.mail);
          
            Load_Info();
        }


        public async void Load_Info()
        {
            

            try
            {

            LoadingIndicator.IsActive = true;
            var UserTable = App.MobileService.GetTable<FoodData>();
            var result = await UserTable.Where(x => x.In1==ClassClone[0] && x.In2==ClassClone[1] && x.In3==ClassClone[2]).ToListAsync();
                if (result.Count==0)
                {
                    recipeName.Text = "Sorry, Nothing to eat :(";
                    
                }
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
                FirstPanel.Visibility = 0 ; 
                LoadingIndicator.IsActive = false;
            }




        }

        private void AddtoFavorites(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            IMobileServiceTable<Favorites> addToFavorites = App.MobileService.GetTable<Favorites>();
            try
            {
                Favorites toadd = new Favorites();
                toadd.mail = ClassClone[3];
                toadd.title = recipeName.Text;
                addToFavorites.InsertAsync(toadd);
                MessageDialog msgDialog = new MessageDialog("Added Succesfully");
                
                msgDialog.ShowAsync();

            }
            catch (Exception x)
            {
                MessageDialog message = new MessageDialog("Error");
                message.ShowAsync();
            }
     
    AddtoFavoritesN.Content = "";

        }
    }
    }



   

    



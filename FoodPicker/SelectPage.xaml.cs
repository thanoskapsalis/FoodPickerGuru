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
    public sealed partial class SelectPage : Page
    {
        public SelectPage()
        {
            this.InitializeComponent();
           

        }
        int counter=0;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (Selected)e.Parameter;
            UserMail.Text=parameters.mail;
           
        }

        //Code to Select one individual item from a product team once a time//
        private void SelectedSpaghetti(object sender, RoutedEventArgs e)
        {
            Rise.IsChecked = false;
           
        }
        private void SelectedRise(object sender, RoutedEventArgs e)
        {
            Spaghetti.IsChecked = false;
            
        }

        private void SelectedPork(object sender, RoutedEventArgs e)
        {
            Chicken.IsChecked = false;
        }
    

        private void SelectedChicken(object sender, RoutedEventArgs e)
        {
            Pork.IsChecked = false;
        }

   

        private void SelectedCheese(object sender, RoutedEventArgs e)
        {
            Sauce.IsChecked = false;
        }

        private void SelectedSauce(object sender, RoutedEventArgs e)
        {
            Cheese.IsChecked = false;
        }

    

        private async void Print(object sender, RoutedEventArgs e)
        {
            //    Checking if all categories have been checked. Else popup message    //
            var checkedBoxes = MainBoard.Children.OfType<CheckBox>().Count(c => c.IsChecked==true);
            if(checkedBoxes>=3)
            {
                Selected selected = new Selected();
                List<string> Items = new List<string>();
            
                foreach(CheckBox b in MainBoard.Children.OfType<CheckBox>())
                {
                    if(b.IsChecked==true)
                    {
                        Items.Add(b.Content.ToString());
                    }
                }
                selected.ingredient1 = Items[0];
                selected.ingredient2 = Items[1];
                selected.ingredient3 = Items[2];
                selected.mail = UserMail.Text;

               
                this.Frame.Navigate(typeof(RecpitPage), selected);
            }
            if(checkedBoxes<3)
            {
                //Message//
                Windows.UI.Popups.MessageDialog showDialog = new Windows.UI.Popups.MessageDialog("Oops,you forgot something!");
                showDialog.Commands.Add(new UICommand("Try Again") { Id = 0 });
                showDialog.DefaultCommandIndex = 0;
                var result = await showDialog.ShowAsync();

            }

            
        }
            

        }
        //         END OF CHECKING        //
    }



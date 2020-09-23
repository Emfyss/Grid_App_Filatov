using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Grid_App_Filatov
{
    public partial class MainPage : ContentPage
    {
        BoxView box;
        public MainPage()
        {
           /* Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}, 
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}, 
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}, 
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}, 
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width= new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
                }

            };*/
            Grid grid = new Grid();
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < ; j++)
                {
                    //box = new BoxView { Color = Color.FromRgb(200, 100, 50) };
                    Image img = new Image { Source = ImageSource.FromFile("nolik.png" };
                    //grid.Children.Add(box, i, j);
                    grid.Children.Add(img, i, j);
                    var tap = new TapGestureRecognizer();
                    ///tap.Tapped += Tap_Tapped;
                    img.GestureRecognizers.Add(tap);
                    //tap.Tapped += async (object sender, EventArgs e) =>
                    //{
                    //    BoxView box = sender as BoxView;
                    //    if (box.Color == new Color(0, 0, 0))
                    //    {
                    //        box.Color = Color.FromRgb(200, 100, 50);
                    //    }
                    //    else
                    //    {
                    //        box.Color = new Color(0, 0, 0);

                    //    }
                    //Image img1 = sender as Image;
                    //if (img1.Source=="nolik".png)
                    //{
                    //    img1.Source = "Agiile_1.png";
                    //}
                    //else
                    //{
                    //    img1.Source = "nolik.png";
                    //}
                };

            }  
        
        }
        Content = grid;

    }

      //  private void Tap_Tapped(object sender, EventArgs e)
       // {
          //  BoxView box = sender as BoxView;
          //  box.Color = Color.FromRgb(0, 0, 0);
        //}
    
}

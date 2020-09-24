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
        Button new_game, random_player;
        public MainPage()
        {
            New_game_Clicked();
        }
        void New_game_Clicked()
        {
            Grid grid = new Grid();
            for (int i = 0; i < 4; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.White };
                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    box.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped;
                    
                }
            }
            new_game = new Button { Text = "New Game" };
            grid.Children.Add(new_game, 0, 3);
            Grid.SetColumnSpan(new_game, 2);
            random_player = new Button { Text = "Who Is First" };
            grid.Children.Add(random_player, 2, 3);
            Grid.SetColumnSpan(random_player, 2);
            Content = grid;
      

        

        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            BoxView box = sender as BoxView;
            box.Color = Color.White;
        }
    }
}


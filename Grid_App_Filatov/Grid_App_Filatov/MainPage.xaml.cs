  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grid_App_Filatov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Label[,] tictactoe = new Label[3, 3];
        string l;
        public MainPage()
        {
            Reset();
            stps = 0;
        }
        Label stat, info;
        Button newGame, randomPlayer;

        void Reset()
        {
            Grid grid = new Grid();
            for (int g = 0; g < 3; g++)
            {
                BackgroundColor = Color.White;
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int f = 0; f < 3; f++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            randomPlayer = new Button //При нажатии кнопки "Кто первый?", рандомным образом определяет, кто первый начнет!
            {
                BackgroundColor = Color.FromRgb(0, 149, 248), 
                BorderWidth = 2,
                BorderColor = Color.FromRgb(0, 149, 248),
                Text = "Кто первый?"
            };
            randomPlayer.Clicked += randomPlayer_Clicked; 
            newGame = new Button //При нажатии кнопки "Новая игра", все обнуляется и начинается новая игра!
            {
                BackgroundColor = Color.FromRgb(0, 149, 248), 
                BorderWidth = 2,
                BorderColor = Color.FromRgb(0, 149, 248),
                Text = "Новая игра"
            };
            newGame.Clicked += newGame_Clicked;
            info = new Label
            {
                FontSize = 30,
                TextColor = Color.White,
                Text = ""
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    stat = new Label
                    {
                        BackgroundColor = Color.FromRgb(0, 149, 248),
                        FontSize = 120,
                        Text = "",
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.FromRgb(0, 149, 248),
                        VerticalTextAlignment = TextAlignment.Center,
                    };
                    tictactoe[i, j] = stat;
                    l = "X";
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    grid.Children.Add(stat, i, j);
                    stat.GestureRecognizers.Add(tap);
                }
            }
            grid.Children.Add(randomPlayer, 0, 3);
            grid.Children.Add(newGame, 2, 3);
            grid.Children.Add(info, 1, 3);
            Content = grid;
        }
        private void newGame_Clicked(object sender, EventArgs e)
        {
            Reset();
            chck = 0;
            stps = 0;
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            Label stat = sender as Label;
            if (stat.Text == "")

                if (chck % 2 == 0)
                {
                    randomPlayer.Text = "Нолик";
                    stat.Text = l;
                    chck++;
                    stps++;
                }
                else if (chck % 2 != 0)
                {
                    randomPlayer.Text = "Крестик";
                    chck++;
                    stps++;
                    stat.Text = "0";
                }

            if (checkDraw() == true)
            {
                DisplayAlert("Конец игры", "Draw", "Новая игра");
                Reset();
                stps = 0;
            }

            else if (checkWinnerY() == true)
            {
                DisplayAlert("Конец игры", "Кто выиграл", "Новая игра");
                Reset();
            }
            else if (checkWinnerX() == true)
            {
                DisplayAlert("Конец игры", "Кто выиграл", "Новая игра");
                Reset();
            }
        }
        bool checkDraw()
        {
            if (stps == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkWinnerX()
        {
            if (tictactoe[0, 0].Text == "X" && tictactoe[1, 0].Text == "X" && tictactoe[2, 0].Text == "X")
            {
                return true; ;
            }
            else if (tictactoe[0, 1].Text == "X" && tictactoe[1, 1].Text == "X" && tictactoe[2, 1].Text == "X")
            {
                return true;
            }
            else if (tictactoe[0, 2].Text == "X" && tictactoe[1, 2].Text == "X" && tictactoe[2, 2].Text == "X")
            {
                return true;
            }
            if (tictactoe[0, 0].Text == "0" && tictactoe[1, 0].Text == "0" && tictactoe[2, 0].Text == "0")
            {
                return true; ;
            }
            else if (tictactoe[0, 1].Text == "0" && tictactoe[1, 1].Text == "0" && tictactoe[2, 1].Text == "0")
            {
                return true;
            }
            else if (tictactoe[0, 2].Text == "0" && tictactoe[1, 2].Text == "0" && tictactoe[2, 2].Text == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkWinnerY()
        {
            if (tictactoe[0, 0].Text == "X" && tictactoe[0, 1].Text == "X" && tictactoe[0, 2].Text == "X")
            {
                return true; ;
            }
            else if (tictactoe[1, 1].Text == "X" && tictactoe[1, 1].Text == "X" && tictactoe[1, 2].Text == "X")
            {
                return true;
            }
            else if (tictactoe[2, 0].Text == "X" && tictactoe[2, 1].Text == "X" && tictactoe[2, 2].Text == "X")
            {
                return true;
            }
            if (tictactoe[0, 0].Text == "0" && tictactoe[0, 1].Text == "0" && tictactoe[0, 2].Text == "0")
            {
                return true; ;
            }
            else if (tictactoe[1, 1].Text == "0" && tictactoe[1, 1].Text == "0" && tictactoe[1, 2].Text == "0")
            {
                return true;
            }
            else if (tictactoe[2, 0].Text == "0" && tictactoe[2, 1].Text == "X" && tictactoe[2, 2].Text == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int stps = 0;

        Random strt = new Random();
        int chck = 0;
        private void randomPlayer_Clicked(object sender, EventArgs e)
        {
            chck = strt.Next(0, 2);
            if (chck % 2 == 0)
            {
                info.Text = "Крестик";
            }
            else if (chck % 2 != 0)
            {
                info.Text = "Нолик";
            }
        }
    }
}


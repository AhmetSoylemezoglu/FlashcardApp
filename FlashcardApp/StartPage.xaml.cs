using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardApp;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    async private void OnStartClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}
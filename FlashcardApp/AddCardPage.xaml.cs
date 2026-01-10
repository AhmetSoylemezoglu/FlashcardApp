using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashcardApp.Services;

namespace FlashcardApp;

public partial class AddCardPage : ContentPage
{
    private DatabaseService _dbService; 
        
    public AddCardPage()
    {
        InitializeComponent();
        _dbService = new DatabaseService();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var newCard = new Flashcard
        {
            Front = FrontEntry.Text,
            Back = BackEntry.Text
        };
        if ((FrontEntry.Text == null) || (BackEntry.Text == null)) 
        {
            await DisplayAlert("Hata", "Lütfen iki tarafı da doldurun.", "Tamam");
            return;
        }
        else
        {
            await _dbService.SaveFlashcardAsync(newCard); //database'e kaydediyor.

            FrontEntry.Text = null; //Değer kaydettikten sonra sıfırlıyoruz entry'leri
            BackEntry.Text = null;

        }
            
        //await Navigation.PopAsync(); bu da saçma geldi belki daha fazla kaydedecem can sıkıcı olurdu hep geri dönmek zorunda kalsam.
    }

    private async void OnReturnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // geri dön butonu bu
    }
}
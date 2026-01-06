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

        await _dbService.SaveFlashcardAsync(newCard); //database'e kaydediyor.
        
        await Navigation.PopAsync(); //kayıt işi bitince dön
    }

    private async void OnReturnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // geri dön butonu bu
    }
}
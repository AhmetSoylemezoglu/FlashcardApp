using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashcardApp.Services;

namespace FlashcardApp;


public partial class DeleteCardPage : ContentPage
{
    private DatabaseService _dbService;
    public DeleteCardPage()
    {
        InitializeComponent();
        _dbService = new DatabaseService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await GetDataDropdown();
    }

    private async Task GetDataDropdown()
    {
        var cards = await _dbService.GetFlashcardsAsync();
        CardsDropdown.ItemsSource = cards;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (CardsDropdown.SelectedItem == null) //hiçbir kart seçilmemişse hata veriyor ki program çöküyor yoksa
        {
            await DisplayAlert("Hata", "Kart seçilmedi", "Tamam");
            return;
        }
        else
        {
            var selectedCard = CardsDropdown.SelectedItem as Flashcard;
        
            await _dbService.DeleteFlashcardAsync(selectedCard);
        
            CardsDropdown.SelectedItem = null;
            await GetDataDropdown();

        }
    }

    private async void OnReturnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // geri dön butonu bu
    }
}
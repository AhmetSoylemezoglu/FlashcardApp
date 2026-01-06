using FlashcardApp.Services;

namespace FlashcardApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    private DatabaseService _veriServis;
    
    public MainPage(DatabaseService service)
    {
        InitializeComponent();
        _veriServis = service;
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
            
    }
}
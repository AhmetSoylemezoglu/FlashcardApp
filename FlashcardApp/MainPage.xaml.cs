using FlashcardApp.Services;

namespace FlashcardApp;

public partial class MainPage : ContentPage
{
    int false_count = 0;
    int correct_count = 0;
    int counter = 0;
    int max_card = 20;
    
    private DatabaseService _veriServis;
    
    public MainPage(DatabaseService service)
    {
        InitializeComponent();
        _veriServis = service;
    }

    private void OnCardClicked(object? sender, EventArgs e)
    {
        CardButton.Text = "basıldı";
    }

    private void OnPrevClicked(object? sender, EventArgs e)
    {
        if (counter != 0)
        {
            counter--;
        }
        CounterLabel.Text = counter.ToString() + "/" + max_card;
    }
    
    private void OnNextClicked(object? sender, EventArgs e)
    {
        if (counter != max_card)
        {
            counter++;    
        }
        CounterLabel.Text = counter.ToString() + "/" + max_card;
    }
    
    private void OnFalseClicked(object? sender, EventArgs e)
    {
        false_count++;
        FalseLabel.Text = "Yanlış: " + false_count;
    }
    
    private void OnCorrectClicked(object? sender, EventArgs e)
    {
        correct_count++;
        CorrectLabel.Text = "Doğru: " + correct_count;
    }

    
}
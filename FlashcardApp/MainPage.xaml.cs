using FlashcardApp.Services;

namespace FlashcardApp;

public partial class MainPage : ContentPage
{
    int false_count = 0;
    int correct_count = 0;
    int counter = 0;
    int max_card;
    
    private List<Flashcard> _flashcards = new List<Flashcard>();
    private bool isShowingFront = true;
    
    private DatabaseService _dbService = new DatabaseService();
    
    public MainPage(DatabaseService service)
    {
        InitializeComponent();
        
        _dbService = service;
        
        //max_card = _flashcards.Count-1;
        //CounterLabel.Text = (counter+1) + "/" + (max_card+1);
        // LoadData async olduğundan bunlar çalışmıyor doğru düzgün.
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadData();
    }

    private async Task LoadData() //async yaptık çünkü uygulamamızın database'den çekerken donmasını istemiyoruz.
    {
        _flashcards = await _dbService.GetFlashcardsAsync();
        
        if (_flashcards.Count == 0) //veritabanı boş olduğundan şuan deneme için böyle yapacaz.
        {
            await _dbService.SaveFlashcardAsync(new Flashcard { Front = "Hola", Back = "Merhaba" });
            await _dbService.SaveFlashcardAsync(new Flashcard { Front = "Gato", Back = "Kedi" });
            
            _flashcards = await _dbService.GetFlashcardsAsync();
        }
        
        MainThread.BeginInvokeOnMainThread(() =>
        {
            max_card = _flashcards.Count - 1;
            CounterLabel.Text = (counter+1) + "/" + (max_card+1);
            UpdateCard(); 
        });
        
        //_flashcards.Add(new Flashcard { Front = "Hola", Back = "Merhaba" });
        //_flashcards.Add(new Flashcard { Front = "Gato", Back = "Kedi" });
        //_flashcards.Add(new Flashcard { Front = "Perro", Back = "Köpek" });
        //_flashcards.Add(new Flashcard { Front = "Libro", Back = "Kitap" });
        //_flashcards.Add(new Flashcard { Front = "Programador", Back = "Yazılımcı" });
    }

    private void UpdateCard()
    {
        if (_flashcards.Count == 0) return; //Eğer liste boşsa direk döndür bir şey yapma demek bu.

        Flashcard currentCard = _flashcards[counter];
        
        if (isShowingFront)
        {
            CardButton.Text = currentCard.Front;
        }
        else
        {
            CardButton.Text = currentCard.Back;
        }
    }


    private async void OnAddCardClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCardPage());
    }
        
    private void OnCardClicked(object? sender, EventArgs e)
    {
        isShowingFront = !isShowingFront;
        UpdateCard();
        //CardButton.Text = "basıldı";
    }

    private void OnPrevClicked(object? sender, EventArgs e)
    {
        if (counter != 0)
        {
            counter--;
        }
        CounterLabel.Text = (counter+1) + "/" + (max_card+1);
        isShowingFront = true;
        UpdateCard();
    }
    
    private void OnNextClicked(object? sender, EventArgs e)
    {
        if (counter != max_card)
        {
            counter++;    
        }
        CounterLabel.Text = (counter+1) + "/" + (max_card+1);
        isShowingFront = true;
        UpdateCard();
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
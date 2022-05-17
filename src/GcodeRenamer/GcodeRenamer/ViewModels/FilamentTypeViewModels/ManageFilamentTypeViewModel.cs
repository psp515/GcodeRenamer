namespace GcodeRenamer.ViewModels;

[QueryProperty(nameof(Id),nameof(Id))]
public class ManageFilamentTypeViewModel : BaseViewModel
{
    public string Id { get; set; }

    FilamentType filamentType;
    public FilamentType FilamentType { get => filamentType; set=>SetProperty(ref filamentType, value); }

    FilamentService FilamentService;

    string buttonText;
    public string ButtonText { get => buttonText; set => SetProperty(ref buttonText, value); }


    public Command InteractCommand { get; }

    bool isAdding { get; set; }

    public ManageFilamentTypeViewModel(FilamentService filamentService)
    {
        FilamentService = filamentService;

        InteractCommand = new Command(Interact);
        FilamentType = new FilamentType();
    }

    protected internal override async void OnAppearing()
    {
        base.OnAppearing();

        if (!string.IsNullOrEmpty(Id))
        {
            isAdding = false;
            buttonText = "Update";
            FilamentType = await FilamentService.GetItemAsync(Convert.ToInt32(Id));
        }
        else
        {
            isAdding = true;
            buttonText = "Add";
            FilamentType = new FilamentType();
        }
    }

    public async void Interact()
    {
        if (IsBusy)
            return;

        IsBusy = true;

        if (isAdding)
        {
            await FilamentService.AddItemAsync(FilamentType);
        }
        else
        {
            await FilamentService.UpdateItemAsync(FilamentType);
        }

        IsBusy = false;
        await Shell.Current.GoToAsync("..");
    }

}
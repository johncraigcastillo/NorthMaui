using System.ComponentModel;
using System.Runtime.CompilerServices;
using NorthMaui.Services;

namespace NorthMaui;

public sealed partial class FoodPage : INotifyPropertyChanged
{
    private readonly DataService _dataService = new();
    private bool _isBusy;

    public new event PropertyChangedEventHandler PropertyChanged;

    public new bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            BindingContext = this;
            OnPropertyChanged();
        }
    }

    public FoodPage()
    {
        InitializeComponent();
        LoadFoodItems();
    }

    private async void LoadFoodItems()
    {
        IsBusy = true;
        var foodItems = await _dataService.GetFoodItemsAsync();
        FoodItemsCollectionView.ItemsSource = foodItems;
        IsBusy = false;
    }

    private new void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
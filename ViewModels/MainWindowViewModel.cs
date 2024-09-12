using ccaaffee.Views;
using System;
namespace ccaaffee.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public DrinkPage DrinksPage { get; set; }
        public StaffsPage StaffsPage { get; set; }
        public MainWindowViewModel()
        {
            DrinksPage = new DrinkPage();
            DrinksPage.DataContext = new DrinksPageViewModel();

            StaffsPage = new StaffsPage();
            StaffsPage.DataContext = new StaffsPageViewModel();
        }

    }
}
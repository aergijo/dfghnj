using ccaaffee.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ccaaffee.ViewModels
{
    public class DrinksPageViewModel : ViewModelBase
    {
        private DbIs617Context db = new DbIs617Context();
        private Drink currentdrink;
        public Drink Currentdrink
        {
            get => currentdrink;
            set => this.RaiseAndSetIfChanged(ref currentdrink, value);
        }

        private ObservableCollection<Drink> drinks = new ObservableCollection<Drink>();
        public ObservableCollection<Drink> Drinks
        {
            get => drinks;
            set => this.RaiseAndSetIfChanged(ref drinks, value);
        }

        
        public DrinksPageViewModel()
        {
            Update();
        }

        public void Update()
        {
            db = new DbIs617Context();
            db.Drinks.Load();
            Drinks = db.Drinks.Local.ToObservableCollection();

        }
        public void Add()
        {
            var _drink = new Drink();
            db.Drinks.Local.Add(_drink);
            Drinks = db.Drinks.Local.ToObservableCollection();
            currentdrink = _drink;
        }
        public void Delete()
        {
            db.Drinks.Remove(currentdrink);
            Drinks = db.Drinks.Local.ToObservableCollection();
        }
        public void Save()
        {
            db.SaveChanges();
            Update();
        }

    }
}

using ccaaffee.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace ccaaffee.ViewModels
{
    public class StaffsPageViewModel : ViewModelBase

    {
        private DbIs617Context db = new DbIs617Context();
        private Staff currentstaff;
        public Staff CurrentStaff
        {
            get => currentstaff;
            set => this.RaiseAndSetIfChanged(ref currentstaff, value);
        }

        private ObservableCollection<Staff> staffs = new ObservableCollection<Staff>();
        public ObservableCollection<Staff> Staffs
        {
            get => staffs;
            set => this.RaiseAndSetIfChanged(ref staffs, value);
        }


        public StaffsPageViewModel()
        {
            Update();
        }

        public void Update()
        {
            db = new DbIs617Context();
            db.Staff.Load();
            Staffs = db.Staff.Local.ToObservableCollection();

        }
        public void Add()
        {
            var _staff = new Staff();
            db.Staff.Local.Add(_staff);
            Staffs = db.Staff.Local.ToObservableCollection();
            CurrentStaff = _staff;
        }
        public void Delete()
        {
            db.Staff.Remove(CurrentStaff);
            Staffs = db.Staff.Local.ToObservableCollection();
        }
        public void Save()
        {
            db.SaveChanges();
            Update();
        }
    
    }
}

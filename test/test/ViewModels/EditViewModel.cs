using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace test.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        Page1ViewModel personEdit;
        bool isEditing;

        public event PropertyChangedEventHandler PropertyChanged;
        public EditViewModel()
        {
            NewCommand = new Command(
                execute: () =>
                {
                    PersonEdit = new Page1ViewModel();
                    PersonEdit.PropertyChanged += OnPersonEditPropertyChanged;
                    IsEditing = true;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return !IsEditing;
                });
        }
        void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (SubmitCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (NewCommand as Command).ChangeCanExecute();
            (SubmitCommand as Command).ChangeCanExecute();
            (CancelCommand as Command).ChangeCanExecute();
        }


        public bool IsEditing
        {
            private set { SetProperty(ref isEditing, value); }
            get { return isEditing; }
        }

        public Page1ViewModel PersonEdit
        {
            set { SetProperty(ref personEdit, value); }
            get { return personEdit; }
        }

        public ICommand NewCommand { private set; get; }

        public ICommand SubmitCommand { private set; get; }

        public ICommand CancelCommand { private set; get; }

        public IList<Page1ViewModel> Persons { get; } = new ObservableCollection<Page1ViewModel>();

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

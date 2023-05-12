using GalaSoft.MvvmLight.Command;
using ProgrammingTest.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ProgrammingTest.ViewModel
{
    //using MvvmLight dependency for command bindings

    public class DisplayPageViewModel : PageViewModelBase
    {
        #region Commands
        public ICommand AddUserbtn { get; private set; }
        public ICommand EditUserbtn { get; private set; }
        public ICommand CanclePopupbtn { get; private set; }
        public ICommand OkCustomerCreationbtn { get; private set; }
        #endregion

        public DisplayPageViewModel()
        {
            //bind commands
            AddUserbtn = new RelayCommand(AddUserbtnExecute, true);
            EditUserbtn = new RelayCommand(EditUserbtnExecute, true);
            CanclePopupbtn = new RelayCommand(CanclePopupbtnExecute, true);
            OkCustomerCreationbtn = new RelayCommand(CreateUserExecute, CanExecuteModifyCustomerCommand);

            //generate default users
            CustomerList.Add(new CustomerMdl("Joe", 23, "AS45 3FG", 1.94));
            CustomerList.Add(new CustomerMdl("Tom", 18, "GH83 3FH", 12));
            CustomerList.Add(new CustomerMdl("Phoena", 48, "KF07 5GN", 2.09));
        }

        #region Main properties
        public ObservableCollection<CustomerMdl> CustomerList { get; private set; } = new ObservableCollection<CustomerMdl>(); //use interface for more complex models

        private CustomerMdl selectedCustomer;
        public CustomerMdl SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                if (value != null)
                {
                    EnableEdit = true;
                    NotifyPropertyChanged(nameof(EnableEdit));
                }
            }
        }

        public bool EnableEdit { get; private set; }
        private bool Popuptype = true; //true for new false of edit

        #endregion

        #region Popup Properties
        public bool PopupVisibility { get; set; } = false;
        public string PopupHeader { get; private set; } //the header of the popup that states if it's in the add or edit stage

        private string nameInput;
        private int ageInput;
        private string postcodeInput;
        private double heightInput;

        public string NameInput { get => nameInput; set { nameInput = value; NotifyPropertyChanged(nameof(NameInput)); } }
        public int AgeInput { get => ageInput; set { ageInput = value; NotifyPropertyChanged(nameof(AgeInput)); } }
        public string PostcodeInput { get => postcodeInput; set { postcodeInput = value; NotifyPropertyChanged(nameof(PostcodeInput)); } }
        public double HeightInput { get => heightInput; set { heightInput = value; NotifyPropertyChanged(nameof(HeightInput)); } }
        #endregion

        #region Methods
        public void AddUserbtnExecute()
        {
            Popuptype = true;

            PopupHeader = "Add New User";
            NotifyPropertyChanged(nameof(PopupHeader));

            //clear the display values
            PostcodeInput = NameInput = string.Empty;
            AgeInput = 0;
            HeightInput = 0.00;

            PopupVisibility = true;
            NotifyPropertyChanged(nameof(PopupVisibility));
        }
        public void EditUserbtnExecute()
        {
            Popuptype = false;

            PopupHeader = "Edit Existing User";
            NotifyPropertyChanged(nameof(PopupHeader));

            //update the display values
            PostcodeInput = SelectedCustomer.PostCode;
            NameInput = SelectedCustomer.Name;
            AgeInput = SelectedCustomer.Age;
            HeightInput = SelectedCustomer.Height;

            PopupVisibility = true;
            NotifyPropertyChanged(nameof(PopupVisibility));
        }
        public void CanclePopupbtnExecute() //dont need to clear the value as this is done on popup open
        {
            PopupVisibility = false;
            NotifyPropertyChanged(nameof(PopupVisibility));
        }

        private bool CanExecuteModifyCustomerCommand()
        {
            return (Services.ValidationService.NameValidation(NameInput) &&
                Services.ValidationService.AgeValidation(AgeInput) &&
                Services.ValidationService.PostCodeValidation(PostcodeInput) &&
                Services.ValidationService.HeightValidation(HeightInput));
        }
        public void CreateUserExecute()
        {
            if (!Popuptype) //if editing remove the existing cutomer and replace with a new one, else just add the new one
                CustomerList.Remove(SelectedCustomer);

            CustomerList.Add(new CustomerMdl(NameInput, AgeInput, PostcodeInput, HeightInput));

            CanclePopupbtnExecute();
        }
        #endregion
    }
}

using GalaSoft.MvvmLight.Command;
using ProgrammingTest.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
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
            AddUserbtn = new RelayCommand(AddUserbtnExecute);
            EditUserbtn = new RelayCommand(EditUserbtnExecute);
            CanclePopupbtn = new RelayCommand(CanclePopupbtnExecute);
            OkCustomerCreationbtn = new RelayCommand(CreateUserExecute);

            //generate default users
            CustomerList.Add(new CustomerMdl("Joe", 23, "AS45 3FG", 1.94));
            CustomerList.Add(new CustomerMdl("Tom", 18, "GH83 3FH", 1.2));
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
        private int ageInput; private int localagecopy;
        private string postcodeInput;
        private double heightInput; private double localheightcopy;

        public string NameInput { get => nameInput; set { nameInput = value; NotifyPropertyChanged(nameof(NameInput)); NotifyPropertyChanged(nameof(EnableSaveBtn)); } }
        public string AgeInput { get => ageInput.ToString(); set
            {
                if (int.TryParse(value, out localagecopy))
                {
                    ageInput = localagecopy;
                    NotifyPropertyChanged(nameof(AgeInput));
                    NotifyPropertyChanged(nameof(EnableSaveBtn));
                }
                else { }//else dont update
            }
        }
        public string PostcodeInput { get => postcodeInput; set { postcodeInput = value; NotifyPropertyChanged(nameof(PostcodeInput)); NotifyPropertyChanged(nameof(EnableSaveBtn)); } }
        public string HeightInput { get => heightInput.ToString(); 
            set {
                if (double.TryParse(value, out localheightcopy))
                {
                    heightInput = Math.Round(localheightcopy, 2);
                    NotifyPropertyChanged(nameof(HeightInput));
                    NotifyPropertyChanged(nameof(EnableSaveBtn));
                }
                else { }//else dont update
            } 
        }

        public bool EnableSaveBtn { get => CanExecuteModifyCustomerCommand();}
        #endregion

        #region Methods
        public void AddUserbtnExecute()
        {
            Popuptype = true;

            PopupHeader = "Add New User";
            NotifyPropertyChanged(nameof(PopupHeader));

            //clear the display values
            PostcodeInput = NameInput = string.Empty;
            AgeInput = "0";
            HeightInput = "0.00";

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
            AgeInput = SelectedCustomer.Age.ToString();
            HeightInput = SelectedCustomer.Height.ToString();

            PopupVisibility = true;
            NotifyPropertyChanged(nameof(PopupVisibility));
        }
        public void CanclePopupbtnExecute() //dont need to clear the value as this is done on popup open
        {
            PopupVisibility = false;
            NotifyPropertyChanged(nameof(PopupVisibility));

            SelectedCustomer = null;
            NotifyPropertyChanged(nameof(SelectedCustomer));
        }

        private bool CanExecuteModifyCustomerCommand()
        {
            return (Services.ValidationService.NameValidation(NameInput) &&
                Services.ValidationService.AgeValidation(int.Parse(AgeInput)) &&
                Services.ValidationService.PostCodeValidation(PostcodeInput) &&
                Services.ValidationService.HeightValidation(double.Parse(HeightInput)));
        }
        public void CreateUserExecute()
        {
            if (!Popuptype) //if editing remove the existing cutomer and replace with a new one, else just add the new one
                CustomerList.Remove(SelectedCustomer);

            CustomerList.Add(new CustomerMdl(NameInput, int.Parse(AgeInput), PostcodeInput, double.Parse(HeightInput)));

            CanclePopupbtnExecute();
        }
        #endregion
    }
}

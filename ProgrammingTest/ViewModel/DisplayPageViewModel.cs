using ProgrammingTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.ViewModel
{
    public class DisplayPageViewModel : PageViewModelBase
    {
        #region Commands

        #endregion

        public DisplayPageViewModel()
        {
            CustomerList.Add(new CustomerMdl("Joe", 23, "AS45 3FG", 1.94));
            CustomerList.Add(new CustomerMdl("Tom", 18, "GH83 3FH", 12));
            CustomerList.Add(new CustomerMdl("Phoena", 48, "KF07 5GN", 2.09));
        }

        #region properties
        public ObservableCollection<CustomerMdl> CustomerList { get; private set; } = new ObservableCollection<CustomerMdl>(); //use interface for more complex models

        private CustomerMdl selectedCustomer;
        public CustomerMdl SelectedCustomer
        {
            get => selectedCustomer;
            set {
                selectedCustomer = value;
                if(value != null)
                {
                    EnableEdit = true;
                    NotifyPropertyChanged(nameof(EnableEdit));
                }
            }
        }

        public bool EnableEdit { get; private set; }
        #endregion

        #region methods

        #endregion
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProgrammingTest.ViewModel
{
    public class PageViewModelBase : INotifyPropertyChanged //this is the microsoft implimentation https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-7.0
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalienceThemes.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace SalienceThemes.ViewModels
{
    class PathViewModel : INotifyPropertyChanged
    {
        public PathViewModel()
        {
            _path = new Path { LicensePath = "C:/Program Files (x86)/Lexalytics/License.v5", DataPath = "C:/Program Files (x86)/Lexalytics/data" };
        }
        Path _path;
        int _count = 0;

        public Path Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public string LicensePath
        {
            get { return Path.LicensePath; }
            set
            {
                if (Path.LicensePath != value)
                {
                    Path.LicensePath = value;
                    RaisePropertyChanged("LicensePath");
                }
            }
        }

        public string DataPath
        {
            get { return Path.DataPath; }
            set
            {
                if (Path.DataPath != value)
                {
                    Path.DataPath = value;
                    RaisePropertyChanged("DataPath");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void UpdatePathExecute()
        {
            ++ _count;
            DataPath = string.Format("", _count);
            LicensePath = string.Format("", _count);
        }

        bool CanUpdatePathExecute()
        {
            return true;
        }

        public ICommand UpdatePath
        {
            get { return new RelayCommand(UpdatePathExecute, CanUpdatePathExecute); }
        }
    }
}
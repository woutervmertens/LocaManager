using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using LocaManager.Annotations;
using LocaManager.Model;

namespace LocaManager.ViewModel
{
    public class SettingsVM : INotifyPropertyChanged
    {
        private SettingsModel localSettingsModel;
        public SettingsModel LocalSettingsModel
        {
            get
            {
                if (localSettingsModel == null)
                    localSettingsModel = MainVM.Settings;
                return localSettingsModel;
            }
            set
            {
                localSettingsModel = value;
                OnPropertyChanged("LocalSettingsModel");
            }
        }

        private string projectLoc;
        public string ProjectLoc
        {
            get
            {
                if (projectLoc == null) projectLoc = LocalSettingsModel.ProjectLocation;
                return projectLoc;
            }
            set
            {
                projectLoc = value;
                LocalSettingsModel.ProjectLocation = value;
                OnPropertyChanged("ProjectLoc");
            }
        }

        //Commands
        private ICommand save;
        public ICommand SaveCommand
        {
            get { return save; }
        }
        private ICommand setProjectLocation;
        public ICommand SetProjectLocationCommand
        {
            get { return setProjectLocation; }
        }

        public Action CloseAction { get; set; }

        public SettingsVM()
        {
            save = new Command(Save);
            setProjectLocation = new Command(SetProjectLocation);
        }

        public void SetProjectLocation()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ProjectLoc = dialog.SelectedPath;
                    OnPropertyChanged("ProjectLoc");
                }
            }
        }

        public void Save()
        {
            MainVM.Settings = LocalSettingsModel;
            CloseAction();
        }

        //OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

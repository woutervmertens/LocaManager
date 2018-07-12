using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LocaManager.Annotations;
using LocaManager.Model;

namespace LocaManager.ViewModel
{
    public class LevelDialogVM : INotifyPropertyChanged
    {
        public bool isProd = true;
        private int _levelId;
        public int LevelId
        {
            get { return _levelId; }
            set
            {
                if (value == _levelId) return;
                _levelId = value;
                OnPropertyChanged("LevelId");
            }
        }
        private string _accessToken;
        public string AccessToken
        {
            get { return _accessToken; }
            set
            {
                if (value == _accessToken) return;
                _accessToken = value;
                OnPropertyChanged("AccessToken");
            }
        }

        private ObservableCollection<LevelModel> _locasFromLevel;
        public ObservableCollection<LevelModel> LocasFromLevel
        {
            get { return _locasFromLevel; }
            set
            {
                if (value == _locasFromLevel) return;
                _locasFromLevel = value;
                OnPropertyChanged("LocasFromLevel");
            }
        }

        //Command
        private ICommand loadFromLevel;
        public ICommand LoadFromLevelCommand
        {
            get { return loadFromLevel; }
        }
        private ICommand saveLocally;
        public ICommand SaveLocallyCommand
        {
            get { return saveLocally; }
        }
        private ICommand saveToLoca;
        public ICommand SaveToLocaCommand
        {
            get { return saveToLoca; }
        }

        public LevelDialogVM()
        {
            LocasFromLevel = new ObservableCollection<LevelModel>();
            loadFromLevel = new Command(LoadFromLevel);
            saveLocally = new Command(SaveLocally);
            saveToLoca = new Command(SaveToLoca);
        }

        public void LoadFromLevel()
        {
            LocasFromLevel.Add(GetLocaFromLevel());
        }

        public void SaveLocally()
        {
            foreach (var item in LocasFromLevel)
            {
                if (item.LocaKeys.Count == 0) continue;
                File.WriteAllLines(MainVM.Settings.LocalSaveLocation + @"\" + item.ID + ".txt", item.LocaKeys);
            }
        }

        public void SaveToLoca()
        {
            foreach (var item in LocasFromLevel)
            {
                if (item.LocaKeys.Count == 0) continue;
                MainVM.instance.AddLocaFromLevel(item);
            }
        }

        private LevelModel GetLocaFromLevel()
        {
            LevelModel lm = new LevelModel();

            //Get the server data and paste into a string
            WebClient myClient = new WebClient();
            Stream response =
                myClient.OpenRead(MainVM.Settings.GetAddress(isProd, LevelId, AccessToken));

            StreamReader sr = new StreamReader(response);
            string str = sr.ReadToEnd();

            //Get all the dialog
            bool notEnd = true;
            while (notEnd)
            {
                int startIndex = str.IndexOf(MainVM.Settings.DialogStart);
                if (startIndex > 0)
                {
                    str = str.Substring(startIndex);
                    int endIndex = str.IndexOf(MainVM.Settings.DialogEnd);
                    lm.LocaKeys.Add(str.Substring(30, endIndex - 30));
                    str = str.Substring(endIndex);
                }
                else
                {
                    notEnd = false;
                }
            }
            lm.ID = LevelId;
            return lm;
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

using LocaManager.Annotations;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace LocaManager.Model
{
    public class SettingsModel : INotifyPropertyChanged
    {
        private string projectLocation = "";
        public string ProjectLocation
        {
            get
            {
                if (projectLocation == "") projectLocation = @"C:\Users\woute\Source\Dreamz";
                return projectLocation;
            }
            set
            {
                projectLocation = value;
                OnPropertyChanged("ProjectLocation");
            }
        }

        private string localSaveLocation = "";
        public string LocalSaveLocation
        {
            get
            {
                return localSaveLocation;
            }
            set
            {
                localSaveLocation = value;
                OnPropertyChanged("LocaSaveLocation");
            }
        }

        private string locaOffset = "";
        public string LocaOffset
        {
            get
            {
                if (locaOffset == "") locaOffset = @"\Dreamers\Assets\AddsOn\I2\Resources\I2Languages.prefab";
                return locaOffset;
            }
            set
            {
                locaOffset = value;
                OnPropertyChanged("LocaOffset");
            }
        }

        private string prodAddress = "";
        public string ProdAddress
        {
            get
            {
                if(prodAddress == "") prodAddress = "https://prod.crazy-dreamz.com/api/APILevelScores/play?access_token=";
                return prodAddress;
            }
            set
            {
                prodAddress = value;
                OnPropertyChanged("ProdAddress");
            }
        }

        private string devAddress = "";
        public string DevAddress
        {
            get
            {
                if(devAddress == "") devAddress = "https://dev.crazy-dreamz.com/api/APILevelScores/play?access_token=";
                return devAddress;
            }
            set
            {
                devAddress = value;
                OnPropertyChanged("DevAddress");
            }
        }

        private string levelDataCommand = "";
        public string LevelDataCommand
        { 
            get
            {
                if(levelDataCommand == "") levelDataCommand = "&IdLevelData=";
                return levelDataCommand;
            }
            set
            {
                levelDataCommand = value;
                OnPropertyChanged("LevelDataCommand");
            }
        }

        private string dialogStart = "";
        public string DialogStart
        {
            get
            {
                if (dialogStart == "") dialogStart = @"argTextB\"":true";
                return dialogStart;
            }
            set
            {
                dialogStart = value;
                OnPropertyChanged("DialogStart");
            }
        }

        private string dialogEnd = "";
        public string DialogEnd
        {
            get
            {
                if (dialogEnd == "") dialogEnd = @"\"",";
                return dialogEnd;
            }
            set
            {
                dialogEnd = value;
                OnPropertyChanged("DialogEnd");
            }
        }

        private string locaStart = "";
        public string LocaStart
        {
            get
            {
                if (locaStart == "") locaStart = "mTerms:";
                return locaStart;
            }
            set
            {
                locaStart = value;
                OnPropertyChanged("LocaStart");
            }
        }

        private string locaEnd = "";
        public string LocaEnd
        {
            get
            {
                if (locaEnd == "") locaEnd = "  mLanguages:";
                return locaEnd;
            }
            set
            {
                locaEnd = value;
                OnPropertyChanged("LocaEnd");
            }
        }

        private string term = "";
        public string Term
        {
            get
            {
                if (term == "") term = "  - Term: ";
                return term;
            }
            set
            {
                term = value;
                OnPropertyChanged("Term");
            }
        }

        private string desc = "";
        public string Desc
        {
            get
            {
                if (desc == "") desc = "    Description: ";
                return desc;
            }
            set
            {
                desc = value;
                OnPropertyChanged("Desc");
            }
        }

        private string lan = "";
        public string Lan
        {
            get
            {
                if (lan == "") lan = "    - ";
                return lan;
            }
            set
            {
                lan = value;
                OnPropertyChanged("Lan");
            }
        }

        private string locaFormat = "";
        public string LocaFormat
        {
            get
            {
                if (locaFormat == "") locaFormat = 
                        Term + "{0}\n" +
                        "    TermType: 0\n" +
                        Desc + "{1}\n" +
                        "    Languages:\n" +
                        Lan + "{2}\n" +
                        Lan + "{3}\n" +
                        Lan + "{4}\n" +
                        Lan + "{5}\n" +
                        Lan + "{6}\n" +
                        Lan + "{7}\n" +
                        "    Languages_Touch:\n" +
                        "    -\n" +
                        "    -\n" +
                        "    -\n" +
                        "    -\n" +
                        "    -\n" +
                        "    -\n" +
                        "    Flags: 000000000000";
                return locaFormat;
            }
            set
            {
                locaFormat = value;
                OnPropertyChanged("LocaFormat");
            }
        }

        public string GetLocaLocation()
        {
            return ProjectLocation + LocaOffset;
        }

        public string GetAddress(bool isProd, int levelId, string accessToken)
        {
            if (isProd)
                return ProdAddress + accessToken + LevelDataCommand + levelId;
            return DevAddress + accessToken + LevelDataCommand + levelId;
        }

        public void Save(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(SettingsModel));
                xmls.Serialize(sw, this);
            }
        }

        public SettingsModel Load(string filename)
        {
            if (!File.Exists(filename)) return new SettingsModel();
            using (StreamReader sw = new StreamReader(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(SettingsModel));
                return xmls.Deserialize(sw) as SettingsModel;
            }
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

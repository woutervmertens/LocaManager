using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LocaManager.Annotations;
using LocaManager.Model;
using LocaManager.View;

namespace LocaManager.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public static SettingsModel Settings;
        public static SaveSystem Savesystem;
        public static MainVM instance;

        private int _numberOfTerms = 0;
        public int NumberOfTerms
        {
            get { return _numberOfTerms; }
            set
            {
                _numberOfTerms = value;
                OnPropertyChanged("NumberOfTerms");
            }
        }

        private int _numberOfViewTerms = 0;
        public int NumberOfViewTerms
        {
            get { return _numberOfViewTerms; }
            set
            {
                _numberOfViewTerms = value;
                OnPropertyChanged("NumberOfViewTerms");
            }
        }

        private int _numberOfNewTerms = 0;
        public int NumberOfNewTerms
        {
            get { return _numberOfNewTerms; }
            set
            {
                _numberOfNewTerms = value;
                OnPropertyChanged("NumberOfNewTerms");
            }
        }

        private int _numberOfEditedTerms = 0;
        public int NumberOfEditedTerms
        {
            get { return _numberOfEditedTerms; }
            set
            {
                _numberOfEditedTerms = value;
                OnPropertyChanged("NumberOfEditedTerms");
            }
        }

        private LocaModel _selectedLoca;
        public LocaModel SelectedLoca
        {
            get { return _selectedLoca; }
            set
            {
                _selectedLoca = value;
                OnPropertyChanged("SelectedLoca");
            }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                if (_selectedIndex == value) return;
                _selectedIndex = value;
                if(value >= 0 && value < Locas.Count)SelectedLoca = Locas[value];
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged("Searchtext");
            }
        }

        private ObservableCollection<LocaModel> _locas = new ObservableCollection<LocaModel>();
        public ObservableCollection<LocaModel> Locas
        {
            get { return _locas; }
            set
            {
                _locas = value;
                NumberOfViewTerms = _locas.Count;
                OnPropertyChanged("Locas");
            }
        }

        private ObservableCollection<LocaModel> _locasBG = new ObservableCollection<LocaModel>();
        public ObservableCollection<LocaModel> LocasBG
        {
            get { return _locasBG; }
            set
            {
                _locasBG = value;
                NumberOfTerms = _locasBG.Count;
                OnPropertyChanged("LocasBG");
            }
        }

        //Commands
        private ICommand search;
        public ICommand SearchCommand
        {
            get { return search; }
        }
        private ICommand loadData;
        public ICommand LoadDataCommand
        {
            get { return loadData; }
        }
        private ICommand newLoca;
        public ICommand NewLocaCommand
        {
            get { return newLoca; }
        }
        private ICommand fromLevelId;
        public ICommand FromLevelIdCommand
        {
            get { return fromLevelId; }
        }
        private ICommand settings;
        public ICommand SettingsCommand
        {
            get { return settings; }
        }
        private ICommand saveEdit;
        public ICommand SaveEditCommand
        {
            get { return saveEdit; }
        }

        private bool isFirstLoad = true;

        public MainVM()
        {
            instance = this;

            //SetCommands
            search = new Command(OnClickSearch);
            loadData = new Command(OnClickLoadData);
            newLoca = new Command(OnClickNewLoca);
            fromLevelId = new Command(OnClickFromLevelId);
            settings = new Command(OnClickSettings);
            saveEdit = new Command(OnClickSaveEdit);

            //Initialize SaveSystem and Load Settings
            Savesystem = new SaveSystem();
            Savesystem.LoadSettings();
            //Show Settings
            OnClickSettings();
        }

        public void Init()
        {
            //Save Settings
            Savesystem.SaveSettings();
            //Check if first load
            if (!isFirstLoad) return;
            //Load
            Savesystem.LoadLoca();
            isFirstLoad = false;
        }

        public void SetLocas(ObservableCollection<LocaModel> locas)
        {
            LocasBG = new ObservableCollection<LocaModel>(locas);
            Locas = new ObservableCollection<LocaModel>(locas);
        }
        public void AddLoca(LocaModel loca)
        {
            LocasBG.Add(loca);
            Locas.Add(loca);
            NumberOfNewTerms++;
        }

        public void AddLocaFromLevel(LevelModel level)
        {
            foreach (var item in level.LocaKeys)
            {
                LocaModel loca = new LocaModel();
                loca.Index = level.ID;
                loca.IsNew = true;
                loca.Term = item;
                AddLoca(loca);
            }
        }

        //Commands
        public void OnClickSearch()
        {
            if (SearchText == "") Locas = LocasBG;
            else
            {
                SelectedIndex = 0;
                Locas.Clear();
                //IEnumerable<LocaModel> query = LocasBG.Where(i => i.Term.Contains(SearchText));
                foreach (LocaModel lm in FindByTerm(LocasBG, SearchText))
                {
                    Locas.Add(lm);
                }
                NumberOfViewTerms = Locas.Count;
            }
        }

        public void OnClickLoadData()
        {
            Savesystem.LoadLoca();
        }

        public void OnClickNewLoca()
        {
            AddLoca(new LocaModel());
            SelectedIndex = Locas.Count - 1;
        }

        public void OnClickFromLevelId()
        {
            var ld = new LevelDialog();
            ld.ShowDialog();
        }

        public void OnClickSettings()
        {
            var sd = new Settings();
            (sd.DataContext as SettingsVM).CloseAction = () => { sd.Close(); Init(); };
            sd.ShowDialog();
        }

        public void OnClickSaveEdit()
        {
            if(!SelectedLoca.IsEdited)
            {
                SelectedLoca.IsEdited = true;
                NumberOfEditedTerms++;
            }
            Locas[SelectedIndex] = SelectedLoca;
        }

        //Find
        IEnumerable<LocaModel> FindByTerm(IEnumerable<LocaModel> coll, String name)
        {
            foreach (LocaModel lm in coll)
            {
                if (lm.Term.ToLowerInvariant().Contains(name.ToLowerInvariant()))
                    yield return lm;
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

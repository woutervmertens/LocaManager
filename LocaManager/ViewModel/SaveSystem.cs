using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using LocaManager.ViewModel;

namespace LocaManager.Model
{
    public class SaveSystem
    {
        public const string UserSettingsFilename = "settings.xml";
        public string _DefaultSettingspath = Assembly.GetEntryAssembly().Location + "\\Settings\\" + UserSettingsFilename;
        public string _UserSettingsPath = Assembly.GetEntryAssembly().Location + "\\Settings\\UserSettings\\" + UserSettingsFilename;

        private List<String> locaTextLines;

        public void SaveSettings()
        {
            MainVM.Settings.Save(_UserSettingsPath);
        }

        public void LoadSettings()
        {
            //if user settings exist
            if (File.Exists(_UserSettingsPath))
                MainVM.Settings = MainVM.Settings.Load(_UserSettingsPath);
            else if (File.Exists(_DefaultSettingspath))
                MainVM.Settings = MainVM.Settings.Load(_DefaultSettingspath);
            else
                MainVM.Settings = new SettingsModel();
        }

        public void SaveLoca(List<LocaModel> locas)
        {
            string toAddToTheEnd = "";
            int c = locas.Count;
            for (int i = 0; i < c; i++)
            {
                if (locas[i].IsNew)
                    toAddToTheEnd += TransformLocaModelToString(locas[i]);
                else if (locas[i].IsEdited)
                    InsertLocaIntoFile(locas[i]);
            }

            AddStringToEndOfLocaFile(toAddToTheEnd);

            File.WriteAllLines(MainVM.Settings.GetLocaLocation(), locaTextLines);
        }

        public void LoadLoca()
        {
            //Load all lines
            string locaLoc = MainVM.Settings.GetLocaLocation();
            if (locaLoc == null || locaLoc == "" || locaLoc == MainVM.Settings.LocaOffset) return;

            locaTextLines = File.ReadAllLines(locaLoc).ToList();

            //Merge multiLine strings
            RemoveDoubleLinesFromList();

            //Convert lines to LocaModels
            ConvertLinesToLocas();
        }

        /// <summary>
        /// returns Formatted version of given LocaModel
        /// </summary>
        /// <param name="lm">LocaModel</param>
        /// <returns></returns>
        private string TransformLocaModelToString(LocaModel lm)
        {
            return "\n" + lm.Format(MainVM.Settings.LocaFormat);
        }

        /// <summary>
        /// Adds given text to end of loca file
        /// </summary>
        /// <param name="whatToAdd">Text to add</param>
        private void AddStringToEndOfLocaFile(string whatToAdd)
        {
            int endIndex = locaTextLines.IndexOf(MainVM.Settings.LocaEnd);
            locaTextLines.Insert(endIndex, whatToAdd);
        }

        /// <summary>
        /// Appends LocaModel to loca text list (for editing)
        /// </summary>
        /// <param name="lm">The LocaModel to be added</param>
        private void InsertLocaIntoFile(LocaModel lm)
        {
            locaTextLines[lm.Index] = MainVM.Settings.Term + lm.Term;
            locaTextLines[lm.Index + 2] = MainVM.Settings.Desc + lm.Description;
            locaTextLines[lm.Index + 4] = MainVM.Settings.Lan + lm.English;
            locaTextLines[lm.Index + 5] = MainVM.Settings.Lan + lm.French;
            locaTextLines[lm.Index + 6] = MainVM.Settings.Lan + lm.Chinese;
            locaTextLines[lm.Index + 7] = MainVM.Settings.Lan + lm.Portuguese;
            locaTextLines[lm.Index + 8] = MainVM.Settings.Lan + lm.Russian;
            locaTextLines[lm.Index + 9] = MainVM.Settings.Lan + lm.Spanish;
        }

        /// <summary>
        /// Takes the complete loca file and uses ConvertTextToLoca to fill the locas lists
        /// </summary>
        private void ConvertLinesToLocas()
        {
            int startPos = locaTextLines.FindIndex(x => x.Contains(MainVM.Settings.LocaStart)) + 1;
            int endPos = locaTextLines.FindIndex(x => x.StartsWith(MainVM.Settings.LocaEnd));
            ObservableCollection<LocaModel> locas = new ObservableCollection<LocaModel>();
            if (startPos == null || startPos == 0 || endPos == null) return;
            for (int i = startPos; i < endPos; i += 18)
            {
                locas.Add(ConvertTextToLoca(i));
            }
            MainVM.instance.SetLocas(locas);
        }

        /// <summary>
        /// Takes line id and fills and returns a LocaModel
        /// </summary>
        /// <param name="startId">Id where loca starts</param>
        /// <returns></returns>
        private LocaModel ConvertTextToLoca(int startId)
        {
            LocaModel lm = new LocaModel();
            lm.Index        = startId;
            lm.Term         = Decode(locaTextLines[startId].Substring(MainVM.Settings.Term.Length));
            lm.Description  = Decode(locaTextLines[startId + 2].Substring(MainVM.Settings.Desc.Length));
            lm.English      = Decode(locaTextLines[startId + 4].Substring(MainVM.Settings.Lan.Length));
            lm.French       = Decode(locaTextLines[startId + 5].Substring(MainVM.Settings.Lan.Length));
            lm.Chinese      = Decode(locaTextLines[startId + 6].Substring(MainVM.Settings.Lan.Length));
            lm.Portuguese   = Decode(locaTextLines[startId + 7].Substring(MainVM.Settings.Lan.Length));
            lm.Russian      = Decode(locaTextLines[startId + 8].Substring(MainVM.Settings.Lan.Length));
            lm.Spanish      = Decode(locaTextLines[startId + 9].Substring(MainVM.Settings.Lan.Length));
            return lm;
        }

        private void RemoveDoubleLinesFromList()
        {
            int c = locaTextLines.Count - 1;
            int startPos = locaTextLines.FindIndex(x => x.Contains(MainVM.Settings.LocaStart)) + 1;
            List<int> linesToRemove = new List<int>();
            for (int i = startPos; i < c; i++)
            {
                int offset = 1;
                //Term
                if (locaTextLines[i].StartsWith(MainVM.Settings.Term))
                {
                    while (!locaTextLines[i + offset].Contains("TermType:"))
                    {
                        locaTextLines[i] += locaTextLines[i + offset];
                        linesToRemove.Add(i + offset);
                        offset++;
                        if (i + offset >= locaTextLines.Count) break;
                    }
                }
                //Description
                if (locaTextLines[i].StartsWith(MainVM.Settings.Desc))
                {
                    while (!locaTextLines[i + offset].Contains("Languages:"))
                    {
                        locaTextLines[i] += locaTextLines[i + offset];
                        linesToRemove.Add(i + offset);
                        offset++;
                        if (i + offset >= locaTextLines.Count) break;
                    }
                }
                //Languages
                if (locaTextLines[i].StartsWith(MainVM.Settings.Lan))
                {
                    while (!locaTextLines[i + offset].StartsWith(MainVM.Settings.Lan) 
                        && !locaTextLines[i + offset].Contains("Languages_Touch") 
                        && !locaTextLines[i + offset].Contains("Flags:"))
                    {
                        locaTextLines[i] += locaTextLines[i + offset];
                        linesToRemove.Add(i + offset);
                        offset++;
                        if (i + offset >= locaTextLines.Count) break;
                    }
                }
            }
            linesToRemove = linesToRemove.Distinct().ToList();

            //Remove the lines
            c = linesToRemove.Count;
            for (int i = c - 1; i >= 0; i--)
            {
                locaTextLines.RemoveAt(linesToRemove[i]);
            }

        }

        private string Decode(string str)
        {
            if(str.Contains(@"\u") || str.Contains(@"\x"))
            {
                string sub = str.Substring(1, str.Length - 2);
                sub = DecodeWhile(sub);
                return sub;
            }
            return str;
        }

        private string DecodeWhile(string str)
        {
            string result = "";
            int c = str.Length;
            for (int i = 0; i < c; i++)
            {
                string letter;
                string start = "";
                if (c > 5 && i < c - 2) start = str.Substring(i, 2);
                if (start.CompareTo("\\u") == 0 || start.CompareTo("\\x") == 0)
                {
                    int len = (str[i + 1] == 'u') ? 4 : 2;
                    letter = str.Substring(i + 2, len);
                    string rest = str.Substring(i);
                    int code = int.Parse(letter, NumberStyles.HexNumber);
                    letter = char.ConvertFromUtf32(code);
                    i += len + 1;
                }
                else
                {
                    letter = str[i].ToString();
                }
                result += letter;
            }
            return result;
        }
    }
}

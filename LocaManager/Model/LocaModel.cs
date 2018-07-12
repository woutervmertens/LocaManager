using System;

namespace LocaManager.Model
{
    public class LocaModel
    {
        private string term;
        private string description;
        private string english;
        private string french;
        private string chinese;
        private string portuguese;
        private string russian;
        private string spanish;
        private bool isNew;
        private bool isEdited;
        private int index;

        public string Term { get => term; set => term = value; }
        public string Description { get => description; set => description = value; }
        public string English { get => english; set => english = value; }
        public string French { get => french; set => french = value; }
        public string Chinese { get => chinese; set => chinese = value; }
        public string Portuguese { get => portuguese; set => portuguese = value; }
        public string Russian { get => russian; set => russian = value; }
        public string Spanish { get => spanish; set => spanish = value; }
        public bool IsNew { get => isNew; set => isNew = value; }
        public bool IsEdited { get => isEdited; set => isEdited = value; }
        public int Index { get => index; set => index = value; }

        public string Format(string format)
        {
            return Format(format, Term, Description, English, French, Chinese, Portuguese, Russian, Spanish);
        }
        public string Format(string format,string term,string desc,string en,string fr,string ch,string po,string ru,string es)
        {
            return String.Format(
                format,
                term, 
                desc,
                en,
                fr,
                ch,
                po,
                ru,
                es);
        }
    }
}

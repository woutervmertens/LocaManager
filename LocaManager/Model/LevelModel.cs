using System.Collections.Generic;

namespace LocaManager.Model
{
    public class LevelModel
    {
        public int ID;
        public List<string> LocaKeys;

        public LevelModel()
        {
            ID = 0;
            LocaKeys = new List<string>();
        }
    }
}

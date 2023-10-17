namespace MyAnimeListInfo
{
    public class Settings
    {
        private static string fileName = "Settings.xml";

        private string _userName = "";
        public string Username
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _userPassword = "";
        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        private int _scoreForRelated = 8;
        public int ScoreForRelated
        {
            get { return _scoreForRelated; }
            set { _scoreForRelated = value; }
        }

        public void Save()
        {
            XmlSerializeHelper.SerializeAndSave(fileName, this);
        }

        public static Settings Load()
        {
            try
            {
                return fileName.LoadAndDeserialize<Settings>();
            }
            catch
            {
                return new Settings();
            }
        }
    }
}
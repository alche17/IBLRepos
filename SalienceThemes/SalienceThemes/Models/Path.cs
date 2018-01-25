
namespace SalienceThemes.Models
{
    public class Path
    {
        protected static string _licensePath;
        protected static string _dataPath;

        public string LicensePath
        {
            get { return _licensePath; }
            set { _licensePath = value; }
        }

        public string DataPath
        {
            get { return _dataPath; }
            set { _dataPath = value; }
        }
    }
}

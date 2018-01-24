
namespace SalienceThemes.Models
{
    public class Theme
    {
        private string _name;
        private string _score;
        private string _type;
        private string _sentiment;
        private string _evidence;

        public Theme(string name, string score, string type, string sentiment, string evidence)
        {
            this._name = name;
            this._score = score;
            this._type = type;
            this._sentiment = sentiment;
            this._evidence = evidence;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Sentiment
        {
            get { return _sentiment; }
            set { _sentiment = value; }
        }
        public string Evidence
        {
            get { return _evidence; }
            set { _evidence = value; }
        }
    }
}

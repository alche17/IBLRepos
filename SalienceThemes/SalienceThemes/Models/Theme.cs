using System.Collections.ObjectModel;

namespace SalienceThemes.Models
{
    public class Themes : ObservableCollection<Theme>
    {
        public Themes()
        {
            loadData();
        }

        private void loadData()
        {
            // if want to create dummy data on start up
        }
    }

    public class Theme
    {
        private string _name;
        private float _score;
        private int _type;
        private float _sentiment;
        private int _evidence;

        public Theme(string name, float score, int type, float sentiment, int evidence)
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

        public float Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public float Sentiment
        {
            get { return _sentiment; }
            set { _sentiment = value; }
        }
        public int Evidence
        {
            get { return _evidence; }
            set { _evidence = value; }
        }
    }
}

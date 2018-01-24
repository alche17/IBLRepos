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
            this.Add(new Theme("Name 1", "Score 1", "Type 1", "Sentiment 1", "Evidence 1"));
            this.Add(new Theme("Name 2", "Score 2", "Type 2", "Sentiment 2", "Evidence 2"));
            this.Add(new Theme("Name 3", "Score 3", "Type 3", "Sentiment 3", "Evidence 3"));
            this.Add(new Theme("Name 4", "Score 4", "Type 4", "Sentiment 4", "Evidence 4"));
        }
    }

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

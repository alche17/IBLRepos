using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SalienceThemes.Models
{
    public class Themes : ObservableCollection<Theme>
    {
        public Themes()
        {
        }
    }

    public class Theme
    {

        public Theme(string name, float score, int type, float sentiment, int evidence)
        {
            Name = name;
            Score = score;
            Type = type;
            Sentiment = sentiment;
            Evidence = evidence;
        }

        public string Name { get; set; }

        public float Score { get; set; }

        public int Type { get; set; }

        public float Sentiment { get; set; }

        public int Evidence { get; set; }
    }
}

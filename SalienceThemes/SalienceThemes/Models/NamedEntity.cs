using System.Collections.ObjectModel;

namespace SalienceThemes.Models
{
    public class NamedEntities : ObservableCollection<NamedEntity>
    {
        public NamedEntities()
        {
        }
    }

    public class NamedEntity
    {

        public NamedEntity(string name, string type, float sentimentScore, int evidence, int count)
        {
            Name = name;
            Type = type;
            SentimentScore = sentimentScore;
            Evidence = evidence;
            Count = count;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public float SentimentScore { get; set; }

        public int Evidence { get; set; }

        public int Count { get; set; }
    }
}


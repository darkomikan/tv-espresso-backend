using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace tv_espresso.Models
{
    public class Video
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public required string Uri { get; set; }
        public required string Title { get; set; }
        public string? TranslatedTitle { get; set; }
        public int Year { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public string? EpisodeTitle { get; set; }
        public string? TranslatedEpisodeTitle { get; set; }
        public string? Uri4k { get; set; }
        public string? CoverUri { get; set; }
        public string? ThemeUri { get; set; }
        public string? SubtitleEngUri { get; set; }
        public string? SubtitleSrbUri { get; set; }
        public bool VideoFhd { get; set; }
        public string? Director { get; set; }
        public string[] Actors { get; set; } = [];
        public string[] Genres { get; set; } = [];
        [BsonIgnore]
        public List<List<Video>> Series { get; set; } = [];

        public override string ToString()
        {
            return Title + (Season > 0 ? " S" + Season + " E" + Episode : "");
        }
    }
}

using Newtonsoft.Json;

using System;
using System.Collections.Generic;

using VimeoVHX.Costumers;

namespace VimeoVHX.Video
{
    public class Video
    {
        [JsonProperty("_links")]
        public Links.Links Links { get; set; }
        [JsonProperty("_embedded")]
        public File[] Embedded { get; set; }
        [JsonProperty("id")]
        public int Ref { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Duration Duration { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public Tracks Tracks { get; set; }
        public Metadata Metadata { get; set; }
        [JsonIgnore]
        public List<Plan> Plans { get; set; }
        [JsonProperty("plans")]
        private string[] PlanList
        {
            get => getPlans();
        }
        public DateTime TimeAvailable { get; set; }
        public DateTime TimeUnavailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PlaysCount { get; set; }
        public int FinishesCount { get; set; }
        public int FilesCount { get; set; }
        private string[] getPlans()
        {
            string[] s = new string[] { };
            int i = 0;
            foreach (var p in Plans)
            {
                s[i] = Enum.GetName(typeof(Plan), p);
                i++;
            }
            return s;
        }

    }

    public class Metadata
    {
        public string Director { get; set; }
        public string[] Writers { get; set; }
        public int ReleaseYear { get; set; }
        public Thumbnail CustomIcons { get; set; }
        public string[] AdvertisingKeywords { get; set; }

    }
}

public class Tracks
{
    public string[] Subtitles { get; set; }
}

public class Thumbnail
{
    public string Small { get; set; }
    public string Medium { get; set; }
    public string Large { get; set; }
    public string Source { get; set; }
}

public class Duration
{
    public int Seconds { get; set; }
    public string Formatted { get; set; }
}

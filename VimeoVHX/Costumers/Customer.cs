using Newtonsoft.Json;
using System;

namespace VimeoVHX.Costumers
{
    public class Customer
    {
        [JsonProperty("id")]
        public int Ref { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Product { get; set; }
        [JsonIgnore]
        public Plan Plan { get; set; }
        [JsonProperty("plan")]
        public string Subscription { get => Enum.GetName(typeof(Plan), Plan); }
        public string Plataform { get; set; }
        public int DaysValid { get; set; }
        public bool SendEmail { get; set; }
        public bool IsRental { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        [JsonProperty("_links")]
        public Links.Links Links { get; set; }

        public void Validate()
        {
            if (this == null || Ref <= 0)
            {
                throw new Exception("Customer can't be null or Ref is invalid.");
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

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
        [JsonIgnore]
        public int DaysValid { get; set; }
        public string ExpiresIn { get => DaysValid + "-days"; set => DaysValid = Int32.Parse(Regex.Match(value, @"\d+").Value); }
        public bool SendEmail { get; set; }
        public bool IsRental { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        [JsonProperty("_links")]
        public Links.Links Links { get; set; }

        public void Validate()
        {
            if (this == null)
            {
                throw new Exception("Customer can't be null.");
            }
        }
    }
}

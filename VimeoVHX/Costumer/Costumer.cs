using System;

namespace VimeoVHX.Costumer
{
    public class Costumer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Product { get; set; }
        public Plan Plan { get; set; }
        public int DaysValid { get; set; }
        public bool SendEmail { get; set; }
        public bool IsRental { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

    }
}

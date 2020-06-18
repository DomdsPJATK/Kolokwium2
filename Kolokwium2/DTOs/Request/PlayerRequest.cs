using System;

namespace Kolokwium2.DTOs.Request
{
    public class PlayerRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthdate { get; set; }
        public int numOnShirt { get; set; }
        public string comment { get; set; }
    }
}
using System;

namespace CademeucarroApi.ViewModels
{
    public class SearchResult
    {
        public bool? IsStolen { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public string Plate { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime? StolenOn { get; set; }
    }
}
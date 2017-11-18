using System;

namespace cademeucarro_api.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
        public bool IsStolen { get; set; }
        public DateTime? StolenOn { get; set; }
    }
}
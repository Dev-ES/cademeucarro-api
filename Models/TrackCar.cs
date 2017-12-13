using System;

namespace CademeucarroApi.Models
{
    public class TrackCar
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public string Plate { get; set; }
        public int Lat { get; set; }
        public int Long { get; set; }
        public string CameraId { get; set; }
        public DateTime TrackedAt { get; set; }

        public Car Car { get; set; }
    }
}
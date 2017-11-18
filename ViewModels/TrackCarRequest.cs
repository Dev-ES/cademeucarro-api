namespace cademeucarro_api.ViewModels
{
    public class TrackCarRequest
    {
        public string Plate { get; set; }
        public string Camera { get; set; }
        public int Lat { get; set; }
        public int Long { get; set; }
    }
}
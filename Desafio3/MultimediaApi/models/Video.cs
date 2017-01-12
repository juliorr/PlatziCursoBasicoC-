namespace MultimediaApi.models
{
    public class Video : Media
    {
        public ushort Duration { get; set; }
        public FormatVideo Format { get; set; }
    }
}
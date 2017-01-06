namespace MultimediaApi.models
{
    public class Media : Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
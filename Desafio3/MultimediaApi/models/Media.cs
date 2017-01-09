namespace MultimediaApi.models
{
    public class Media
    {
        private int With;
        private int Height;
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        
        public void setSize(int With, int Height)
        {
            this.With = With;
            this.Height = Height;
        }
    }
}
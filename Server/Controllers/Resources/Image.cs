namespace Server.Controllers.Resources
{
    public class Image
    {
        public int? Id { get; set; }
        public string Url { get; set; }

        public static Image Empty { get => new Image { Id = 0, Url = "" }; }

    }
}

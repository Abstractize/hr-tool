namespace Server.Controllers.Resources
{
    public class Image
    {
        public int? Id { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// Returns an Empty Image
        /// </summary>
        public static Image Empty { get => new Image { Id = 0, Url = "" }; }

    }
}

using treinoCS;

namespace treinoCS.UserAutor
{
    public class userAutor
    {
        public userAutor() { }

        public string autorUserName { get; set; }
        public string autorUserBio { get; set; }
        public string autorUserEmail { get; set; }

        public userAutor(string autorUserName, string autorUserBio, string autorUserEmail)
        {
            this.autorUserName = autorUserName;
            this.autorUserBio = autorUserBio;
            this.autorUserEmail = autorUserEmail;
        }
    }

}
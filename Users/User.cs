using treinoCS;

namespace treinoCS.UserAluno
{
    public class User
    {
        public User() { }

        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userCPF { get; set; }

        public User(string userName, string userEmail, string userCPF)
        {
            this.userName = userName;
            this.userEmail = userEmail;
            this.userCPF = userCPF;
        }
    }

}
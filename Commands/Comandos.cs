using System.Text.RegularExpressions;
using treinoCS;
using treinoCS.Administrador;
using treinoCS.Data;
using treinoCS.UserAluno;
using treinoCS.UserAutor;
using treinoCS.UserLogin;

namespace treinoCS.Comandos
{
    class Commands
    {

        private List<userAutor> userAutor = new List<userAutor>();
        private List<User> userList = new List<User>();

        public void Help(string command)
        {
            Cadastro cad = new Cadastro();
            Login alunoLogin = new Login();
            Admin adm = new Admin();

            try
            {
                if (command.Equals("/cad"))
                {
                    Console.Clear();
                    cad.Whoami();
                }
                else if (command.StartsWith("/c"))
                {
                    Console.WriteLine("Você quis dizer \"/cad\"?\n-> [S/N]");
                    command = Console.ReadLine().ToLower();

                    if (command == "s")
                    {
                        Console.Clear();
                        cad.Whoami();
                    }
                    else if (command == ("n"))
                    {
                        Console.WriteLine("Tchau, tchau!");
                        Thread.Sleep(2000);
                        return;
                    }
                }
                if (command.Equals("/log"))
                {
                    Console.Clear();
                    alunoLogin.verifyLogin();
                }
                else if (command.StartsWith("/l"))
                {
                    Console.WriteLine("Você quis dizer \"/log\"?\n-> [S/N]");
                    command = Console.ReadLine().ToLower();
                    if (command == "s")
                    {
                        Console.Clear();
                        alunoLogin.verifyLogin();
                    }
                    else if (command == ("n"))
                    {
                        Console.WriteLine("Obrigado pela atenção! tchau, tchau!");
                        Thread.Sleep(2000);
                        return;
                    }
                }
                if (command.Equals("/admin"))
                {
                    Console.Clear();
                    adm.AdminLogin();
                }
                else if (command.StartsWith("/a"))
                {
                    Console.WriteLine("Você quis dizer \"/users\"?\n-> [S/N]");
                    command = Console.ReadLine().ToLower();
                    if (command == "s")
                    {
                        Console.Clear();
                        adm.AdminLogin();

                    }
                    else if (command == ("n"))
                    {
                        Console.WriteLine("Obrigado pela atenção! tchau, tchau!");
                        Thread.Sleep(2000);
                        return;
                    }
                }

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Invalid operation!");
                throw new Exception($"{e.Message}");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("An error has occurred");
                throw new Exception($"Error: {e.Message}");
            }
        }

        public void UserCadastro()
        {
            Cadastro cad = new Cadastro();
            User user = new User();

            try
            {
                while (string.IsNullOrWhiteSpace(user.userName) || string.IsNullOrWhiteSpace(user.userEmail) || string.IsNullOrWhiteSpace(user.userCPF) || user.userCPF.Length != 11)
                {
                    Console.WriteLine("PÁGINA CADASTRO DE ALUNO");
                    Console.Write("-> Nome: ");
                    user.userName = Console.ReadLine();
                    Console.Write("-> Email: ");
                    user.userEmail = Console.ReadLine();
                    Console.Write("-> CPF (Sem pontos e trações): ");
                    user.userCPF = (Console.ReadLine());
                }

                using (var context = new DataContext())
                {
                    var Aluno = (from aluno in context.Aluno
                                 where aluno.Nome == user.userName
                                 where aluno.Email == user.userEmail
                                 where aluno.CPF == user.userCPF
                                 select aluno).FirstOrDefault();

                    if (Aluno?.Nome == user.userName && Aluno.Email == user.userEmail && Aluno.CPF == user.userCPF)
                    {
                        Console.WriteLine("USUÁRIO JÁ CADASTRADO!");
                    }
                    Console.Clear();

                    cad.UserConfirmarCadastro(user.userName, user.userEmail, user.userCPF);
                }

                //FAZER TRATAMENTO DOS DADOS DE CADASTRO

            }
            catch (System.ArgumentNullException e)
            {
                throw new Exception($"Argumento vazio.\nMotivo do erro: {e.Message}");
            }
            catch (System.NullReferenceException e)
            {
                throw new Exception($"Resultado Nulo.\nMotivo do erro: {e.Message}");
            }
            catch (System.FormatException e)
            {
                throw new Exception($"Formato incorreto, por favor tentar novamente.\nMotivo do erro: {e.Message}");
            }
            catch (System.Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
        public string cpfConvert(string cpf)
        {
            //return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
            string response = cpf.Trim();
            if (response.Length == 11)
            {
                response = response.Substring(0, response.Length - 5) + "*****";
                // response = response.Insert(1, "*");
                response = response.Insert(9, "-");
                response = response.Insert(6, ".");
                response = response.Insert(3, ".");
            }
            return response;
        }
    }

}
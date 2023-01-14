using System;
using Microsoft.Data.SqlClient;
using treinoCS.cursoAluno;
using treinoCS.Cursos;
using treinoCS.Data;
using treinoCS.Models;
using treinoCS.UserLogin;

namespace treinoCS
{
    class Program
    {
        private static void Main(string[] args)
        {
            Cadastro start = new Cadastro();
            start.Menu();
            // AlunoCURSO l = new AlunoCURSO();
            // l.ConfirmarDados(27, 2);
        }
    }
}


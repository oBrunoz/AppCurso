using Microsoft.Data.SqlClient;
using treinoCS.Data;
using treinoCS.UserLogin;

namespace treinoCS.Cursos;

public class CursoALL
{

    private int opID;
    private int cursoMin { get; set; }

    public void Curso()
    {
        var t = new DataContext();

        Console.WriteLine("Tabela abaixo de todas categorias:\n");

        using (var context = new DataContext())
        {
            var curso = context.Categorias;

            foreach (var c in curso)
            {
                Console.WriteLine($"\n -------------------- \n");
                Console.WriteLine($"ID: {c.Id}");
                Console.WriteLine($"TÍTULO: {c.Titulo}");
                Console.WriteLine($"DESCRIÇÃO: {c.Descricao}");
                Console.WriteLine($"\n -------------------- \n");
            }
        }

        do
        {
            Console.WriteLine("Agora, escolha uma categoria e digite o ID (número) correspondente abaixo.");
            opID = Convert.ToInt32(Console.ReadLine());

            try
            {
                var a = (from categorias in t.Categorias
                         where opID == categorias.Id
                         select categorias).FirstOrDefault();

                Console.Clear();
                CompleteCurso(a.Id, a.Titulo, a.Descricao);
            }
            catch (SystemException e)
            {
                throw new Exception($"{e}");
            }

        } while (int.IsNegative(opID));
    }

    public void CompleteCurso(int id, string title, string desc)
    {
        Login log = new Login();

        Console.WriteLine("Complete as informações abaixo:\n");
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"TÍTULO: {title}");
        Console.WriteLine($"DESCRIÇÃO: {desc}\n");
        Console.Write("DURAÇÃO EM MINUTOS: ");
        cursoMin = Convert.ToInt32(Console.ReadLine());

        try
        {
            using (var context = new DataContext())
            {
                var curso = new Curso
                {
                    Titulo = title,
                    Descricao = desc,
                    DuracaoEmMinutos = cursoMin,
                    DataCriacao = DateTime.Now,
                    DataUltimaAtualizacao = DateTime.Now,
                    AutorId = 1,
                    CategoriaId = id
                };

                context.Cursos.Add(curso);
                context.SaveChanges();
                Console.WriteLine("Dados adicionados com sucesso!");
            }
        }
        catch (SqlException e)
        {
            throw new Exception("Não foi possível conectar-se ao Banco de Dados! " + e);
        }
        catch (System.Exception e)
        {
            Console.WriteLine($"{e}");
        }


    }
}
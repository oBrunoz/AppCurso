using treinoCS.Data;

namespace treinoCS.cursoAluno;

public class AlunoCURSO
{
    private int optionID;

    public void ConfirmarDados(string name, int id)
    {
        try
        {
            using (var context = new DataContext())
            {
                Console.WriteLine("\nCatálogo de cursos:\n");

                var cursos = context.Cursos;

                foreach (var a in cursos)
                {
                    Console.WriteLine($"ID: {a.Id}\t");
                    Console.WriteLine($"TÍTULO: {a.Titulo}\t");
                    Console.WriteLine($"DESCRIÇÃO: {a.Descricao}\t");
                    Console.WriteLine($"DURAÇÃO DE CURSO: {a.DuracaoEmMinutos}\t");
                    Console.WriteLine($"\n -------------------- \n");
                }

                Console.WriteLine($"{name}, escolha um curso digitando o ID correspondente.\n");
                Console.Write("-> ");
                optionID = Convert.ToInt32(Console.ReadLine());

                var c = (from curso in context.Cursos
                         where optionID == curso.Id
                         select curso).FirstOrDefault();

                var cadCurso = new AlunoCurso { CoursoId = c.Id, AlunoId = 38,Progresso = 0, DataInicio = DateTime.Now, UltimaDataAtualizacao = DateTime.Now };
                context.AlunoCurso.Add(cadCurso);
                context.SaveChanges();

                Console.WriteLine("Cadastrado com sucesso!");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine($"{e}");
        }
    }

    private static int id = 1;
    static int generateId()
    {
        return id++;
    }
}
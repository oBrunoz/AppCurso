using Microsoft.Data.SqlClient;
using treinoCS.Cursos;
using treinoCS.Data;

namespace treinoCS.Categorias;

public class GeralCategoria
{

    private CursoALL c = new CursoALL();
    private string cursoPage;
    private string titleCat;
    private string descCat;

    public void Categoria(string name, int id)
    {
        Console.WriteLine($"{name}, descreva as informações da categoria.\n");
        Console.WriteLine("-> Título da categoria: ");
        titleCat = Console.ReadLine().ToUpper();
        Console.WriteLine("-> Descrição da categoria: ");
        descCat = Console.ReadLine().ToUpper();

        //Desenvolver condições

        using (var context = new DataContext())
        {
            // var cat = (from categoria in context.Categorias
            //            where categoria.Titulo == titleCat
            //            where categoria.Descricao == descCat
            //            select categoria).FirstOrDefault();

            try
            {
                var cat = new Categoria { Id = id, Titulo = titleCat, Descricao = descCat };
                context.Categorias.Add(cat);
                context.SaveChanges();

                Thread.Sleep(3000);
                Console.Clear();

                if (cat != null)
                {
                    Console.WriteLine("Categoria adicionada com sucesso!");
                    Console.WriteLine("Deseja cadastrar um curso?\n1 - SIM\n2 - NÃO\n");
                    Console.Write("-> ");
                    cursoPage = Console.ReadLine();

                    if(cursoPage == "1")
                    {
                        Console.Clear();
                        c.Curso();
                    }
                }
                else
                {
                    Console.WriteLine("Não foi possível adicionar a categoria no banco de dados! Por favor, tente novamente.");
                }

            }
            catch (SqlException e)
            {
                throw new Exception("Não foi possível conectar-se ao Banco de Dados! " + e);
            }
        }
    }
}

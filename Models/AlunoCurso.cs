using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace treinoCS
{

    public class AlunoCurso
    {
        [Key]
        public int CoursoId { get; set; }
        public int AlunoId { get; set; }
        public int Progresso { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime UltimaDataAtualizacao { get; set; }
    }
}
namespace SistemaBiblioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public int LibvroId { get; set; }
        public Livro? Livro { get; set; }

        public int EstudanteId { get; set; }
        public Estudante? Estudante { get; set; }
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime DataDevolucao { get; set; } = DateTime.Now.AddDays(15);
        public string StatusLivro { get; set; } = "Disponible";
    }
}

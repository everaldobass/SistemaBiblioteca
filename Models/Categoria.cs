namespace SistemaBiblioteca.Models
{
    // Classe que representa uma categoria de livro
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public DateTime DataCriacao{ get; set; } = DateTime.Now;
    }
}

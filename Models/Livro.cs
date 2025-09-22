namespace SistemaBiblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public DateTime? DataPublicacao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}

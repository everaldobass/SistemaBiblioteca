using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Data
{

    // Conexao com o banco de dados
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }

}

using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Data
{

    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();
            await CheckCategoriasAsync();
            await CheckUsersAsync("tecnologia", "tecnologia@gmail.com", "Tecno.2025", "Administrador");
        }

        private async Task<Usuario> CheckUsersAsync(string nome, string email, string password, string perfil)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuarioExistente != null)
            {
                return usuarioExistente;
            }

            Usuario usuario = new()
            {
                Nome = nome,
                Email = email,
                Perfil = perfil,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        private async Task CheckCategoriasAsync()
        {
            if (!_context.Categorias.Any())
            {
                _context.Categorias.AddRange(
                    new Categoria { Nome = "Ciencia" },
                    new Categoria { Nome = "Programação" },
                    new Categoria { Nome = "Inteligencia artificial" }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}

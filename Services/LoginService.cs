using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Data;

// Service para autenticação de login
namespace SistemaBiblioteca.Services
{
    //
    public class LoginService
    {
        // Injeção de dependência do DataContext
        private readonly DataContext _context;

        // Construtor
        public LoginService(DataContext context)
        {
            _context = context;
        }

        // Propriedade para verificar se o usuário está autenticado
        public bool IsAuthenticated { get; private set; } = false;

        // Método para realizar o login
        public async Task<bool> LoginAsync(string email, string password)
        {
            // Busca o usuário pelo email
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            // Verifica se o usuário existe e se a senha não é nula ou vazia
            if (user == null || string.IsNullOrEmpty(user.Password))
            {
                IsAuthenticated = false;
                return IsAuthenticated;
            }

            // Verifica a senha usando BCrypt
            IsAuthenticated = BCrypt.Net.BCrypt.Verify(password, user.Password);
            return IsAuthenticated;
        }

    }

}
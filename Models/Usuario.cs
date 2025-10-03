namespace SistemaBiblioteca.Models
{
    // Classe que representa um usuário do sistema
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //public string Perfil { get; set; } = "Usuario";
        public string Perfil { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}

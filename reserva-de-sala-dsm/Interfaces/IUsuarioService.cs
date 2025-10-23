using reserva_de_sala_dsm.Models;

namespace reserva_de_sala_dsm.Interfaces
{
    public interface IUsuarioService
    {
        //Contratos
        //Busca todos os usuários
        Task<IEnumerable<Usuario>>GetAllAsync();
        //Busca o usuário por ID
        Task<Usuario> GetByIdAsync(long id);
        //Cria um novo usuário
        Task<Usuario> CreateAsync(Usuario usuario);
        //Atualiza um usuário
        Task UpdateAsync(Usuario usuario);
        //Deleta um usuário
        Task DeleteAsync(long id);
    }
}

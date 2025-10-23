using reserva_de_sala_dsm.Models;

namespace reserva_de_sala_dsm.Interfaces
{
    public interface ISalaService
    {
        Task <IEnumerable<Sala>> GetAllSalasAsync();
        Task<Sala> GetSalaByIdAsync(long id);
        Task<Sala> SaveSalaAsync(Sala sala);
        Task DeleteSalasAsync(long id);
    }
}

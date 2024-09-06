using Arhitektura.Models;
using System.Collections.Generic;

namespace Arhitektura.IRepositories
{
    public interface ITuristickaAgencijaRepository
    {
        List<TuristickaAgencija> GetAll();
        TuristickaAgencija GetById(string id);
        void Create(TuristickaAgencija turistickaAgencija);
        void Update(string id, TuristickaAgencija turistickaAgencija);
        void Delete(string id);
    }
}

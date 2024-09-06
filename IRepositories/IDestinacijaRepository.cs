using Arhitektura.Models;
using System.Collections.Generic;

namespace Arhitektura.IRepositories
{
    public interface IDestinacijaRepository
    {
        List<Destinacija> GetAll();
        Destinacija GetById(string id);
        void Create(Destinacija destinacija);
        void Update(string id, Destinacija destinacija);
        void Delete(string id);
    }
}

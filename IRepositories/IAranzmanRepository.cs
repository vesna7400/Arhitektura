using Arhitektura.Models;
using System.Collections.Generic;

namespace Arhitektura.IRepositories
{
    public interface IAranzmanRepository
    {
        List<Aranzman> GetAll();
        Aranzman GetById(string id);
        void Create(Aranzman aranzman);
        void Update(string id, Aranzman aranzman);
        void Delete(string id);
    }
}

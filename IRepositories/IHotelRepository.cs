using Arhitektura.Models;
using System.Collections.Generic;

namespace Arhitektura.IRepositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetAll();
        Hotel GetById(string id);
        void Create(Hotel hotel);
        void Update(string id, Hotel hotel);
        void Delete(string id);
    }
}

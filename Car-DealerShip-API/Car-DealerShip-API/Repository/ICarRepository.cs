using Car_DealerShip_API.Model;

namespace Car_DealerShip_API.Repository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> Get();
        Task<Car> Get(int id);
        Task<Car> Create(Car car);
        Task Update(Car Car);
        Task Delete(int id);
        Task<Car> SearchByName(string name);
    }
}

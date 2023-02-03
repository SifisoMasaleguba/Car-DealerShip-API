using Car_DealerShip_API.Data;
using Car_DealerShip_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Car_DealerShip_API.Repository
{
    public class CarRepository : ICarRepository
    {

        private readonly CarDbContext context;

        public CarRepository(CarDbContext context)
        {
            this.context = context;
        }

        public async Task<Car> Create(Car car)
        {
            context.Cars.Add(car);
            await context.SaveChangesAsync();
            return car;
        }

        public async Task Delete(int id)
        {
            var carToDelete = await context.Cars.FindAsync(id);           
                context.Cars.Remove(carToDelete);
                await context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Car>> Get()
        {
            return await context.Cars.ToListAsync();
        }

        public async Task<Car> Get(int id)
        {
            return await context.Cars.FindAsync(id);
        }

        public async Task<Car> SearchByName(string name)
        {
            return await context.Cars.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task Update(Car car)
        {
            context.Entry(car).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}

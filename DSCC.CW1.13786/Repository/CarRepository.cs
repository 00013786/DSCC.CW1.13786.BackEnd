using DSCC.CW1._13786.DBContexts;
using DSCC.CW1._13786.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._13786.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarContext _dbContext;
        public CarRepository(CarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCar(int CarId)
        {
            var Car = _dbContext.Cars.Find(CarId);
            _dbContext.Cars.Remove(Car);
            Save();
        }


        public Car GetCarById(int CarId)
        {
            var prod = _dbContext.Cars.Find(CarId);
            _dbContext.Entry(prod).Reference(s => s.Category).Load();
            return prod;
        }

        public IEnumerable<Car> GetCars()
        {
            return _dbContext.Cars.Include(s => s.Category).ToList();
        }

        public void InsertCar(Car Car)
        {
            _dbContext.Add(Car);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCar(Car Car)
        {
            _dbContext.Entry(Car).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

    }
}

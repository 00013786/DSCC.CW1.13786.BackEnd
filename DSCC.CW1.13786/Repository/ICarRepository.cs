using DSCC.CW1._13786.Model;

namespace DSCC.CW1._13786.Repository
{
    public interface ICarRepository
    {
        void InsertCar(Car Car);
        void UpdateCar(Car Car);
        void DeleteCar(int CarId);
        Car GetCarById(int Id);
        IEnumerable<Car> GetCars();
    }
}

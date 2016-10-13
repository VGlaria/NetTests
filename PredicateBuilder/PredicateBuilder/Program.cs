using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> lstCar = new List<Car>();

            lstCar.Add(new Car() { brand = "BMW", model = "X5", colour = "RED" });
            lstCar.Add(new Car() { brand = "BMW", model = "X3", colour = "BLACK" });
            lstCar.Add(new Car() { brand = "BMW", model = "X1", colour = "BLUE" });
            lstCar.Add(new Car() { brand = "SEAT", model = "TOLEDO", colour = "RED" });

            var predicate = PredicateBuilder.True<Car>();
            predicate = predicate.And(a => a.brand.Equals("BMW"));

            var innerPredicate = PredicateBuilder.False<Car>();
            innerPredicate = innerPredicate.Or(a => a.colour == "RED" || a.colour == "BLACK");

            predicate = predicate.And(innerPredicate);



            var answers = lstCar.AsQueryable<Car>().Where(predicate).ToList();

            foreach (var s in answers)
                Console.WriteLine(String.Format("{0}  {1}  {2}", s.brand, s.model, s.colour));

            Console.ReadLine();

        }
    }
}

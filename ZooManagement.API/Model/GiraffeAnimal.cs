using ZooManagement.API.Constants;

namespace ZooManagement.API.Model
{
    public class GiraffeAnimal : HerbivoreAnimal
    {
        public override bool Feed(FoodStorage foodStorage) // Redundant
        {
            return base.Feed(foodStorage);
        }
    }
}

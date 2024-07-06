using ZooManagement.API.Constants;
using ZooManagement.API.Model;

namespace ZooManagement.API.Model
{
    public class CarnivoreAnimal : Animal
    {
        public override bool Feed(FoodStorage foodStorage)
        {
            if (ConsumeFood(foodStorage, FoodConstants.StandardFoodRation * 3)) //TODO: this logic is duplicated, should be moved into the base class
            {
                ResetHunger();
                return true;
            }

            return false;
        }
    }
}
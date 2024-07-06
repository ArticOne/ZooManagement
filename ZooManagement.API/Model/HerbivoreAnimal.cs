using ZooManagement.API.Constants;
using ZooManagement.API.Model;

namespace ZooManagement.API.Model
{
    public class HerbivoreAnimal : Animal
    {
        public override bool Feed(FoodStorage foodStorage)
        {
            if (ConsumeFood(foodStorage, (int)Math.Ceiling(FoodConstants.StandardFoodRation * 3f))) //TODO: this logic is duplicated, should be moved into the base class
            {
                ResetHunger();
                return true;
            }

            return false;
        }
    }
}
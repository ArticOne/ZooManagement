using ZooManagement.API.Constants;

namespace ZooManagement.API.Model
{
    public abstract class Animal
    {
        /*
         *  Properties that are common to all animals would go here
         *
         */

        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeceased { get; set; }

        private int hunger;
        public int Hunger
        {
            get => hunger;
            set
            {
                if (value is > 100 or < 100)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"Valid range for property {nameof(Hunger)} is between 0 and 100.");
                hunger = value;
            }
        }

        public virtual bool Feed(FoodStorage foodStorage)
        {
            if (ConsumeFood(foodStorage, FoodConstants.StandardFoodRation))
            {
                ResetHunger();
                return true;
            }

            return false;
        }

        protected static bool ConsumeFood(FoodStorage foodStorage, int ration)
        {
            try
            {
                foodStorage.Inventory -= ration;
                return true;
            }
            catch (Exception ex) //TODO: swallowed exception, not really useful
            {
                return false;
            }
        }

        protected void ResetHunger()
        {
            Hunger = 0;
        }
    }
}

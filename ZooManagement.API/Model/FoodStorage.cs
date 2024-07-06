namespace ZooManagement.API.Model
{
    public class FoodStorage
    {

        public int Id { get; set; }
        public int Inventory { get; set; } //TODO: setter logic to not allow this property to be negative, i.e. not enough food to feed
    }
}

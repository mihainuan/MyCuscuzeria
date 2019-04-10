namespace MyCuscuzeria.Domain.Arguments.Drink
{
    public class AddDrinkResponse
    {
        public int DrinkId { get; set; }

        public AddDrinkResponse(int drinkId)
        {
            drinkId = DrinkId;
        }
    }
}
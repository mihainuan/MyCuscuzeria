namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IDrinkRepository
    {
        Drink GetDrink(int drinkid);

        void SaveDrink(Drink drink);
    }
}
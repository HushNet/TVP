namespace DefaultNamespace
{
    public class BurgerBuilder : IBurgerBuilder
    {
        public Burger burger;

        public BurgerBuilder()
        {
            burger = new Burger();
        }
        public void WithCheese()
        {
            burger.ingredients.Add("Cheese");
        }

        public void WithBacon()
        {
            burger.ingredients.Add("Bacon");
        }

        public void WithOnion()
        {
            burger.ingredients.Add("Onion");
        }

        public void WithKetchup()
        {
            burger.ingredients.Add("Ketchup");

        }

        public void WithMayonise()
        {
            burger.ingredients.Add("Mayonise");

        }

        public void WithChickenCutlet()
        {
            burger.ingredients.Add("ChickenCutlet");

        }

        public void WithCabbage()
        {
            burger.ingredients.Add("Cabbage");
        }

        public void WithBeefCutlet()
        {
            burger.ingredients.Add("BeefCutlet");
        }

        public Burger GetBurger()
        {
            return burger;
        }
    }
}
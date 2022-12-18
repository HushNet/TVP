namespace DefaultNamespace
{
    public interface IBurgerBuilder
    {
        public void WithCheese();
        public void WithBacon();
        public void WithOnion();
        public void WithKetchup();
        public void WithMayonise();
        public void WithChickenCutlet();
        public void WithCabbage();
        public void WithBeefCutlet();

        public Burger GetBurger();
    }
}
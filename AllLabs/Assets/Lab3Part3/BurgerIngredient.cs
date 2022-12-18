using UnityEngine;

namespace DefaultNamespace
{
    public class BurgerIngredient
    {
        public string name;
        public GameObject prefab;

        public BurgerIngredient(string name, GameObject prefab)
        {
            this.name = name;
            this.prefab = prefab;
        }
    }
}
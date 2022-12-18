using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


namespace DefaultNamespace
{
    public class BurgerKing : MonoBehaviour
    {
        public List<string> names;
        public List<GameObject> prefabs;
        public GridLayoutGroup grid;

        private List<GameObject> spawnedObjects;
        private List<BurgerIngredient> burgerIngredients;
        private Burger burger;
        void Start()
        {
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            
            burgerBuilder.WithCheese();
            burgerBuilder.WithBacon();
            burgerBuilder.WithMayonise();
            burgerBuilder.WithCabbage();
            burgerBuilder.WithOnion();
            burgerBuilder.WithBeefCutlet();
            burgerBuilder.WithChickenCutlet();
            burgerBuilder.WithKetchup();

            burger = burgerBuilder.GetBurger();

            burgerIngredients = new List<BurgerIngredient>();
            spawnedObjects = new List<GameObject>();
            for (int i = 0; i < prefabs.Count; i++)
            {
                burgerIngredients.Add(new BurgerIngredient(names[i], prefabs[i]));
            }
        }
        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                for (int i = 0; i < spawnedObjects.Count; i++)
                {
                    Destroy(spawnedObjects[i].gameObject);
                }
                for (int i = 0; i < burger.ingredients.Count; i++)
                {
                    var newIng = Instantiate(burgerIngredients.First(x => x.name == burger.ingredients[i]).prefab, new Vector3(0,0,0), Quaternion.identity);
                    newIng.transform.SetParent(grid.transform);
                    spawnedObjects.Add(newIng);
                }
            }
        }
    }
}
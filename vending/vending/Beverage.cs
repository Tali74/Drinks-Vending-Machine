using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending {
    internal abstract class Beverage {
        private string _name;
        private double _price;

        public string Name { get { return _name; } protected set { _name = value; } }
        public double Price { get { return _price; } protected set { _price = value; } }

        public Beverage(string name, double price) {
            Name = name;
            Price = price;
            //_counterDrinks++;
        }
        public string Prepare(VendingMachine machine) {
            return String.Format("{0}\n{1}\n{2}",
                AddIngredients(machine),
                HotWater(),
                Stirring());

        }

        protected abstract string AddIngredients(VendingMachine machine);
        protected abstract string HotWater();
        public abstract string Stirring();

        protected string UseMyIngredients(ref int ingredient, string name, int value = 1) {
            if (ingredient - value < 0)
                throw new BeverageOutOfIngredientsException();
            ingredient -= value;
            return $"use {value} {name}";
        }

        public abstract string Restock();

        public override string ToString() {
            return $"{Name} : {Price:c}";
        }

        public override bool Equals(object obj) {
            var bev = obj as Beverage;
            if (bev == null)
                throw new ArgumentNullException();
            return bev.Name == Name;
        }
    }
}

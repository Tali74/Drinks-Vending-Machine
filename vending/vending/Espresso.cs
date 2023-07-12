using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending {
    internal class Espresso : Beverage {

        int _coffeeBeans = 10;
        public Espresso(string name = "Espresso", double price = 13) : base(name, price) {

        }

        protected override string AddIngredients(VendingMachine machine) {
            return String.Format("{0}\n{1}\n{2}",
                machine.AddCups(),
                machine.AddSugar(),
                UseMyIngredients(ref _coffeeBeans, "Coffee Beans"));
        }

        protected override string HotWater() {
            return "add 60 ml of hot water";
        }
        public override string Stirring() {
            return "no need to stir";
        }

        public override string Restock() {
            _coffeeBeans = 10;
            return "CoffeeBeans restock to 10";
        }
    }
}

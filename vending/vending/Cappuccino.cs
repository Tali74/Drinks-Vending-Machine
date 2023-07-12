using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending {
    internal class Cappuccino : Beverage {

        int _coffee = 10;
        public Cappuccino(string name = "Cappuccino", double price = 15) : base(name, price) {

        }

        public override string Stirring() {
            return "stir 3 times clockwise";
        }

        protected override string AddIngredients(VendingMachine machine) {
            return String.Format("{0}\n{1}\n{2}\n{3}",
                machine.AddCups(),
                machine.AddSugar(),
                machine.AddMilk(),
                UseMyIngredients(ref _coffee, "Coffee"));
        }

        protected override string HotWater() {
            return "add 100 ml of hot water";
        }

        public override string Restock() {
            _coffee = 10;
            return "Coffee restock to 10";
        }
    }
}

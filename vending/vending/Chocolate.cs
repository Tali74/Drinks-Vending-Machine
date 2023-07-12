using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending {
    internal class Chocolate : Beverage {

        int _chocolate = 10;
        public Chocolate(string name = "Chocolate", double price = 15) : base(name, price) {

        }


        public override string Stirring() {
            return "stir 8 times Counterclockwise";
        }

        protected override string AddIngredients(VendingMachine machine) {
            return String.Format("{0}\n{1}\n{2}\n{3}",
               machine.AddCups(),
               machine.AddSugar(),
               machine.AddMilk(),
               UseMyIngredients(ref _chocolate, "Chocolate"));
        }

        protected override string HotWater() {
            return "add 100 ml of hot water";
        }

        public override string Restock() {
            _chocolate = 10;
            return "Chocolate restock to 10";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending {
    internal class Tea : Beverage {

        int _teaBag = 10;
        public Tea(string name = "Tea", double price = 10) : base(name, price) {

        }



        public override string Stirring() {
            return "stir 1 time";
        }

        protected override string AddIngredients(VendingMachine machine) {
            return String.Format("{0}\n{1}\n{2}",
                           machine.AddCups(),
                           machine.AddSugar(),
                           UseMyIngredients(ref _teaBag, "Tea Bag"));
        }

        protected override string HotWater() {
            return "add 150 ml of hot water";
        }
        public override string Restock() {
            _teaBag = 10;
            return "Tea Bag restock to 10";
        }
    }
}

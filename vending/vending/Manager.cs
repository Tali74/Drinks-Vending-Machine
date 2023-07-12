using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending {
    internal class Manager {
        public VendingMachine Machine { get; private set; }


        public Manager() {

            Machine = new VendingMachine();
            Machine.AddBeverage(new Tea());
            Machine.AddBeverage(new Cappuccino());
            Machine.AddBeverage(new Espresso());
            Machine.AddBeverage(new Chocolate());
        }

        public string Preper(string name, double money) {

            string s = $"{Machine[name].ToString()} \n";
            try {
                s += $"{Machine.Pay(name, money)} \n{Machine.Preper(name)}";
                return s;
            }
            catch (BeverageOutOfIngredientsException e) {
                s += e.Message;
                return s;
            }
            catch (NotEnoughMoneyException e) {
                s += e.Message;
                return s;
            }
        }
    }
}

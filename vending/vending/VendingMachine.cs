using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace vending {
    internal class VendingMachine {
        private Beverage[] _beverages;

        private int _numDrinks;

        int _cups = 5;
        int _sugar = 5;
        int _milk = 25;

        public int CountBev { get => _numDrinks; }

        public VendingMachine(int length = 10) {
            _beverages = new Beverage[length];
        }

        public Beverage this[string name] {
            get {
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentNullException("name");
                for (int i = 0 ; i < _numDrinks ; i++) {
                    if (_beverages[i] == null)
                        continue;
                    if (_beverages[i].Name.ToLower() == name.ToLower())
                        return _beverages[i];
                }
                throw new ArgumentException("there is not such beverage");
            }
            private set {
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentNullException("name");
                for (int i = 0 ; i < _numDrinks ; i++) {
                    if (_beverages[i] == null)
                        continue;
                    if (_beverages[i].Name.ToLower() == name.ToLower())
                        _beverages[i] = value;
                }
                throw new ArgumentException("there is not such beverage");
            }
        }

        public string Preper(string name) {
            return this[name].Prepare(this);
        }

        public string Pay(string name, double money) {
            if (this[name].Price > money)
                throw new NotEnoughMoneyException("there is not enough money.");

            return $"You have successfully paid\nTake your change: {money - this[name].Price:c}";
        }

        public void AddBeverage(Beverage beverages) {
            if (beverages == null)
                throw new ArgumentNullException();
            if (_numDrinks >= _beverages.Length)
                throw new ArgumentOutOfRangeException();
            _beverages[_numDrinks++] = beverages;
        }
        public void RemoveBeverage(string name) {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            this[name] = null;
        }

        public string Restock() {

            StringBuilder s = new StringBuilder();
            _cups = _milk = _sugar = 10;
            for (int i = 0 ; i < _numDrinks ; i++) {
                s.AppendLine(_beverages[i].Restock());
            }
            s.AppendLine("cups, milk and sugar also restock to 10");
            return s.ToString();
        }

        public string AddCups() {
            if (_cups <= 0)
                throw new BeverageOutOfIngredientsException();
            else
                _cups--;
            return "Adding cup";
        }

        public string AddSugar() {
            if (_sugar <= 0)
                throw new BeverageOutOfIngredientsException();
            else
                _sugar--;
            return "Adding sugar ";
        }
        public string AddMilk() {
            if (_milk <= 0)
                throw new BeverageOutOfIngredientsException();
            else
                _milk--;
            return "Adding milk ";
        }

        public override string ToString() {
            StringBuilder s = new StringBuilder();
            for (int i = 0 ; i < _numDrinks ; i++) {
                s.AppendLine(_beverages[i].ToString());
            }
            return s.ToString();
        }

        //public string AddWater()
        //{
        //    if (_water <= 0)
        //        throw new ArgumentException("There is no water");
        //    else
        //        _water--;
        //    return "Adding hot water\n ";
        //}
        //public string AddCoffee() 
        //{
        //    if (_coffee <= 0)
        //        throw new ArgumentException("There is no coffee");
        //    else
        //        _coffee--; 
        //    return "Adding Coffee\n ";
        //}
        //public string AddTeaBag()
        //{
        //    if (_teaBag <= 0)
        //        throw new ArgumentException("There is no tea");
        //    else
        //        _teaBag--;
        //    return "Adding tea\n ";
        //}
        //public string AddChocolate()
        //{
        //    if (_chocolate <= 0)
        //        throw new ArgumentException("There is no chocolate");
        //    else
        //        _chocolate--;
        //    return "Adding chocolate\n ";
        //}
    }
}

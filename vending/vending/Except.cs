using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending {
    internal class BeverageOutOfIngredientsException : Exception {
        public BeverageOutOfIngredientsException() { }
        public BeverageOutOfIngredientsException(string message) : base(message) { }

        public override string Message => "there is no more ingredients for this beverage";
    }

    internal class NotEnoughMoneyException : Exception {
        public NotEnoughMoneyException() { }
        public NotEnoughMoneyException(string message) : base(message) { }
    }


}

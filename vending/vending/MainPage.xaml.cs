using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace vending {

    public sealed partial class MainPage : Page {
        //Tea _tea;
        //Cappuccino _cappuccino;
        //Espresso _espresso;
        //Chocolate _chocolate;
        //private bool _isTea = false;
        //private bool _iscappuccino = false;
        //private bool _isespresso = false;
        //private bool _ischocolate = false;
        ////private VendingMachine _machine;
        //List<BitmapImage> _images;
        Manager manager;


        public MainPage() {
            this.InitializeComponent();
            manager = new Manager();
            //_machine = new VendingMachine();
            //_images = new List<BitmapImage>();/
        }

        private void Btn_Tapped(object sender, TappedRoutedEventArgs e) {
            Button btn = sender as Button;
            string name = btn.Name;
            double money;
            if (!double.TryParse(payTbx.Text, out money) || money < 0) {
                showChoice.Text = $"please enter {manager.Machine[name].Price:c}";
                payTbx.Text = "";
                return;
            }
            payTbx.Text = "";
            showChoice.Text = manager.Preper(name, money);


        }

        private void RestockBtn_Tapped(object sender, TappedRoutedEventArgs e) {
            showChoice.Text = manager.Machine.Restock();
        }





#if a
        private void Tapeed_Tea(object sender, TappedRoutedEventArgs e) {
            _tea = new Tea("Tea", 10);
            showChoice.Text = _tea.ToString();
            _isTea = true;
            _iscappuccino = false;
            _ischocolate = false;
            _isespresso = false;
        }

        private void Tapped_Cappuccino(object sender, TappedRoutedEventArgs e) {
            _cappuccino = new Cappuccino("Cappuccino", 15);
            showChoice.Text = _cappuccino.ToString();
            _iscappuccino = true;
            _isTea = false;
            _ischocolate = false;
            _isespresso = false;
        }

        private void Tapped_Pay(object sender, TappedRoutedEventArgs e) {
            if (_isTea == true) {
                showChoice.Text = _tea.Prepare(_machine);
            }
            if (_iscappuccino == true) {
                showChoice.Text = _cappuccino.Prepare(_machine);
            }
            if (_isespresso == true) {
                showChoice.Text = _espresso.Prepare(_machine);
            }
            if (_ischocolate == true) {
                showChoice.Text = _chocolate.Prepare(_machine);
            }

        }

        private void Tapped_Espresso(object sender, TappedRoutedEventArgs e) {
            _espresso = new Espresso("Espresso", 13);
            showChoice.Text = _espresso.ToString();
            _isespresso = true;
            _isTea = false;
            _iscappuccino = false;
            _ischocolate = false;
        }

        private void Tapped_Chocolate(object sender, TappedRoutedEventArgs e) {
            _chocolate = new Chocolate("Chocolate", 15);
            showChoice.Text = _chocolate.ToString();
            _ischocolate = true;
            _isTea = false;
            _iscappuccino = false;
            _isespresso = false;
        } 
#endif
    }
}

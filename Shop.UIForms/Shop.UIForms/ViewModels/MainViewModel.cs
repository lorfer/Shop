
using System;
using System.Runtime.CompilerServices;

namespace Shop.UIForms.ViewModels
{
   public class MainViewModel
    {
        private static MainViewModel SingletonInstance { get; set; }
        public LoginViewModel Login { get; set; }
        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            SingletonInstance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (SingletonInstance == null)
            {
                return new MainViewModel();
            }

            return SingletonInstance;
        }

    }
}

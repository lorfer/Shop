namespace Shop.UIForms.ViewModels
{
    using Shop.Common;
    using Shop.Common.Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
   public class ProductsViewModel : BaseViewModel
    {
        //Atributo privado
        private ObservableCollection<Product> products;
        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        //For Look the change of property
        public ObservableCollection<Product> Products {
            get {return this.products;  }
            set{ this.SetValue(ref this.products, value);}
        }
        public ApiService apiservices { get;  set; }

        public ProductsViewModel()
        {
            this.apiservices = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            IsRefreshing = true;
            var responce = await this.apiservices.GetListAsync<Product>(
                "https://shopweblorfe.azurewebsites.net",
                "/api",
                "/Products"
                ) ;

            IsRefreshing = false;
            if (!responce.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                     responce.Message,
                    "Aceptar"
                    ) ;
                return;
            }

            //This make a cass the result to list product
            var misProductos = (List<Product>)responce.Result;
            this.Products = new ObservableCollection<Product>(misProductos);
        }
    }
}

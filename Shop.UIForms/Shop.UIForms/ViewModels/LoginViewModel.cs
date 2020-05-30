

namespace Shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Passworld { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
            this.Email = "fernandogarciaolivo@gmail.com";
            this.Passworld = "123456";
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduce un Email valido",
                    "Aceptar"

                    );
            }

            if (string.IsNullOrEmpty(this.Passworld))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduce un Password valido",
                    "Aceptar"

                    );
            }

            if (!this.Email.Equals("fernandogarciaolivo@gmail.com") || !this.Passworld.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El Usuario o Contraseña es invalido",
                    "Aceptar"

                    );
            }

            await Application.Current.MainPage.DisplayAlert(
                "OK",
                "Iniciaste sesion!!!! Fuck!!!",
                "Aceptar");

             
            }
        }
 }


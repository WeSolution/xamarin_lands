namespace deleteme.ViewModels
{
    using deleteme.Views;
    // Nugget package mvvm light libs icono de una plumita
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        /* Si se requiere que se actualice una propiedad modificada en el backend
         * en la view, entonces se tiene que usar la interface 
         * INotifyPropertyChanged, y se tiene que declarar atributos privados por 
         * cada propiedad que se van a actualizar.
         * Se crea una clase base para que se pueda hacer reutilización de código
         */

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        /* 
         * Mostly methods in mobile are async so you must change 
         * your common methods into async methods.
         */
        public async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    ,"You must enter your mail"
                    ,"Acept"
                );
                return;
            }

            if(string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    ,"You must enter your password"
                    ,"Acept"
                );
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if(this.Email != "mail@mail.com" || this.password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await  Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "Your email and password are incorrect"
                    , "Acept"
                );
                this.password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.password = string.Empty;

            // Para hacer la navegación se necesita primero instanciar el view
            // model de la siguiente page, posterior se debe apilar el page view
            // a la aplicación mediante navigation.pushasync(aquí va tu page view)
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

        }
        #endregion

    }
}

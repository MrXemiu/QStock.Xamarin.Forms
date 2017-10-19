using System.Threading.Tasks;
using System.Windows.Input;
using IdentityModel.Client;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using QStock.Xamarin.Core.Models.App;
using QStock.Xamarin.Core.ServiceInterfaces;

namespace QStock.Xamarin.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel<LoginViewModel.Initializer, TokenResponse>
    {
        #region Private Fields

        private readonly IAuthenticationService _authenticationService;

        private readonly LoginModel _loginModel;

        private readonly IDialogService _userDialogs;

        private readonly IMvxMessenger _messenger;

        private bool _isLoading;

        private MvxCommand _signInCommmand;
        private ICommand _forgotPwCommand;

        #endregion Private Fields

        #region Public Properties

        public string Company
        {
            get => _loginModel.Company;

            set
            {
                _loginModel.Company = value;

                RaisePropertyChanged(() => Company);
                _signInCommmand.RaiseCanExecuteChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public string Password
        {
            get => _loginModel.Password;

            set
            {
                _loginModel.Password = value;

                RaisePropertyChanged(() => Password);
                _signInCommmand.RaiseCanExecuteChanged();
            }
        }

        public bool SignInCanExecute => !string.IsNullOrWhiteSpace(Company)
                                        && !string.IsNullOrWhiteSpace(Username)
                                        && !string.IsNullOrWhiteSpace(Password);

        public ICommand SignInCommand
        {
            get
            {
                return _signInCommmand ?? (_signInCommmand =
                           new MvxCommand(async () => await DoSignIn(), () => SignInCanExecute));
            }
        }

        public ICommand ForgotPwCommand
        {
            get
            {
                return _forgotPwCommand ?? (_forgotPwCommand = new MvxCommand(async () =>
                {
                    Company = "QStockMobile";
                    Username = "gabe";
                    Password = "password";
                    await DoSignIn();
                }));
            }
        }

        public string Username
        {
            get => _loginModel.Username;

            set
            {
                _loginModel.Username = value;

                RaisePropertyChanged(() => Username);
                _signInCommmand.RaiseCanExecuteChanged();
            }
        }

        #endregion Public Properties

        #region Public Constructors

        public LoginViewModel(IAuthenticationService authenticationService, IDialogService userDialogs, IMvxMessenger messenger) : base(messenger)
        {
            _authenticationService = authenticationService;
            _userDialogs = userDialogs;
            _messenger = messenger;

            _loginModel = new LoginModel();
        }

        #endregion Public Constructors

        #region Private Methods

        private async Task DoSignIn()
        {
            try
            {
                IsLoading = true;
                await _authenticationService.TrySignIn(_loginModel);
                ShowViewModel<HomeViewModel>();
            }
            catch (System.Exception ex)
            {
                _userDialogs.Alert($"Authentication Failed", $"{ex.Message}", "Try Again", null);
            }
            finally
            {
                IsLoading = false;
            }
        }

        #endregion Private Methods

        #region Public Methods

        public override void Reset()
        {
            Company = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }

        /// <inheritdoc />
        public override async void Prepare(Initializer parameter)
        {
            await Task.Run(() =>
            {
                Company = parameter.Company;
                Username = parameter.Username;
            });
        }

        #endregion Public Methods

        #region Public Classes

        public class Initializer
        {
            #region Public Properties

            public string Company { get; set; }

            public string Username { get; set; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}
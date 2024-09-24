namespace ec.com.naturisa.mobile.feedcontrol.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            BindingContext = loginViewModel;

            this.SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (mainGrid != null)
                {
                    if (Width > Height)
                    {
                        mainGrid.RowDefinitions = new RowDefinitionCollection
                        {
                            new RowDefinition { Height = new GridLength(256) },
                            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                            new RowDefinition { Height = GridLength.Auto }
                        };
                    }
                    else
                    {
                        mainGrid.RowDefinitions.Clear();

                        mainGrid.RowDefinitions = new RowDefinitionCollection
                        {
                            new RowDefinition { Height = new GridLength(0.30, GridUnitType.Star) },
                            new RowDefinition { Height = new GridLength(0.40, GridUnitType.Star) },
                            new RowDefinition { Height = GridLength.Auto }
                        };
                    }
                }
            }
            catch (ObjectDisposedException) { }
        }

        ~LoginView()
        {
            this.SizeChanged -= OnSizeChanged;
        }

        private void CheckAndFocusEmptyFields()
        {
            var viewModel = BindingContext as LoginViewModel;

            if (viewModel == null)
                return;

            if (string.IsNullOrWhiteSpace(viewModel.UserName))
            {
                UsernameEntry.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(viewModel.Password))
            {
                PasswordEntry.Focus();
                return;
            }
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            CheckAndFocusEmptyFields();

            var viewModel = BindingContext as LoginViewModel;
            if (
                viewModel != null
                && !string.IsNullOrWhiteSpace(viewModel.UserName)
                && !string.IsNullOrWhiteSpace(viewModel.Password)
            )
            {
                viewModel.LoginCommand.Execute(null);
            }
        }
    }
}

using Caliburn.Micro;

namespace Caliburn4Fun.Demo.ViewModels
{
    public class MainPageViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private int _dialogCounter = 1;

        public MainPageViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public int DialogCounter
        {
            get { return _dialogCounter; }
            set
            {
                if (value == _dialogCounter) return;
                _dialogCounter = value;
                NotifyOfPropertyChange(() => DialogCounter);
            }
        }

        public void ShowDialog()
        {
            var dialogViewModel = new DialogViewModel
            {
                Title = "About",
                Text = "It's a modal dialog. It blocks user interface.\r\n\r\nTap 'ok' to increase the counter."
            };
            dialogViewModel.Deactivated += (sender, args) =>
            {
                if (dialogViewModel.Result == DialogResult.Ok)
                {
                    DialogCounter++;
                }
            };
            _windowManager.ShowDialog(dialogViewModel);
        }

    }
}
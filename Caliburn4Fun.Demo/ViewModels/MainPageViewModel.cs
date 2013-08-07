using Caliburn.Micro;

namespace Caliburn4Fun.Demo.ViewModels
{
    public class MainPageViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private int _dialogCounter = 1;
        private int _popupCounter = 1;

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

        public int PopupCounter
        {
            get { return _popupCounter; }
            set
            {
                if (value == _popupCounter) return;
                _popupCounter = value;
                NotifyOfPropertyChange(() => PopupCounter);
            }
        }

        public void ShowDialog()
        {
            var dialogViewModel = new DialogViewModel
            {
                Title = "Dialog",
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

        public void ShowPopup()
        {
            var dialogViewModel = new DialogViewModel
            {
                Title = "Popup",
                Text = "It's a popup. You can tap on dummy buttons below.\r\n\r\nTap 'ok' to increase the counter."
            };
            dialogViewModel.Deactivated += (sender, args) =>
            {
                if (dialogViewModel.Result == DialogResult.Ok)
                {
                    PopupCounter++;
                }
            };
            _windowManager.ShowPopup(dialogViewModel);
        }
    }
}
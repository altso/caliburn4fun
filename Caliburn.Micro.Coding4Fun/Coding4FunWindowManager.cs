using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Caliburn.Micro.Coding4Fun
{
    public class Coding4FunWindowManager : IWindowManager
    {
        public void ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null)
        {
            ShowDialog(rootModel, new Coding4FunDialog
            {
                Context = context,
                RootModel = rootModel,
                Overlay = (Brush)Application.Current.Resources["PhoneSemitransparentBrush"]
            });
        }

        public void ShowPopup(object rootModel, object context = null, IDictionary<string, object> settings = null)
        {
            ShowDialog(rootModel, new Coding4FunDialog
            {
                Context = context,
                RootModel = rootModel
            });
        }

        private static void ShowDialog(object rootModel, Coding4FunDialog dialog)
        {
            var activate = rootModel as IActivate;
            if (activate != null)
            {
                activate.Activate();
            }

            var deactivate = rootModel as IDeactivate;
            if (deactivate != null)
            {
                dialog.Completed += (sender, args) => deactivate.Deactivate(true);
            }

            dialog.Show();
        }
    }
}
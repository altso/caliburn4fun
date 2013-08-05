using System.Collections.Generic;

namespace Caliburn.Micro.Coding4Fun
{
    public class Coding4FunWindowManager : IWindowManager
    {
        public void ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null)
        {
            var dialog = new Coding4FunDialog
            {
                Context = context,
                RootModel = rootModel
            };

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

        public void ShowPopup(object rootModel, object context = null, IDictionary<string, object> settings = null)
        {
            ShowDialog(rootModel, context, settings);
        }
    }
}
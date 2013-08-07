using System.Windows;
using System.Windows.Media;
using Coding4Fun.Toolkit.Controls;

namespace Caliburn.Micro.Coding4Fun
{
    public class Coding4FunDialog : PopUp<object, PopUpResult>
    {
        public static readonly DependencyProperty RootModelProperty =
            DependencyProperty.Register("RootModel", typeof(object), typeof(Coding4FunDialog), new PropertyMetadata(null));

        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(object), typeof(Coding4FunDialog), new PropertyMetadata(null));

        public object RootModel
        {
            get { return GetValue(RootModelProperty); }
            set { SetValue(RootModelProperty, value); }
        }

        public object Context
        {
            get { return GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }

        public Coding4FunDialog()
        {
            DefaultStyleKey = typeof(Coding4FunDialog);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var host = (Coding4FunDialogHost)GetTemplateChild("ViewContainer");
            var view = ViewLocator.LocateForModel(RootModel, host, Context);
            host.Content = view;
            host.SetValue(View.IsGeneratedProperty, true);

            ViewModelBinder.Bind(RootModel, host, null);
            Action.SetTarget(host, RootModel);

            host.Closed += (sender, args) => OnCompleted(new PopUpEventArgs<object, PopUpResult>
            {
                Result = PopUpResult.Ok
            });
        }
    }
}
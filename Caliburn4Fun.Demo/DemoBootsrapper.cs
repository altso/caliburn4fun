using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Caliburn.Micro.Coding4Fun;
using Caliburn4Fun.Demo.ViewModels;

namespace Caliburn4Fun.Demo
{
    public class DemoBootsrapper : PhoneBootstrapper
    {
        private PhoneContainer _container;

        protected override void Configure()
        {
            _container = new PhoneContainer();

            // register Coding4FunWindowManager BEFORE calling RegisterPhoneServices
            _container.Singleton<IWindowManager, Coding4FunWindowManager>();

            _container.RegisterPhoneServices(RootFrame);

            _container.PerRequest<MainPageViewModel>();
            _container.PerRequest<DialogViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

    }
}
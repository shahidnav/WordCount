using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using WordCount.Main.Providers;
using Module = Autofac.Module;

namespace WordCount.Main
{
    public class MainAutofacModule : Module
    {
        private const string AppSettingForfilePathMissingExceptionMessageFormat = "Please add a value for {0} in the App.config";
        private const string AppSettingKeyForfilePath = "completeFilePathToTextFile";
        private readonly string _fullPathForTextfile;

        public MainAutofacModule()
        {
            _fullPathForTextfile = ConfigurationManager.AppSettings.Get(AppSettingKeyForfilePath);
            if (string.IsNullOrEmpty(_fullPathForTextfile))
            {
                throw new ConfigurationErrorsException(string.Format(
                    AppSettingForfilePathMissingExceptionMessageFormat, AppSettingKeyForfilePath));
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces();

            builder.RegisterType<TextFileProvider>()
                .WithParameter(new NamedParameter("fullPathForTextfile", _fullPathForTextfile))
                .WithParameter(new NamedParameter("encoding", Encoding.UTF8))
                .AsImplementedInterfaces();
        }
    }
}

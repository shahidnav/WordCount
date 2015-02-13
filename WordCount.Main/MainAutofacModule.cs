using System.Configuration;
using System.Reflection;
using Autofac;
using WordCount.Main.Providers;
using Module = Autofac.Module;

namespace WordCount.Main
{
    public class MainAutofacModule : Module
    {
        private const string AppSettingMissingExceptionMessageFormat = "Please add a value for {0} in the App.config.";
        private const string AppSettingBufferSizeNanMessageFormat = "The value for textFileProviderStreamBufferSize {0} in the App.config is not a valid number.";
        private const string AppSettingKeyForfilePath = "completeFilePathToTextFile";
        private const string AppSettingKeyForBufferSize = "textFileProviderStreamBufferSize";
        
        private readonly string _fullPathForTextfile;
        private readonly int _bufferSize;

        public MainAutofacModule()
        {
            _fullPathForTextfile = ConfigurationManager.AppSettings.Get(AppSettingKeyForfilePath);
            if (string.IsNullOrEmpty(_fullPathForTextfile))
            {
                throw new ConfigurationErrorsException(string.Format(
                    AppSettingMissingExceptionMessageFormat, AppSettingKeyForfilePath));
            }

            var bufferSizeAsText = ConfigurationManager.AppSettings.Get(AppSettingKeyForBufferSize);
            if (string.IsNullOrEmpty(bufferSizeAsText))
            {
                throw new ConfigurationErrorsException(string.Format(
                    AppSettingMissingExceptionMessageFormat, AppSettingKeyForBufferSize));
            }

            if (!int.TryParse(bufferSizeAsText, out _bufferSize))
            {
                throw new ConfigurationErrorsException(string.Format(
                    AppSettingBufferSizeNanMessageFormat, bufferSizeAsText));
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces();

            builder.RegisterType<TextFileProvider>()
                .WithParameter(new NamedParameter("fullPathForTextfile", _fullPathForTextfile))
                .WithParameter(new NamedParameter("bufferSize", _bufferSize))
                .AsImplementedInterfaces();
        }
    }
}

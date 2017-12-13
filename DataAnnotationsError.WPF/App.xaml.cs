using System;
using System.Windows;
using DataAnnotationsError.Lib;

namespace DataAnnotationsError
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            AppDomain.CurrentDomain.UnhandledException += ErrorHandler.HandleUnhandledException;
        }

        public App()
        {
            ErrorHandler.OnErrorShown += HandleFatalError;
            DispatcherUnhandledException += ErrorHandler.HandleDispatcherUnhandledException;

            var validated = new ValidatedClass();
            validated.Email = "notanemail";
            var valid = validated.Validate();
            var qualifier = valid ? "" : "not ";
            MessageBox.Show($"{validated.Email} is {qualifier}a valid email address", "Validation Successful",
                MessageBoxButton.OK);
            Shutdown();
        }

        private void HandleFatalError()
        {
            Shutdown();
        }
    }
}

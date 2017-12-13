using System;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace DataAnnotationsError
{
    public class ErrorHandler
    {
        public static event Action OnErrorShown;

        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            DisplayError((Exception)args.ExceptionObject);
        }

        public static void HandleDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            DisplayError(args.Exception);
        }

        public static void DisplayError(Exception exception)
        {
            Console.WriteLine(exception);
            StringBuilder sb = new StringBuilder();
            sb.Append(exception.Message);
            sb.Append(Environment.NewLine);
            sb.Append(exception.StackTrace);
            while (exception.InnerException != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("Inner --> " + exception.InnerException.GetType().Name + ":");
                sb.Append(Environment.NewLine);
                sb.Append(exception.InnerException.Message);
                sb.Append(Environment.NewLine);
                sb.Append(exception.InnerException.StackTrace);
                exception = exception.InnerException;
            }
            DisplayError(sb.ToString(), exception.GetType().Name);
        }

        public static void DisplayError(string error, string caption, MessageBoxImage messageBoxImage = MessageBoxImage.Error)
        {
            MessageBox.Show(error, caption, MessageBoxButton.OK, messageBoxImage);
            OnErrorShown?.Invoke();
        }
    }
}
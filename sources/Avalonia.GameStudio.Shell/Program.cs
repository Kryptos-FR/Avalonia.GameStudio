using System;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading;

using Avalonia.Logging.Serilog;

namespace Avalonia.GameStudio.Shell
{
    /// <summary>
    /// Entry point.
    /// </summary>
    internal sealed class Program
    {
        private static int _terminatedState;

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
        }

        [SecurityCritical]
        [HandleProcessCorruptedStateExceptions]
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
            {
                HandleException(e.ExceptionObject as Exception, 1);
            }
            // TODO: log to file?
        }


        private static void HandleException(Exception? exception, int location)
        {
            if (exception is null) return;

            // prevent multiple crash reports
            if (Interlocked.CompareExchange(ref _terminatedState, 1, 0) == 1) return;

            // FIXME: implement crash reporter
        }
    }
}

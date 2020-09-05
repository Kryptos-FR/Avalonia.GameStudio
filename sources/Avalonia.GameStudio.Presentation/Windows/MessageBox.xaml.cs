using System.Threading.Tasks;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.GameStudio.Presentation.Windows
{
    public enum MessageBoxButtons
    {
        Ok,
        OkCancel,
        YesNo,
        YesNoCancel
    }

    public enum MessageBoxResult
    {
        Ok,
        Cancel,
        Yes,
        No
    }

    /// <summary>
    /// View for the message box.
    /// </summary>
    public class MessageBox : Window
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MessageBox"/>.
        /// </summary>
        public MessageBox()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public static Task<MessageBoxResult> ShowAsync(Window? owner, string text, string title, MessageBoxButtons buttons, WindowStartupLocation startupLocation = WindowStartupLocation.CenterOwner)
        {
            var messageBox = new MessageBox()
            {
                Title = title,
                WindowStartupLocation = owner is not null ? startupLocation : WindowStartupLocation.CenterScreen,
            };
            messageBox.FindControl<TextBlock>("Text").Text = text;
            var buttonPanel = messageBox.FindControl<StackPanel>("Buttons");

            var result = MessageBoxResult.Ok;

            void AddButton(string caption, MessageBoxResult r, bool def = false)
            {
                var button = new Button { Content = caption };
                button.Click += (_, __) =>
                {
                    result = r;
                    messageBox.Close();
                };
                buttonPanel.Children.Add(button);
                if (def)
                    result = r;
            }

            if (buttons == MessageBoxButtons.Ok || buttons == MessageBoxButtons.OkCancel)
                AddButton("Ok", MessageBoxResult.Ok, true);
            if (buttons == MessageBoxButtons.YesNo || buttons == MessageBoxButtons.YesNoCancel)
            {
                AddButton("Yes", MessageBoxResult.Yes);
                AddButton("No", MessageBoxResult.No, true);
            }
            if (buttons == MessageBoxButtons.OkCancel || buttons == MessageBoxButtons.YesNoCancel)
                AddButton("Cancel", MessageBoxResult.Cancel, true);

            var tcs = new TaskCompletionSource<MessageBoxResult>();
            messageBox.Closed += (_,_) => tcs.TrySetResult(result);

            if (owner != null) messageBox.ShowDialog(owner);
            else messageBox.Show();
            
            return tcs.Task;
        }
    }
}

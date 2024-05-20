using PhotinoNET;
using System.Drawing;
using System.Windows.Forms;

namespace PtfsAi
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Window title declared here for visibility
            string windowTitle = "PTFS Attitude Indicator by qaezz.dev";

            // Creating a new PhotinoWindow instance with the fluent API
            var window = new PhotinoWindow()
                .SetTitle(windowTitle)
                // Resize to a percentage of the main monitor work area
                .SetUseOsDefaultSize(false)
                .SetSize(new Size(300, 300))
                // Center window in the middle of the screen
                .Center()
                .SetTopMost(true)
                // Users can resize windows by default.
                // Let's make this one fixed instead.
                .SetResizable(false)
                .SetContextMenuEnabled(false)
                // Most event handlers can be registered after the
                // PhotinoWindow was instantiated by calling a registration 
                // method like the following RegisterWebMessageReceivedHandler.
                // This could be added in the PhotinoWindowOptions if preferred.
                .RegisterWebMessageReceivedHandler((object sender, string message) =>
                {
                    var window = (PhotinoWindow)sender;

                    // The message argument is coming in from sendMessage.
                    // "window.external.sendMessage(message: string)"
                    string response = "{\"msg\": \"none\", \"data\": {} }";
                    Console.WriteLine(response);

                    if (message == "getMousePos")
                    {
                        Screen screen = Screen.PrimaryScreen;

                        Rectangle workingArea = screen.WorkingArea;

                        Point centerPoint = new(
                            workingArea.Left + workingArea.Width / 2,
                            workingArea.Top + workingArea.Height / 2
                        );

                        Point p = new(
                            Cursor.Position.X - centerPoint.X,
                            Cursor.Position.Y - centerPoint.Y
                        );

                        response = "{\"msg\": \"mousePos\", \"data\": { \"x\":" + p.X + ", \"y\": " + p.Y + " } }";
                    }

                    // Send a message back the to JavaScript event handler.
                    // "window.external.receiveMessage(callback: Function)"
                    window.SendWebMessage(response);
                })
                .Load("wwwroot/index.html"); // Can be used with relative path strings or "new URI()" instance to load a website.

            window.WaitForClose(); // Starts the application event loop
        }
    }
}

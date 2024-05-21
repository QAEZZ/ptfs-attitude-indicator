using PhotinoNET;
using PtfsAi.Helpers;

namespace PtfsAi
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            string windowTitle = "PTFS Attitude Indicator by qaezz.dev";

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            var window = new PhotinoWindow()
                .SetTitle(windowTitle)
                .SetUseOsDefaultSize(false)
                .SetSize(new Size(300, 300))
                .Center()
                .SetTopMost(true)
                .SetResizable(false)
                .SetContextMenuEnabled(false)
                .RegisterWebMessageReceivedHandler((object sender, string message) =>
                {
                    var window = (PhotinoWindow)sender;

                    string response = "{\"msg\": \"none\", \"data\": {} }";

                    if (message == "GetMousePos")
                    {
                        Point p = Mouse.GetMousePosAccordingToCenter();
                        response = BuildResponse.Build("MousePos", $"{{\"x\": {p.X}, \"y\": {p.Y} }}");
                    } else if (message == "ChangeSetting") {
                        Console.WriteLine("ChangeSetting");
                    } else {
                        return;
                    }

                    window.SendWebMessage(response);
                })
                .Load("wwwroot/index.html");
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).


            window.WaitForClose();
        }
    }
}

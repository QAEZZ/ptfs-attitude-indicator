using System;
using System.Drawing;
using System.Windows.Forms;

namespace PtfsAi.Helpers;

public static class Mouse
{
    public static Point GetMousePosAccordingToCenter()
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
        
        return p;
    }
}
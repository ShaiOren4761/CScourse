using System.Windows.Forms;

namespace Assignment2_207667916
{
    public class GameButton : Button
    {
        // Button, but with x,y coordinates for game grid.
        private int x, y;

        public GameButton(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
        }
        public int X { get { return x; } set { this.x = value; } }
        public int Y { get { return y; } set { this.y = value; } }
    }
}

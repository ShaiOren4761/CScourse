using System.Windows.Forms;

namespace Assignment1_207667916
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
        public int X { get { return x; } } // No need for set. Fixed x,y value after constructor.
        public int Y { get { return y; } }
    }
}

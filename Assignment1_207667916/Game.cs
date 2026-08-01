using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment1_207667916
{
    public partial class Game : Form
    {
        private GameButton[,] Game_Matrix = new GameButton[4,4];
        private int count = 1;
        Random r = new Random();

        public Game()
        {
            // Adjust window size to game
            this.Height = 400;
            this.Width = 350;
            this.Text = "Fifteen";
            InitializeGame();
        }

        private void InitializeGame()
        {
            CreateBoard();
            RandomizePositions();
            CreateRestartGameMenu();
        }

        private void CreateRestartGameMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem newGameItem = new ToolStripMenuItem("New Game");
            newGameItem.Click += NewGameClick_Handler;
            menuStrip.Items.Add(newGameItem);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private GameButton CreateGameButton(int x, int y)
        {
            GameButton b = new GameButton(x,y);
            b.Height = 70;
            b.Width = 70;
            b.Text = count.ToString();
            count++;
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            b.Click += GameClick_Handler;
            return b;
        }

        private GameButton CreateGameButton_Invisible(int x, int y)
        {
            GameButton b = new GameButton(x,y);
            b.Height = 70;
            b.Width = 70;
            b.Visible = false;
            b.Name = "Empty";
            b.Click += GameClick_Handler; // This control may become visible after a tile moves into this position.
            return b;
        }

        private void CreateBoard()
        {
            int x = 10, y = 50;
            for (int i = 0; i < Game_Matrix.GetLength(0); i++)
            {

                for (int j = 0; j < Game_Matrix.GetLength(1); j++)
                {
                    if (i == 3 && j == 3) Game_Matrix[i, j] = CreateGameButton_Invisible(i, j);
                    else Game_Matrix[i, j] = CreateGameButton(i, j);

                    Game_Matrix[i, j].Location = new Point(x + 20, y);
                    this.Controls.Add(Game_Matrix[i, j]);

                    x += Game_Matrix[i, j].Width;
                }
                x = 10;
                y += Game_Matrix[i, 0].Height;
            }
        }

        private void DestroyBoard()
        {
            count = 1;
            foreach(GameButton g in Game_Matrix)
            {
                g.Dispose();
            }
        }

        private void RandomizePositions()
        {
            int x, y;
            for (int i = 0; i < Game_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Game_Matrix.GetLength(1) && !(i == 3 && j == 3); j++)
                {
                    do
                    {
                        x = r.Next(4);
                        y = r.Next(4);
                    } while (x == 3 && y == 3); //Ignore bottom right
                    Swap(Game_Matrix[i, j], Game_Matrix[x, y]);
                }
            }
        }

        private void GameClick_Handler(object sender, EventArgs e)
        {
            GameButton b = sender as GameButton;

            if (b == null) return;

            int x, y;
            if (IsAdjacentToEmpty(b, out x, out y))
            {
                Swap(Game_Matrix[b.X, b.Y], Game_Matrix[x, y]);
                CheckWinCondition();
            }
        }

        private void NewGameClick_Handler(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Swap(GameButton b1, GameButton b2)
        {
            bool b1Visible = !(b2.Name == "Empty");
            bool b2Visible = !(b1.Name == "Empty");

            // Copy b1's properties into temp
            String tempText = b1.Text;
            Font tempFont = b1.Font;
            Color tempBackColor = b1.BackColor;
            String tempName = b1.Name;

            // Copy b2's properties into b1
            b1.Text = b2.Text;
            b1.Font = b2.Font;
            b1.BackColor = b2.BackColor;
            b1.Name = b2.Name;

            // Copy b1's properties into b2 (via temp)
            b2.Text = tempText;
            b2.Font = tempFont;
            b2.BackColor = tempBackColor;
            b2.Name = tempName;

            // Set visibility
            b1.Visible = b1Visible;
            b2.Visible = b2Visible;
            // Explicit check and not just copy, because of Form default visibility set to "false" until form itself is visible, which makes all button invisible at the start.
        }

        private Boolean IsAdjacentToEmpty(GameButton b, out int x_empty, out int y_empty)
        {
            int x = b.X, y = b.Y;
            if (IsEmpty(x, y + 1))
            {
                x_empty = x;
                y_empty = y + 1;
                return true;
            }
            else if (IsEmpty(x, y - 1))
            {
                x_empty = x;
                y_empty = y - 1;
                return true;
            }
            else if (IsEmpty(x - 1, y))
            {
                x_empty = x - 1;
                y_empty = y;
                return true;
            }
            else if (IsEmpty(x + 1, y))
            {
                x_empty = x + 1;
                y_empty = y;
                return true;
            }
            x_empty = -1; y_empty = -1;
            return false;
        }

        private Boolean IsEmpty(int x, int y)
        {
            if (x >= 0 && y >= 0 && x <= Game_Matrix.GetUpperBound(0) && y <= Game_Matrix.GetUpperBound(1)) // check x,y bounds
            {
                if (Game_Matrix[x, y].Name == "Empty") return true; // check button name
            }
            return false;
        }

        private void CheckWinCondition()
        {
            // Basic required check by assignment
            if (Game_Matrix[0, 0].Text == "1" && Game_Matrix[0, 1].Text == "2") Win();                 
        }

        private void Win()
        {
            DialogResult d = MessageBox.Show("New Game?", "You win!", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes) RestartGame();
            else this.Close();
        }

        private void RestartGame()
        {
            DestroyBoard();
            CreateBoard();
            RandomizePositions();
        }
    }
}

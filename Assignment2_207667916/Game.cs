namespace Assignment2_207667916
{
    public partial class Game : Form
    {
        private GameButton[,] Game_Matrix = new GameButton[4, 4];
        private int count = 1;
        Random r = new Random();
        private GameButton[] To_Switch = new GameButton[2];
        private int[] Locations = new int[4]; // b1 --> (x1,y1) - b2 --> (x2,y2)
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        public Game()
        {
            // Adjust window size to game
            this.Height = 400;
            this.Width = 350;
            this.Text = "Fifteen";
            CreateTimer();
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
            GameButton b = new GameButton(x, y);
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
            GameButton b = new GameButton(x, y);
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
            foreach (GameButton g in Game_Matrix)
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
                    Quick_Swap(Game_Matrix[i, j], Game_Matrix[x, y]);
                }
            }
        }

        private void GameClick_Handler(object sender, EventArgs e)
        {
            GameButton b1 = sender as GameButton;

            if (b1 == null) return;

            int x, y;
            if (IsAdjacentToEmpty(b1, out x, out y))
            {
                // Trigger Switch Animation check
                if (Animation_Swap(Game_Matrix[b1.X, b1.Y], Game_Matrix[x, y]))
                {
                    // Switch x,y in Matrix
                    GameButton b2 = Game_Matrix[x, y];
                    Game_Matrix[b1.X, b1.Y] = b2;
                    Game_Matrix[x, y] = b1;

                    // Switch x,y inside GameButtons
                    int xTemp = b1.X;
                    int yTemp = b1.Y;
                    b1.X = b2.X;
                    b1.Y = b2.Y;
                    b2.X = xTemp;
                    b2.Y = yTemp;
                }

            }
            
        }

        private void NewGameClick_Handler(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Quick_Swap(GameButton b1, GameButton b2)
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

        private Boolean Animation_Swap(GameButton b1, GameButton b2)
        {
            if (this.To_Switch[0] == null){ // Only add button to switch queue if empty.
                // Btns to Switch
                To_Switch[0] = b1;
                To_Switch[1] = b2;
                // Destinations
                Locations[0] = b2.Left;
                Locations[1] = b2.Top;
                Locations[2] = b1.Left;
                Locations[3] = b1.Top;
                // Start timer
                t.Start();
                return true;
            }
            return false;
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
            //if (Game_Matrix[0, 0].Text == "1" && Game_Matrix[0, 1].Text == "2") Win();

            // Full Win Condition
            int counter = 1;
            for (int i = 0; i < Game_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Game_Matrix.GetLength(1); j++)
                {
                    if (counter == 16) continue;
                    if (Game_Matrix[i, j].Text != "" + counter++) return;
                }
            }
            Win();

        }

        private void Win()
        {
            DialogResult d = MessageBox.Show("New Game?", "You win!", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes) RestartGame();
            else this.Close();
        }

        private void RestartGame()
        {
            t.Stop(); // Stop current board actions before deleting it.
            To_Switch[0] = null;
            To_Switch[1] = null;

            DestroyBoard();
            CreateBoard();
            RandomizePositions();
        }

        private void CreateTimer()
        {
            t.Interval = 20;
            t.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (To_Switch[0] != null)
            {
                if (To_Switch[0].Left != Locations[0] || To_Switch[0].Top != Locations[1]) // Buttons not in correct position
                {
                    AdjustPositions();
                }
                else // Btns have switched positions
                {
                    t.Stop();
                    CheckWinCondition();
                    To_Switch[0] = null;
                    To_Switch[1] = null;
                }
            }
        }

        private void AdjustPositions()
        {
            // Locations [0],[1] = Destination for b1
            // Locations [2],[3] = Destination for b2

            GameButton b1 = To_Switch[0];
            GameButton b2 = To_Switch[1];

            if (b1.Left < Locations[0])
            {
                b1.Left += 10;
            }
            else if (b1.Left > Locations[0])
            {
                b1.Left -= 10;
            }

            if (b1.Top < Locations[1])
            {
                b1.Top += 10;
            }
            else if (b1.Top > Locations[1])
            {
                b1.Top -= 10;
            }

            if (b2.Left < Locations[2])
            {
                b2.Left += 10;
            }
            else if (b2.Left > Locations[2])
            {
                b2.Left -= 10;
            }

            if (b2.Top < Locations[3])
            {
                b2.Top += 10;
            }
            else if (b2.Top > Locations[3])
            {
                b2.Top -= 10;
            }
        }
    }
        

    
}

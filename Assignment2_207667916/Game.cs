namespace Assignment2_207667916
{
    public partial class Game : Form
    {
        private Button[] Game_Matrix = new Button[15];
        private int count = 1;
        Random r = new Random();
        private Button To_Switch = null;
        private Point empty_pos = new Point();
        private Point empty_next_pos = new Point();
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

        private Button CreateGameButton()
        {
            Button b = new Button();
            b.Height = 70;
            b.Width = 70;
            b.Text = count.ToString();
            count++;
            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            b.Click += GameClick_Handler;
            return b;
        }

        private void CreateBoard()
        {
            int x = 10, y = 50;
            
            for (int i = 0; i < Game_Matrix.GetLength(0); i++)
            {
                Game_Matrix[i] = CreateGameButton();
                
                Game_Matrix[i].Location = new Point(x + 20, y);
                this.Controls.Add(Game_Matrix[i]);

                x += Game_Matrix[i].Width;

                if ((i+1) % 4 == 0)
                {
                    x = 10;
                    y += Game_Matrix[i].Height;
                }
            }
            empty_pos = new Point(x + 20, y);
        }

        private void DestroyBoard()
        {
            count = 1;
            foreach (Button g in Game_Matrix)
            {
                g.Dispose();
            }
        }

        private void RandomizePositions()
        {
            int swp;
            for (int i = 0; i < Game_Matrix.GetLength(0); i++)
            {
                do
                {
                    swp = r.Next(15);
                } while (swp == i);
                Quick_Swap(Game_Matrix[i], Game_Matrix[swp]);   
            }
        }

        private void GameClick_Handler(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (b == null) return;

            if (IsAdjacentToEmpty(b))
            {
                // Trigger Switch Animation check
                Animation_Swap(b);
            }

        }

        private void NewGameClick_Handler(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Quick_Swap(Button b1, Button b2)
        {
            // Animationless swap for game init

            Point tmp = new Point(b1.Location.X, b1.Location.Y);
            b1.Location = b2.Location;
            b2.Location = tmp;
        }

        private Boolean Animation_Swap(Button b)
        {
            if (this.To_Switch == null)
            { // Only add button to switch queue if empty.
                // Btn to Switch
                To_Switch = b;
                empty_next_pos = b.Location; // Back b's position to transfer to empty when done swapping
                // Start timer
                t.Start();
                return true;
            }
            return false;
        }

        private Boolean IsAdjacentToEmpty(Button b)
        {
            int x = b.Left; int y = b.Top;

            if (empty_pos == new Point(x, y+b.Height) || empty_pos == new Point(x, y - b.Height) 
                || empty_pos == new Point(x + b.Width, y) || empty_pos == new Point(x - b.Width, y))
            {
                return true;
            }
            return false;
        }

        private void CheckWinCondition()
        {

            // i limit determines how many buttons need to be order to win.
            Point ExpectedLocation = new Point();

            for (int i = 1; i <= 2; i++) // <--- i <= amount of blocks to solve
            {
                for (int j = 0; j < Game_Matrix.Length; j++)
                {
                    if (Game_Matrix[j].Text == i.ToString())
                    {
                        ExpectedLocation.X = 30 + (Game_Matrix[j].Width * ((i - 1) % 4));
                        ExpectedLocation.Y = 50 + (Game_Matrix[j].Height * ((int)(i - 1) / 4));

                        if (ExpectedLocation != Game_Matrix[j].Location) return;
                        break;
                    }
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
            To_Switch = null;
            
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
            if (To_Switch != null)
            {
                if (To_Switch.Location != empty_pos) // Button at destination?
                {
                    AdjustPositions();
                }
                else // Btn is at destination
                {
                    t.Stop();
                    empty_pos = empty_next_pos; // complete swap
                    CheckWinCondition();
                    To_Switch = null;
                }
            }
        }

        private void AdjustPositions()
        {
            Button b = To_Switch;
            
            if (b.Left < empty_pos.X)
            {
                b.Left += 10;
            }
            else if (b.Left > empty_pos.X)
            {
                b.Left -= 10;
            }
            else if (b.Top < empty_pos.Y)
            {
                b.Top += 10;
            }
            else if (b.Top > empty_pos.Y)
            {
                b.Top -= 10;
            }

        }
    }



}

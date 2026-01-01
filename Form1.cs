/* 
 *  Student Name: Sena Unal
 *  Completion Date: 2026/01/01
 *  Game Name: Square Catcher
 *  Language: C#
 * 
 * */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; //allows the use of SoundPlayer

namespace Square_Chaser
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer gameTimer;

        // The sounds of interactions
        SoundPlayer targetMetSoundPlayer = new SoundPlayer(Properties.Resources.targetMetSound);
        SoundPlayer powerUpSoundPlayer = new SoundPlayer(Properties.Resources.powerUpSound);
        SoundPlayer winSoundPlayer = new SoundPlayer(Properties.Resources.winSound);

        // The colour of the players 
        SolidBrush play1Color = new SolidBrush(Color.LightCyan);
        SolidBrush play2Color = new SolidBrush(Color.HotPink);


        // The colour of the target circle and other power ups/downs
        SolidBrush targetRectangleColor = new SolidBrush(Color.White);
        SolidBrush speedColor = new SolidBrush(Color.Yellow);


        //Players, target, and power up initialized -- x,y,width and height
        Rectangle player1 = new Rectangle(130, 160, 50, 50);
        Rectangle player2 = new Rectangle(230, 160, 50, 50);

        Rectangle targetRectangle = new Rectangle(0, 0, 40, 40);
        Rectangle speedPowerUp = new Rectangle(0, 0, 26, 26);


        // Player scores initialized
        int player1Score = 0;
        int player2Score = 0;


        //The speeds will be the pixel step size each time the player or ball moves
        int player1Speed = 4;
        int player2Speed = 4;


        //These booleans are required for keypress methods

        //player 1
        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        //player 2
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;


        // At first I manually randomized target with X and Y but then learnt that I could use .X and .Y with power boost
        // Initialized target X and Y to 0
        int targetRectangleX = 0;
        int targetRectangleY = 0;

        // Initialized a random point generator
        Random randomPoint = new Random();


        // Power up method
        void powerUp(int player) // takes in player variable to know which player is calling the method
        {
            switch (player) // The player becomes faster
            {
                case 1:
                    player1Speed = 7;
                    break;
                case 2:
                    player2Speed = 7;
                    break;
            }

            // Power up sound plays
            powerUpSoundPlayer.Play();

            // The power up goes to a random place
            speedPowerUp.X = randomPoint.Next(75, 490);
            speedPowerUp.Y = randomPoint.Next(75, 400);
        }


        // Method for when the player scores
        void playerScores(int player) // Takes in player variable to know which player is calling the method
        {
            switch (player)
            {
                case 1:
                    // The score of the player increases by 1
                    player1Score += 1;
                    p1scoreLabel.Text = "Player 1 Score: " + player1Score;

                    if (player1Score == 4) // Checks if the player won (by acquiring 4 points)
                    {
                        // Displays winning message
                        winningLabel.Visible = true;
                        winningLabel.Text = "Player 1 WON!";

                        // Plays winning sound
                        winSoundPlayer.Play();

                        // Stops the game
                        gameTimer.Stop();
                        targetTimer.Stop();

                    }
                    break;
                case 2:
                    // The score of the player increases by 1
                    player2Score += 1;
                    p2scoreLabel.Text = "Player 2 Score: " + player2Score;

                    if (player2Score == 4) // Checks if the player won (by acquiring 4 points)
                    {
                        // Displays winning message
                        winningLabel.Visible = true;
                        winningLabel.Text = "Player 2 WON!";

                        // Plays winning sound
                        winSoundPlayer.Play();

                        // Stops the game
                        gameTimer.Stop();
                        targetTimer.Stop();

                    }
                    break;

            }

            // Randomizes the location of the target
            targetRectangle.X = randomPoint.Next(75, 490);
            targetRectangle.Y = randomPoint.Next(75, 400);

            // If player gains a point the sound plays
            targetMetSoundPlayer.Play();

        }


        public Form1()
        {
            InitializeComponent();

            // Timer for the players
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20;        // 20 ms
            gameTimer.Enabled = true;       // start immediately
            gameTimer.Tick += GameTimer_Tick;

            // Timer for the target, scores, and speed boost
            targetTimer = new System.Windows.Forms.Timer();
            targetTimer.Interval = 10;        // 10 ms
            targetTimer.Enabled = true;       // start immediately
            targetTimer.Tick += targetTimer_Tick;


            // Manually randomizes the X Y coordinates of the target 
            targetRectangleX = randomPoint.Next(75, 490);
            targetRectangleY = randomPoint.Next(75, 400);
            targetRectangle = new Rectangle(targetRectangleX, targetRectangleY, 40, 40);

            // Randomizes the X Y coordinates of the speed power up
            speedPowerUp.X = randomPoint.Next(75, 490);
            speedPowerUp.Y = randomPoint.Next(75, 400);

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // This runs every 20 ms

            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += player1Speed;
            }


            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }

            // Refreshes
            Invalidate();

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Paints the objects
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(play1Color, player1);
            g.FillRectangle(play2Color, player2);
            g.FillRectangle(targetRectangleColor, targetRectangle);
            g.FillEllipse(speedColor, speedPowerUp);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Switch statement for if a key is pressed
            switch (e.KeyCode)
            {
                // Player 1
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;

                // Player 2
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Switch statement for if a key is not pressed/released
            switch (e.KeyCode)
            {
                // Player 1
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;

                // Player 2
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }

        }


        private void targetTimer_Tick(object sender, EventArgs e)
        {
            // Ticks every 10 ms 

            // If player intersects with the target
            if (player1.IntersectsWith(targetRectangle))
            {
                // Player score method is called and let known that it was called by player1
                playerScores(1);
            }

            // If player intersects with the power up
            if (player1.IntersectsWith(speedPowerUp))
            {
                // Power up method is called and let known that it was called by player1
                powerUp(1);

            }
            

            // If player intersects with the target
            if (player2.IntersectsWith(targetRectangle))
            {
                // Player score method is called and let known that it was called by player2
                playerScores(2);
            }

            // If player intersects with the power up
            if (player2.IntersectsWith(speedPowerUp))
            {
                // Power up method is called and let known that it was called by player2
                powerUp(2);
            }
        }
    }
}

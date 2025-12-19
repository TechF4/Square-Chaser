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

namespace Square_Chaser
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer gameTimer;

        public Form1()
        {
            InitializeComponent();
            
            // Timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20;        // 20 ms
            gameTimer.Enabled = true;       // start immediately
            gameTimer.Tick += GameTimer_Tick;

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // This runs every 20 ms

            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if(aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if(dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }


            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }
            
            if (leftArrowDown == true && player2.X > 0)
            { 
                player2.X -= playerSpeed; 
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            // Refreshes
            Invalidate();

        }


        // The colour of the players
        SolidBrush play1Color = new SolidBrush(Color.LightCyan);
        SolidBrush play2Color = new SolidBrush(Color.HotPink);

        //These rectangles with initial x,y,width and height
        Rectangle player1 = new Rectangle(130, 160, 50, 50);
        Rectangle player2 = new Rectangle(230, 160, 50, 50);
        
        // Rectangle ball = new Rectangle(295, 195, 10, 10);                               // Will get to ball later

        
        int player1Score = 0;                                                            // Will get to scores later
        int player2Score = 0;                                                            // Will get to scores later

        //The speeds will be the pixel step size each time the player or ball moves
        int playerSpeed = 4;

        
        int ballXSpeed = -6;                                                               // Will get to ball later
        int ballYSpeed = 6;                                                                // Will get to ball later


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




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(play1Color, player1);
            g.FillRectangle(play2Color, player2);
            // g.FillRectangle(whiteBrush, ball);

            /* Graphics g = e.Graphics;

            g.FillPie(play1Color, 130, 160, 50, 50, 30, 300);

            g.FillPie(play2Color, 230, 160, 50, 50, 30, 300); */
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
    }
}

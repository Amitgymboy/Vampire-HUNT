using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampire_Game
{
    public partial class Form1 : Form
    {
        Graphics g; //declare a graphics object called g
                    // declare space for an array of 7 objects called planet 
        Stake[] stake = new Stake[7];
        Random yspeed = new Random();
        Vampire vampire = new Vampire();
        bool left, right, up, down;
        string move;
        int score, lives;


        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                stake[i] = new Stake(x);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }

        }

        private void tmrVampire_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                vampire.moveVampire(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                vampire.moveVampire(move);
            }
            if (up) // if up arrow key pressed
            {
                move = "up";
                vampire.moveVampire(move);
            }
            if (down) // if down arrow key pressed
            {
                move = "down";
                vampire.moveVampire(move);
            }

        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            score = 0;
            lblScore.Text = score.ToString();
            lives = int.Parse(lblLives.Text);// pass lives entered from textbox to lives variable
            tmrStake.Enabled = true;
            tmrVampire.Enabled = true;

        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            tmrVampire.Enabled = false;
            tmrStake.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lives = int.Parse(lblLives.Text);// pass lives entered from textbox to lives variable
            MessageBox.Show("Use the left and right arrow keys to move the spaceship. \n Don't get hit by the planets! \n Every planet that gets past scores a point. \n If a planet hits a spaceship a life is lost! \n \n Enter your Name press tab and enter the number of lives \n Click Start to begin", "Game Instructions");
            txtName.Focus();

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Planet class's DrawPlanet method to draw the image planet1 
            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(5, 20);
                stake[i].x -= rndmspeed;

                //call the stake class's drawStake method to draw the images
                stake[i].drawStake(g);
            }
            vampire.drawVampire(g);


        }

        private void tmrStake_Tick(object sender, EventArgs e)
        {
            score = 0;
            for (int i = 0; i < 7; i++)
            {
                score += stake[i].score;// get score from Planet class (in movePlanet method)
                lblScore.Text = score.ToString();// display score
                stake[i].moveStake();
                if (vampire.vampireRec.IntersectsWith(stake[i].stakeRec))
                {
                    //reset planet[i] back to top of panel
                    stake[i].x = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                   lblLives.Text = lives.ToString();// display number of lives
                    checkLives();
                }

            }

            pnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }
        private void checkLives()
        {
            if (lives == 0)
            {
                tmrStake.Enabled = false;
                tmrVampire.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }

    }
}

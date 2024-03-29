﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampire_Hunt
{
    public partial class form1 : Form
    {
        Graphics g; //declare a graphics object called g
                    // declare space for an array of 7 objects called planet 
        Planet[] planet = new Planet[7];
        Random xspeed = new Random();
        spaceship spaceship = new spaceship();
        bool up, down;
        string move;


        public form1()
        {

            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                int y = 10 + (i * 75);
                planet[i] = new Planet(y);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            spaceship.drawSpaceship(g);
            //call the Planet class's DrawPlanet method to draw the image planet1 
            for (int i = 0; i < 7; i++)
            {
                spaceship.drawSpaceship(g);
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = xspeed.Next(5, 20);
                planet[i].x -= rndmspeed;
                //call the Planet class's drawPlanet method to draw the images
                planet[i].drawPlanet(g);
            }
            


        }

        private void form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }

        }

        private void form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }

        }

        private void tmrship_Tick(object sender, EventArgs e)
        {
            if (up) // if right arrow key pressed
            {
                move = "up";
                spaceship.movespaceship(move);
            }
            if (down) // if left arrow key pressed
            {
                move = "down";
                spaceship.movespaceship(move);
            }

        }

        private void tmrplanet_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                planet[i].movePlanet();
            }
            panel1.Invalidate();//makes the paint event fire to redraw the panel
        }


    }
}

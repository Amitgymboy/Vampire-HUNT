using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Vampire_Game
{
    class Vampire
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image vampire;//variable for the planet's image

        public Rectangle vampireRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Vampire()
        {
            x = 10;
            y = 360;
            width = 40;
            height = 40;
            vampire = Image.FromFile("alien1.png");
            vampireRec = new Rectangle(x, y, width, height);
        }
        //methods
        public void drawVampire(Graphics g)
        {

            g.DrawImage(vampire, vampireRec);
        }
        public void moveVampire(string move)
        {
            vampireRec.Location = new Point(x, y);

            if (move == "right")
            {
                if (vampireRec.Location.X > 704) // is spaceship within 50 of right side
                {
                    x = 10;
                    vampireRec.Location = new Point(x, y);
                }
                else
                {
                    x += 5;
                    vampireRec.Location = new Point(x, y);
                }

            }
            if (move == "left")
            {
                if (vampireRec.Location.X < 10) // is spaceship within 10 of left side
                {

                    x = 10;
                    vampireRec.Location = new Point(x, y);
                }
                else
                {
                    x -= 5;
                    vampireRec.Location = new Point(x, y);
                }

            }
            if (move == "up")
            {
                if (vampireRec.Location.Y < 10) // is spaceship within 10 of top side
                {

                    y = 10;
                    vampireRec.Location = new Point(x, y);
                }
                else
                {
                    y -= 5;
                    vampireRec.Location = new Point(x, y);
                }


            }
            if (move == "down")
            {
                if (vampireRec.Location.Y > 500) // is spaceship within 10 of bottom side
                {

                    y = 500;
                    vampireRec.Location = new Point(x, y);
                }
                else
                {
                    y += 5;
                    vampireRec.Location = new Point(x, y);
                }

            }
        }
    }
}
    

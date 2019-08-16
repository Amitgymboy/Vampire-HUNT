using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Vampire_Game
{
    class Stake
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image stakeImage;//variable for the planet's image

        public Rectangle stakeRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        public Stake(int spacing)
        {
            x = 700;
            y = spacing;
            width = 20;
            height = 20;
            stakeImage = Image.FromFile("planet1.png");
            stakeRec = new Rectangle(x, y, width, height);
        }
        // Methods for the Planet class
        public void drawStake(Graphics g)
        {
            stakeRec = new Rectangle(x, y, width, height);
            g.DrawImage(stakeImage, stakeRec);
        }
   
        public void moveStake()
        {
         

            stakeRec.Location = new Point(x, y);
            if (stakeRec.Location.X < 14)
            {
                score += 1;// add 1 to score when stake reaches left side of panel
                x = 700;
                
                stakeRec.Location = new Point(x, y);
            }

        }



    }
}

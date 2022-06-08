using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace thebestestgame
{
    public partial class CAMTHEMAN : Form
    {
        bool aDown = false;
        bool wDown = false;
        bool sDown = false;
        int randValue = 0;
        int playerSpeed = 5;
        int missleeXSpeed = 0;
        int missleeYSpeed = 5;
        int metor = 75;
       
        Rectangle rocketShip = new Rectangle(200, 360, 110, 90);
        SolidBrush rocketShipsColour = new SolidBrush(Color.Silver);
        Rectangle misslle = new Rectangle(200, 360, 60, 50);
       
        List<int> metorSpeeds = new List<int>();
        List<Rectangle> metors = new List<Rectangle>();

        Random randGen = new Random();


        public CAMTHEMAN()
        {
            InitializeComponent();
        }
        private void CAMTHEMAN_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;

            }
        }
        private void CAMTHEMAN_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
            }

        }


        private void CAMTHEMAN_Paint(object sender, PaintEventArgs e)
        {
            //       e.Graphics.FillRectangle(rocketShipsColour, rocketShip);
            e.Graphics.DrawImage(Properties.Resources.rocekyshipt6, rocketShip);
            e.Graphics.DrawImage(Properties.Resources.missle, misslle);

            for (int i = 0; i < metors.Count(); i++)
            {

                e.Graphics.DrawImage(Properties.Resources.rock, metors[i]);
             //  e.Graphics.FillEllipse(Brushes.White, metors[i]);
            }
        }

        private void camsGameLoop(object sender, EventArgs e)
        {
            if (wDown == true && rocketShip.Y > 0)
            {
                rocketShip.Y -= playerSpeed;
                misslle.Y -= missleeYSpeed;

            }

            if (sDown == true && rocketShip.Y < this.Height - rocketShip.Height)
            {
                rocketShip.Y += playerSpeed;
                misslle.Y += missleeYSpeed;
            }
            if (aDown == true && misslle.X > 0)
            {

                missleeXSpeed = 5;
                missleeYSpeed = 0;

            }
            if (aDown == false)
            {
                misslle.X += missleeXSpeed;
            }

            randValue = randGen.Next(0, 100);
            //meators
            if (randValue <6)
            {

                int y = randGen.Next(10, this.Height - 150);
                metors.Add(new Rectangle(1000, y, metor, metor));
                metorSpeeds.Add(randGen.Next(-10, -2));           
                
            }
            for (int i = 0; i < metors.Count(); i++)
            {
                //find the new postion of y based on speed
                int x = metors[i].X + metorSpeeds[i];

                //replace the rectangle in the list with updated one using new y
                metors[i] = new Rectangle(x, metors[i].Y, metor, metor);
                if (metors[i].X < 0)
                {
                    metors.RemoveAt(i);
                    metorSpeeds.RemoveAt(i);
                }
            }
            for (int i = 0; i < metors.Count(); i++)
            {
                if (misslle.IntersectsWith(metors[i]))
                {
                    misslle.Y = rocketShip.Y;
                    misslle.X = rocketShip.X;
                    metors.RemoveAt(i);
                    metorSpeeds.RemoveAt(i);
                    missleeXSpeed = 0;
                    missleeYSpeed = playerSpeed;


                }
            }
            Refresh();
        }
    }

}
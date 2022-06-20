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
       //ints,bools and strings
        int randValue = 0;
        int playerSpeed = 15;
        int missleeXSpeed = 0;
        int missleeYSpeed = 15;
        int metor = 75;
        int score = 0;
        int lives = 3;
        bool aDown = false;
        bool wDown = false;
        bool sDown = false;
        string gameState = "waiting";
       //Rectangles
        List<int> metorSpeeds = new List<int>();
        List<Rectangle> metors = new List<Rectangle>();
        Rectangle rocketShip = new Rectangle(90, 190, 110, 90);
        Rectangle misslle = new Rectangle(80, 200, 110, 80);
        Rectangle earth = new Rectangle(1, 1, 100, 500);
        Rectangle heart1 = new Rectangle(10, 10, 50, 50);
        Rectangle heart2 = new Rectangle(70, 10, 50, 50);
        Rectangle heart3 = new Rectangle(130, 10, 50, 50);
        Rectangle outerSpace = new Rectangle(650, 1, 1, 60000000);
        SolidBrush rocketShipsColour = new SolidBrush(Color.Black);
        Random randGen = new Random();
        //Sounds
        SoundPlayer gun = new SoundPlayer(Properties.Resources.gun);
        SoundPlayer death = new SoundPlayer(Properties.Resources.Hl2_Rebel_Ragdoll485_573931361__1_);
        SoundPlayer flyup = new SoundPlayer(Properties.Resources.UFO_Takeoff_Sonidor_1604321570);
        SoundPlayer destroy = new SoundPlayer(Properties.Resources.Grenade_Explosion_SoundBible_com_2100581469);
        SoundPlayer flydown = new SoundPlayer(Properties.Resources.descending_craft_Sonidor_991848481);
        


        public CAMTHEMAN()
        {
            InitializeComponent();
        }
        public void GameInitialize()
        {
            titlelabel.Text = "";
            subtitleLabel.Text = "";
            titlelabel.Visible = false;
            subtitleLabel.Visible = false;
            gameTimer.Enabled = true;

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
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                        gameState = "running";

                    }
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
            if (gameState == "waiting")
            {
                titlelabel.Text = "Cams Game";
                subtitleLabel.Text = "PRESS SPACE TO START";
            }
            if (gameState == "running")
            {   //       e.Graphics.FillRectangle(rocketShipsColour, rocketShip);

                e.Graphics.DrawImage(Properties.Resources.goodmissle_2__2_, misslle);
                e.Graphics.DrawImage(Properties.Resources.rocekyshipt6, rocketShip);
                e.Graphics.FillRectangle(rocketShipsColour, outerSpace);
                e.Graphics.DrawImage(Properties.Resources.eartahse, earth);

                // if there are 3 hp left draw all hearts
                if (lives == 3)
                {
                    e.Graphics.DrawImage(Properties.Resources.heart_1, heart1);
                    e.Graphics.DrawImage(Properties.Resources.heart_2, heart2);
                    e.Graphics.DrawImage(Properties.Resources.heart_3, heart3);
                }


                //else if there are 2 hp left draw 2 hearts
                else if (lives == 2)
                {
                    e.Graphics.DrawImage(Properties.Resources.heart_1, heart1);
                    e.Graphics.DrawImage(Properties.Resources.heart_2, heart2);

                }
                else if (lives == 1)
                {
                    e.Graphics.DrawImage(Properties.Resources.heart_1, heart1);
                }
                else if (lives == 0)
                {

                }
                for (int i = 0; i < metors.Count(); i++)
                {

                    e.Graphics.DrawImage(Properties.Resources.rock, metors[i]);
                    //  e.Graphics.FillEllipse(Brushes.White, metors[i]);
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == "running")
            {
                subtitleLabel.Visible = false;

                if (wDown == true && rocketShip.Y > 0)
                {
                    rocketShip.Y -= playerSpeed;
                    misslle.Y -= missleeYSpeed;

                }

                if (sDown == true && rocketShip.Y < this.Height - rocketShip.Height)
                {
                    rocketShip.Y += playerSpeed;
                    misslle.Y += missleeYSpeed;
                    flydown.Play();
                }
                if (aDown == true && misslle.X > 0)
                {

                    missleeXSpeed = 50;
                    missleeYSpeed = 0;
                    gun.Play();

                }

                misslle.X += missleeXSpeed;

                randValue = randGen.Next(0, 100);
                //meators
                if (randValue < 5)
                {

                    int y = randGen.Next(10, 400);
                    metors.Add(new Rectangle(750, y, metor, metor));
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
                        misslle.Y = rocketShip.Y + 10;
                        misslle.X = rocketShip.X - 10;
                        metors.RemoveAt(i);
                        metorSpeeds.RemoveAt(i);
                        missleeXSpeed = 0;
                        missleeYSpeed = playerSpeed;
                        score += 155;
                        gameScore.Text = $"{score}";
                        destroy.Play();

                    }

                }
                for (int i = 0; i < metors.Count(); i++)
                {
                    if (earth.IntersectsWith(metors[i]))
                    {
                        metors.RemoveAt(i);
                        metorSpeeds.RemoveAt(i);
                        lives -= 1;
                        death.Play();
                    }

                }
                if (misslle.IntersectsWith(outerSpace))
                {
                    misslle.X = rocketShip.X - 10;
                    misslle.Y = rocketShip.Y + 10;
                    missleeXSpeed = 0;
                    missleeYSpeed = playerSpeed;
                    score -= 50;
                    gameScore.Text = $"{score}";
                }
                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    subtitleLabel.Visible = true;
                    subtitleLabel.Text = " YOU LOSE:(";

                }
                if (score > 780)
                {
                    subtitleLabel.Visible = true;
                    subtitleLabel.Text = " YOU WIN!!";

                    subtitleLabel.BringToFront();
                    gameTimer.Enabled = false;






                }

                for (int i = 0; i < metors.Count(); i++)
                {
                    if (rocketShip.IntersectsWith(metors[i]))
                    {
                        metors.RemoveAt(i);
                        metorSpeeds.RemoveAt(i);
                        lives -= 1;
                        death.Play();
                    }

                }
                if (score < -1)
                {
                    lives = 0;

                }

                Refresh();
            }
        }



    }

}
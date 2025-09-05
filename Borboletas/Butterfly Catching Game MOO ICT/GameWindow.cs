using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Butterfly_Catching_Game_MOO_ICT
{
    public partial class GameWindow : Form
    {
        float timeLeft = 10f;
        int caught = 0;
        int spawnTime = 0;
        int spawnLimit = 30;
        List<Butterfly> butterfly_list = new List<Butterfly>();
        Random rand = new Random();

        Image[] butterfly_images = { Properties.Resources._01, Properties.Resources._02, Properties.Resources._03, Properties.Resources._04, Properties.Resources._05, Properties.Resources._06, Properties.Resources._07, Properties.Resources._08, Properties.Resources._09, Properties.Resources._10 };

        List<Joaninha> jona_list = new List<Joaninha>();
        Image ladybug_image = Properties.Resources.jona;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            lblTime.Text = "Time Left: " + timeLeft.ToString("#") + ".s";
            lblCaught.Text = "Caught: " + caught;
            timeLeft -= 0.03f;

            if (butterfly_list.Count < spawnLimit)
            {
                spawnTime--;

                if (spawnTime < 1)
                {
                    MakeButterfly();
                    spawnTime = spawnLimit;
                }
            }

            if (jona_list.Count < 5) // limite de joaninhas
            {
                MakeLadybug();
            }
            foreach (Joaninha j in jona_list)
            {
                j.MoveJoaninha();
            }

            foreach (Butterfly butterfly in butterfly_list)
            {
                butterfly.MoveButterfly();

                butterfly.positionX += butterfly.speedX;

                if (butterfly.positionX < 0 || butterfly.positionX + butterfly.width > this.ClientSize.Width)
                {
                    butterfly.speedX = -butterfly.speedX;

                    if (butterfly.positionX < 0)
                    {
                        butterfly.positionX = butterfly.positionX + 10;
                    }
                    else if (butterfly.positionX + butterfly.width > this.ClientSize.Width)
                    {
                        butterfly.positionX = butterfly.positionX - 10;
                    }
                }

                butterfly.positionY += butterfly.speedY;

                if (butterfly.positionY < 0 || butterfly.positionY + butterfly.height > this.ClientSize.Height - 50)
                {
                    butterfly.speedY = -butterfly.speedY;

                    if (butterfly.positionY < 0)
                    {
                        butterfly.positionY = butterfly.positionY + 10;
                    }
                    else if (butterfly.positionY + butterfly.height > this.ClientSize.Height - 50)
                    {
                        butterfly.positionY = butterfly.positionY - 10;
                    }
                }


            }
            for (int i = jona_list.Count - 1; i >= 0; i--)
            {
                Joaninha j = jona_list[i];
                j.MoveJoaninha();
                j.positionX += j.speedX;
                j.positionY += j.speedY;

                // Verifica colisão com bordas
                if (j.positionX < 0 || j.positionX + j.width > this.ClientSize.Width)
                    j.speedX = -j.speedX;
                if (j.positionY < 0 || j.positionY + j.height > this.ClientSize.Height - 50)
                    j.speedY = -j.speedY;

                // Remove se a joaninha morreu
                if (j.IsDead())
                    jona_list.RemoveAt(i);
            }




            if (timeLeft < 1)
            {
                GameOver();
            }

            this.Invalidate();

        }

        private void MakeLadybug()
        {
            Joaninha j = new Joaninha();
            j.ladybug_image = ladybug_image; // sempre a mesma imagem
           j.positionX = rand.Next(50, this.ClientSize.Width - 200);
            j.positionY = rand.Next(50, this.ClientSize.Height - 200);

            jona_list.Add(j);
            ImageAnimator.Animate(j.ladybug_image, this.OnFrameChangedHandler);
        }

        private void FormClickEvent(object sender, EventArgs e)
        {
            foreach (Butterfly butterfly in butterfly_list.ToList())
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                if (mouse.X >= butterfly.positionX && mouse.Y >= butterfly.positionY && mouse.X < butterfly.positionX + butterfly.width && mouse.Y < butterfly.positionY + butterfly.height)
                {
                    butterfly_list.Remove(butterfly);
                    caught++;
                }
            }
            foreach (Joaninha j in jona_list.ToList())
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                if (mouse.X >= j.positionX && mouse.Y >= j.positionY &&
                    mouse.X < j.positionX + j.width && mouse.Y < j.positionY + j.height)
                {
                    jona_list.Remove(j);
                    caught++; // ou criar um contador separado para joaninhas
                }
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();

            foreach (Butterfly butterfly in butterfly_list)
            {
                e.Graphics.DrawImage(butterfly.butterfly_image, butterfly.positionX, butterfly.positionY, butterfly.width, butterfly.height);
            }
            foreach (Joaninha j in jona_list)
            {
                e.Graphics.DrawImage(j.ladybug_image, j.positionX, j.positionY, j.width, j.height);
            }

        }

        private void MakeButterfly()
        {
            int i = rand.Next(butterfly_images.Length);

            Butterfly newButterFly = new Butterfly();
            newButterFly.butterfly_image = butterfly_images[i];
            newButterFly.positionX = rand.Next(50, this.ClientSize.Width - 200);
            newButterFly.positionY = rand.Next(50, this.ClientSize.Height - 200);
            butterfly_list.Add(newButterFly);
            ImageAnimator.Animate(newButterFly.butterfly_image, this.OnFrameChangedHandler);
        }

        private void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void RestartGame()
        {
            this.Invalidate();
            butterfly_list.Clear();
            caught = 0;
            timeLeft = 60f;
            spawnTime = 0;
            lblTime.Text = "Time: 00";
            lblCaught.Text = "Caught: 0";
            GameTimer.Start();
        }

        private void GameOver()
        {
            GameTimer.Stop();
            MessageBox.Show("Times Up!!, You've Caught " + caught + " butterflies. Click ok to try again.", "MOO says: ");
            RestartGame();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

/// Yaksh Patel
/// April 23, 2024
/// This is my Halloween greeting card

namespace GreetingCard
{

    public partial class greetingCard : Form
    {
        SoundPlayer happyLaugh = new SoundPlayer(Properties.Resources.happy); // Set all my colors, fonts, and sounds.
        SoundPlayer evilLaugh = new SoundPlayer(Properties.Resources.evil);
        SoundPlayer introSound = new SoundPlayer(Properties.Resources.start);

        Pen outlinePen = new Pen(Color.White, 2);
        Pen outlinePen2 = new Pen(Color.Black, 2);
        Pen redPen = new Pen(Color.Red, 6);
        Pen orangePen = new Pen(Color.DarkOrange, 20);
        Pen yellowPen = new Pen(Color.Yellow, 2);

        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush brownBrush = new SolidBrush(Color.Brown);

        Font arialFont = new Font("Arial", 26, FontStyle.Regular);
        Font oldFont = new Font("Ravie", 30, FontStyle.Bold);

        public greetingCard()
        {
            InitializeComponent();
        }

        private void greetingCard_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);

            int x = 0;

            while (x < 331)       // Makes the word "TREAT" move from the left onto the screen.
            {
                g.Clear(Color.Black);
                g.DrawString("TREAT!!", oldFont, orangeBrush, 0 + x, 150);
                x = x + 40;
                Thread.Sleep(200);
            }

            happyLaugh.Play();

            for (int i = 0; i < 221; i = i + 220)   // Makes the two candies.
            {
                g.FillEllipse(redBrush, 220 + i, 250, 100, 75);
                g.FillPie(orangeBrush, 170 + i, 235, 100, 100, 135, 90);
                g.FillPie(orangeBrush, 270 + i, 235, 100, 100, 315, 90);
                g.DrawEllipse(yellowPen, 220 + i, 250, 100, 75);
                g.DrawPie(yellowPen, 170 + i, 235, 100, 100, 135, 90);
                g.DrawPie(yellowPen, 270 + i, 235, 100, 100, 315, 90);
            }

            Thread.Sleep(2000);
            g.Clear(Color.Black);

            evilLaugh.PlayLooping();

            int angle = 0;

            while (angle < 361)    // Rotates the word "TRICK".
            {
                g.Clear(Color.Black);
                g.TranslateTransform(360, 150);
                g.RotateTransform(angle);
                g.DrawString("TRICK\n\nHAHA", oldFont, orangeBrush, 0,0);
                g.ResetTransform();
                Thread.Sleep(100);
                angle = angle + 45;
            }

            int x2 = 0;

            for (int y = 421; y > 0; y = y - 30)  // Covers the whole screen in bricks.
            {
                while (x2 < 800)
                {
                    g.FillRectangle(brownBrush, 0 + x2, y, 100, 30);
                    g.DrawRectangle(outlinePen, 0 + x2, y, 100, 30);
                    Thread.Sleep(50);
                    x2 = x2 + 100;
                }

                x2 = 0;
            }
        }

        private void greetingCard_Shown(object sender, EventArgs e)
        {
            introSound.PlayLooping();

            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);

            g.DrawRectangle(orangePen, 245, 90, 320, 350);  // Displays text.
            g.DrawString("Happy Halloween\n\n\n  Trick Or Treat?", arialFont, orangeBrush, 260, 100);

            for (int i = 0; i < 191; i = i + 190)            // Makes my pumpkins twice.
            {
                g.FillRectangle(greenBrush, 300 + i, 286, 20, 30);
                g.DrawRectangle(yellowPen, 300 + i, 286, 20, 30);
                g.FillEllipse(orangeBrush, 260 + i, 300, 100, 100);
                g.FillPie(redBrush, 260 + i, 290, 60, 60, 80, 25);
                g.FillPie(redBrush, 304 + i, 290, 60, 60, 80, 25);
                g.DrawArc(outlinePen2, 280 + i, 300, 30, 100, 90, 180);
                g.DrawArc(outlinePen2, 300 + i, 300, 15, 100, 90, 180);
                g.DrawArc(outlinePen2, 320 + i, 300, 30, 100, 270, 180);
                g.DrawArc(outlinePen2, 310 + i, 300, 15, 100, 270, 180);
                g.DrawArc(redPen, 270 + i, 330, 80, 60, 0, 180);
                g.DrawEllipse(yellowPen, 260 + i, 300, 100, 100);
                g.DrawPie(yellowPen, 260 + i, 290, 60, 60, 80, 25);
                g.DrawPie(yellowPen, 304 + i, 290, 60, 60, 80, 25);
            }
        }
    }
}
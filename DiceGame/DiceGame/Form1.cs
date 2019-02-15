using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceGame
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        int[] dice = new int[5] { 0, 0, 0, 0, 0 };
        List<Player> results = new List<Player>();

        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.Red;
            buttonStart.Enabled = false;
            buttonSave.Enabled = false;
            textBoxPlayer.TextChanged += textBoxPlayer_TextChanged;
            //labelPoints.TextChanged + = labelPoints_TextChanged;
        }
        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = !string.IsNullOrWhiteSpace(textBoxPlayer.Text);
            Image[] Images = new Image[6];
            Images[0] = Properties.Resources.dice1;
            Images[1] = Properties.Resources.dice2;
            Images[2] = Properties.Resources.dice3;
            Images[3] = Properties.Resources.dice4;
            Images[4] = Properties.Resources.dice5;
            Images[5] = Properties.Resources.dice6;

            int result = 0;
            for(int i = 0; i < 5; i++)
            {
                dice[i] = ran.Next(1, 6);
                result += dice[i] + 1;
            }
            
            pictureBox1.Image = Images[dice[0]];
            pictureBox2.Image = Images[dice[1]];
            pictureBox3.Image = Images[dice[2]];
            pictureBox4.Image = Images[dice[3]];
            pictureBox5.Image = Images[dice[4]];

            labelPoints.Text = result.ToString();
            if (result > 0)
            {
                buttonSave.Enabled = true;
            }
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Player player = new Player(textBoxPlayer.Text, labelPoints.Text);
            results.Add(player);
            labelPoints.Text = "0";

            pictureBox1.Image = Properties.Resources.dice1;
            pictureBox2.Image = Properties.Resources.dice1;
            pictureBox3.Image = Properties.Resources.dice1;
            pictureBox4.Image = Properties.Resources.dice1;
            pictureBox5.Image = Properties.Resources.dice1;

            buttonSave.Enabled = false;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            textBoxList.Clear();
            for(int i = 0; i < results.Count; i++)
            {
                textBoxList.AppendText(results[i].Name + " " + results[i].Points + "\r\n");
            }
        }

        private void textBoxPlayer_TextChanged(object sender, EventArgs e)
        {
            buttonStart.Enabled = !string.IsNullOrWhiteSpace(textBoxPlayer.Text);
        }
    }
}

public class Player
{
    public string Name { get; set; }
    public string Points { get; set; }

    public Player(string name, string points)
    {
        Name = name;
        Points = points;
    }
}



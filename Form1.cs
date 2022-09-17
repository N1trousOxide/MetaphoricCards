using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PsychologicalTest
{
    public partial class Form1 : Form
    {   
        
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            pictureBox1.Hide();
            button1.Text = "Начать";
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            label1.Hide();
            label2.Hide();
            button2.Hide();
            button3.Hide();
            button1.Text = "Далее";
            string TextFile = textBox2.Text;
            string[] Lines = File.ReadAllLines(TextFile);
            Random rand = new Random();
            int index = rand.Next(Lines.Length);
            string RandomPhrase = Lines[index];
            StartupLabel.Text = RandomPhrase;
            button1.Click += new EventHandler(button1_secondClick);
            textBox1.Hide();
            textBox2.Hide();
        }
        public void button1_secondClick(object sender, EventArgs e)
        {
            StartupLabel.Hide();
            string FolderPath = textBox1.Text;
            textBox1.Hide();
            textBox2.Hide();
            string[] PicList1 = Directory.GetFiles(FolderPath, "*.jpg");
            string[] PicList2 = Directory.GetFiles(FolderPath, "*.png");
            string[] PicList = new string[PicList1.Length + PicList2.Length];
            PicList1.CopyTo(PicList, 0);
            PicList2.CopyTo(PicList, PicList1.Length);
            pictureBox1.Show();
            Random rand2 = new Random();
            int index1 = rand2.Next(PicList.Length);
            pictureBox1.Image = Image.FromFile(PicList[index1]);
            button1.Click += new EventHandler(button1_thirdClick);
        }

        private void button1_thirdClick(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            StartupLabel.Show();
            string TextFile = textBox2.Text;
            string[] Lines = File.ReadAllLines(TextFile);
            Random rand = new Random();
            int index = rand.Next(Lines.Length);
            string RandomPhrase = Lines[index];
            StartupLabel.Text = RandomPhrase;
            button1.Click += new EventHandler(button1_fourthClick);
            textBox1.Hide();
            textBox2.Hide();
            
        }

        private void button1_fourthClick(object sender, EventArgs e)
        {
            pictureBox1.Show();
            StartupLabel.Hide();
            button1.Text = "Закрыть";
            button1.Click += new EventHandler(button1_fifthClick);
        }

        private void button1_fifthClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            DialogResult result = fileDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = fileDlg.FileName;
            }
        }
    }
}

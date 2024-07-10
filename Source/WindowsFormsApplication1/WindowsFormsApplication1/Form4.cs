using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {

        String color;
        String tcolor;
        String bcolor;
        String xaxis;
        String yaxis;
        String title;
        String pallete;
        List<string> settings = new List<string>();

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            label8.BackColor = colorDialog1.Color;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label7.Text = System.Drawing.ColorTranslator.ToHtml(colorDialog1.Color).ToString();
            color = System.Drawing.ColorTranslator.ToHtml(colorDialog1.Color).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pallete = "bright";
                    break;
                case 1:
                    pallete = "pastel";
                    break;
                case 2:
                    pallete = "muted";
                    break;
                case 3:
                    pallete = "dark";
                    break;
                default:
                    pallete = "bright";
                    break;
            }
            xaxis = textBox1.Text;
            yaxis = textBox2.Text;
            title = textBox3.Text;
            if (colorDialog1.Color == System.Drawing.Color.Black)
            {
                settings.Add("black");
            }
            else
            {
                settings.Add(tcolor);
            }
            if (colorDialog1.Color == System.Drawing.Color.Black)
            {
                settings.Add("white");
            }
            else
            {
                settings.Add(bcolor);
            }
            if (colorDialog1.Color == System.Drawing.Color.Black)
            {
                settings.Add("white");
            }
            else
            {
                settings.Add(color);
            }
            settings.Add(xaxis);
            settings.Add(yaxis);
            settings.Add(title);
            settings.Add(pallete);
            settings.Add(numericUpDown1.Value.ToString());
            using (StreamWriter sw = new StreamWriter("settings.txt"))
            {
                foreach (string item in settings)
                {
                    sw.WriteLine(item);
                }
            }
            Process process = Process.Start(Form3.type+".exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            int id = process.Id;
            Process tempProc = Process.GetProcessById(id);
            tempProc.StartInfo.CreateNoWindow = true;
            tempProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            tempProc.WaitForExit();

                
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            label6.BackColor = colorDialog2.Color;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label5.Text = System.Drawing.ColorTranslator.ToHtml(colorDialog2.Color).ToString();
            tcolor = System.Drawing.ColorTranslator.ToHtml(colorDialog2.Color).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            label10.BackColor = colorDialog3.Color;
            label10.BorderStyle = BorderStyle.FixedSingle;
            label9.Text = System.Drawing.ColorTranslator.ToHtml(colorDialog3.Color).ToString();
            bcolor = System.Drawing.ColorTranslator.ToHtml(colorDialog3.Color).ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (Form3.type == "bar"){
            }
            else if (Form3.type == "line"){
            }
            else if (Form3.type == "scatter"){
            }
            else if (Form3.type == "pie")
            {
                groupBox9.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox6.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 fr = new Form3();
            this.Hide();
            fr.Show();
        }

    }
}
 
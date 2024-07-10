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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static String path;
        public static String readColumns;
        public static String type;
        List<string> columns = new List<string>();
        List<string> selectedColumns = new List<string>();

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.BackColor = Color.Gainsboro;
                label12.Text = "Za ovaj grafikon, prvo izaberite vrijednosti za x-osu (najčešće vrijeme), a drugo izaberite vrijednosti koje se mjenjaju";
                type = "line";
            }
            else
            {
                panel1.BackColor = Color.WhiteSmoke;
            }
            button1.Visible = true;
            textBox1.Visible = true;
            label10.Visible = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panel3.BackColor = Color.Gainsboro;
                label12.Text = "Za ovaj grafikon, prvo izaberite kolonu sa kategorijama za x-osu, a onda izaberite kolonu sa vrijednostima za te kategorije";
                type = "bar";
            }
            else
            {
                panel3.BackColor = Color.WhiteSmoke;
            }
            button1.Visible = true;
            textBox1.Visible = true;
            label10.Visible = true;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                panel4.BackColor = Color.Gainsboro;
                label12.Text = "Za ovaj grafikon, prvo izaberite kolonu vrijednosti za x-osu, pa onda izaberite kolonu vrijednosti.";
                type = "scatter";
            }
            else
            {
                panel4.BackColor = Color.WhiteSmoke;
            }
            button1.Visible = true;
            textBox1.Visible = true;
            label10.Visible = true;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                panel2.BackColor = Color.Gainsboro;
                label12.Text = "Za ovaj grafikon, prvo izaberite kolonu sa kategorijama, a onda izaberite kolonu sa vrijednostima za te kategorije";
                type = "pie";
            }
            else
            {
                panel2.BackColor = Color.WhiteSmoke;
            }
            button1.Visible = true;
            textBox1.Visible = true;
            label10.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            selectedColumns.Clear();
            columns.Clear();
            checkedListBox1.Items.Clear();
            path = openFileDialog1.FileName;
            using (StreamWriter sw = new StreamWriter("path.txt"))
            {
                sw.WriteLine(path);
            }
            Process process = Process.Start(@"main.exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            int id = process.Id;
            Process tempProc = Process.GetProcessById(id);
            tempProc.StartInfo.CreateNoWindow = true;
            tempProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            tempProc.WaitForExit();
            string line = "";
            using (StreamReader sr = new StreamReader("names.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    readColumns = line;
                }
            }
            columns = readColumns.Split(',').ToList();
            foreach (var l in columns)
            {
                if (l != "")
                {
                    checkedListBox1.Items.Add(l);
                }
            }
            
            textBox1.Text = path;
            label11.Visible = true;
            checkedListBox1.Visible = true;
            label12.Visible = true;
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (selectedColumns.Contains(checkedListBox1.SelectedItem.ToString()) == true)
            {
                selectedColumns.Remove(checkedListBox1.SelectedItem.ToString());
            }
            else
            {
                if (selectedColumns.Count >= 2)
                {
                    MessageBox.Show("Maksimalno izabrati 2 kolone");
                    checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex, CheckState.Unchecked);
                }
                else
                {
                    selectedColumns.Add(checkedListBox1.SelectedItem.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            using (StreamWriter sw = new StreamWriter("selected.txt"))
            {
                foreach (string item in selectedColumns)
                {
                    sw.WriteLine(item);
                }
            }
            Form4 fr = new Form4();
            this.Hide();
            fr.Show();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

    }
}

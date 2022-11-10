using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        Label[,] outFields;
        TextBox[] inFields;
        Panel[] panels;

        public Form1()
        {
            InitializeComponent();

            outFields = new Label[6, 11];
            inFields = new TextBox[11];
            panels = new Panel[] { alg1, alg2, alg3, tab1, tab2, tab3 };
            const int w = 62, h = 20, wm = 2, hm = 4;
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    outFields[i, j] = new Label
                    {
                        Text = "0",
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.White,
                        Name = i.ToString() + j.ToString() + "out",
                        AutoSize = false,
                        Width = w, Height = h,
                        Location = new Point(wm, hm + (h + hm) * j),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    panels[i].Controls.Add(outFields[i, j]);
                }
                outFields[i, 10].ForeColor = Color.Red;
            }

            for (int j = 0; j < 11; j++)
            {
                inFields[j] = new TextBox
                {
                    Text = "0",
                    MaxLength = 1,
                    BackColor = Color.White,
                    Name = j.ToString() + "in",
                    AutoSize = false,
                    //Width = w,
                    Width = 152,
                    Height = h,
                    Location = new Point(wm, hm + (h + hm) * j),
                };
                inp_panel.Controls.Add(inFields[j]);
            }
            inFields[10].ReadOnly = true;
            inFields[10].ForeColor = Color.Red;

            FillAll();
        }

        private void FillAll()
        {
            var r = new Random();
            IRndGen[] gen = new IRndGen[] { 
                new RndAlgGen(0, 10, r.Next()), new RndAlgGen(10, 100, r.Next()), new RndAlgGen(100, 1000, r.Next()),
                new RndTabGen(0, 10, "1.txt", r.Next()%10000), new RndTabGen(10, 100, "2.txt", r.Next()%10000), new RndTabGen(100, 1000, "3.txt", r.Next()%10000),
            };
            string[] fPathArr = { 
                "alg1.txt", "alg2.txt", "alg3.txt", 
                "tab1.txt", "tab2.txt", "tab3.txt" 
            };

            for (int i = 0; i < 6; i++)
            {
                int[] valArr = gen[i].RandArr(1000);
                WriteFile(fPathArr[i], valArr);
                for (int j = 0; j < 10; j++)
                    outFields[i, j].Text = valArr[j].ToString();

                var crt = new Crit(valArr);
                outFields[i, 10].Text = crt.Value(gen[i].MinN, gen[i].MaxN).ToString();
                Console.WriteLine(crt.Value(gen[i].MinN, gen[i].MaxN));
            }
        }

        private void WriteFile(string fpath, int[] arr)
        {
            using (StreamWriter sw = File.CreateText(fpath))
            {
                for (int i = 0; i < 1000; i++)
                    sw.WriteLine(arr[i]);
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] val = new int[10];
            for (int i = 0; i < 10; i++)
            {
                var inStr = inFields[i].Text;
                if (inStr.Length == 0) inStr = "0";
                val[i] = Convert.ToInt32(inStr);
            }

            var c = new Crit(val);
            inFields[10].Text = c.Value(0, 10).ToString();
        }

    private void button2_Click(object sender, EventArgs e)
    {
      FillAll();
    }
  }
}

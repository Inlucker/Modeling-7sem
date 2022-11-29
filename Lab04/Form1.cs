using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void DTButton_Click(object sender, EventArgs e)
		{
			DTButton.Enabled = false;

			string txt;
			double a, b;
			txt = aInp.Text.Replace(".", ",");
			a = Convert.ToDouble(txt);

			txt = bInp.Text.Replace(".", ",");
			b = Convert.ToDouble(txt);

			double l;
			int al;
			txt = aInp.Text.Replace(".", ",");
			l = Convert.ToDouble(txt);

			txt = bInp.Text.Replace(".", ",");
			al = Convert.ToInt32(Convert.ToDouble(txt));

			double fb;
			txt = pInp.Text.Replace(".", ",");
			fb = Convert.ToDouble(txt);

			DeltaTModel model = new DeltaTModel(a, b, l, al, fb);

			int res = model.getMaxBufSize();

			if (res == -1)
				lenOut.Text = "∞";
			else
				lenOut.Text = res.ToString();

			DTButton.Enabled = true;
		}

		private void EventButton_Click(object sender, EventArgs e)
		{
			EventButton.Enabled = false;

			string txt;
			double a, b;
			txt = aInp.Text.Replace(".", ",");
			a = Convert.ToDouble(txt);

			txt = bInp.Text.Replace(".", ",");
			b = Convert.ToDouble(txt);

			double l;
			int al;
			txt = aInp.Text.Replace(".", ",");
			l = Convert.ToDouble(txt);

			txt = bInp.Text.Replace(".", ",");
			al = Convert.ToInt32(Convert.ToDouble(txt));

			double fb;
			txt = pInp.Text.Replace(".", ",");
			fb = Convert.ToDouble(txt);

			EventModel model = new EventModel(a, b, l, al, fb);

			int res = model.getMaxBufSize();

			if (res == -1)
				lenOut.Text = "∞";
			else
				lenOut.Text = res.ToString();

			EventButton.Enabled = true;
		}

		private void label7_Click(object sender, EventArgs e)
		{

		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trigonometrie
{
	public partial class frmTrigonometrie : Form
	{
		private double a = 0;
		private double b = 0;
		private double c = 0;
		private double alpha = 0;
		private double beta = 0;
		private double gamma = 90;
		private System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrigonometrie));

		public frmTrigonometrie()
		{
			InitializeComponent();
		}

		private void frmTrigonometrie_Load(object sender, EventArgs e)
		{
			this.BackgroundImage = (System.Drawing.Image)(resources.GetObject("pbDreieck.Image"));
		}

		private void btnBerechnen_Click(object sender, EventArgs e)
		{
			if (!Fall1())
			{
				Fall2();
			}
		}

		private bool Fall1()
		{
			bool result = false;
			if (!(string.IsNullOrWhiteSpace(txtA.Text)) &&
				!(string.IsNullOrWhiteSpace(txtB.Text)))
			{
				berechneCfuerFall1();
				berechneAlphafuerFall1();
				berechneBetafuerFall1();
				result = true;
			}

			else if (!(string.IsNullOrWhiteSpace(txtC.Text)) &&
				!(string.IsNullOrWhiteSpace(txtB.Text)) &&
				(string.IsNullOrWhiteSpace(txtA.Text)))
			{
				berechneAfuerFall1();
				berechneAlphafuerFall1();
				berechneBetafuerFall1();
				result = true;
			}

			else if (!(string.IsNullOrWhiteSpace(txtC.Text)) &&
				!(string.IsNullOrWhiteSpace(txtA.Text)) &&
				(string.IsNullOrWhiteSpace(txtB.Text)))
			{
				berechneBfuerFall1();
				berechneAlphafuerFall1();
				berechneBetafuerFall1();
				result = true;
			}
			else if (((string.IsNullOrWhiteSpace(txtA.Text)) && (string.IsNullOrWhiteSpace(txtB.Text))) ||
				((string.IsNullOrWhiteSpace(txtB.Text)) && (string.IsNullOrWhiteSpace(txtC.Text))) ||
				((string.IsNullOrWhiteSpace(txtA.Text)) && (string.IsNullOrWhiteSpace(txtC.Text))))
			{
				result = false;
				
			}
			return result;
		}

		private void Fall2()
		{
			if (string.IsNullOrWhiteSpace(txtAlpha.Text) && !(string.IsNullOrWhiteSpace(txtBeta.Text))) 
			{
				berechneAlphafuerFall2();
				berechneSeiten();
			}

			else if (string.IsNullOrWhiteSpace(txtBeta.Text)&& !(string.IsNullOrWhiteSpace(txtAlpha.Text)))
			{
				berechneBetafuerFall2();
				berechneSeiten();
			}
			else
			{
				MessageBox.Show("Zooo nicht!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void berechneCfuerFall1()
		{
			a = double.Parse(txtA.Text);
			b = double.Parse(txtB.Text);

			c = machsPositiv(Math.Sqrt(a * a + b * b));
			txtC.Text = c.ToString();
		}

		private void berechneAfuerFall1()
		{
			c = double.Parse(txtC.Text);
			b = double.Parse(txtB.Text);

			a = machsPositiv(Math.Sqrt(c * c - b * b));
			txtA.Text = a.ToString();
		}

		private void berechneBfuerFall1()
		{
			a = double.Parse(txtA.Text);
			c = double.Parse(txtC.Text);

			b = machsPositiv(Math.Sqrt(c * c - a * a));
			txtB.Text = b.ToString();
		}
		private void berechneAlphafuerFall1()
		{
			a = double.Parse(txtA.Text);
			c = double.Parse(txtC.Text);

			alpha = machsPositiv(Math.Asin(a / c) * (360 / (2 * Math.PI)));
			txtAlpha.Text = alpha.ToString();
		}

		private void berechneBetafuerFall1()
		{
			b = double.Parse(txtB.Text);
			c = double.Parse(txtC.Text);

			beta = machsPositiv(Math.Asin(b / c) * (360 / (2 * Math.PI)));
			txtBeta.Text = beta.ToString();
		}

		private void berechneAlphafuerFall2()
		{
			beta = double.Parse(txtBeta.Text);

			alpha = gamma - beta;
			txtAlpha.Text = alpha.ToString();
		}

		private void berechneBetafuerFall2()
		{
			alpha = double.Parse(txtAlpha.Text);

			beta = gamma - alpha;
			txtBeta.Text = beta.ToString();

		}

		private void berechneSeiten()
		{
			if (!(string.IsNullOrWhiteSpace(txtA.Text)))
			{
				a = double.Parse(txtA.Text);

				b = machsPositiv(a / Math.Tan(alpha));
				txtB.Text = b.ToString();

				c = machsPositiv(a / Math.Sin(alpha));
				txtC.Text = c.ToString();
			}

			else if (!(string.IsNullOrWhiteSpace(txtB.Text)))
			{
				b = double.Parse(txtB.Text);

				a = machsPositiv(Math.Tan(alpha) * b);
				txtA.Text = a.ToString();

				c = machsPositiv(b / Math.Cos(alpha));
				txtC.Text = c.ToString();
			}

			else if (!(string.IsNullOrWhiteSpace(txtC.Text)))
			{
				c = double.Parse(txtC.Text);

				a = machsPositiv(Math.Sin(alpha) * c);
				txtA.Text = a.ToString();

				b = machsPositiv(Math.Cos(alpha) * c);
				txtB.Text = b.ToString();
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			txtA.Text = "";
			txtB.Text = "";
			txtC.Text = "";
			txtAlpha.Text = "";
			txtBeta.Text = "";

			a = 0;
			b = 0;
			c = 0;
			alpha = 0;
			beta = 0;
		}

		private double machsPositiv(double zahl)
		{
			return Math.Sqrt(zahl * zahl);
		}

	}
}


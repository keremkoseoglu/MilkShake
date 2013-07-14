using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MilkShakeTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components;

		private MilkShakeEngine.Engine en;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ProgressBar prog;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox4;
		private int tim;
		private ArrayList hist;
		private int unique;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.prog = new System.Windows.Forms.ProgressBar();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(136, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(336, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "May the source be with you";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(272, 112);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "MilkShake";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(136, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(336, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "textBox2";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(136, 80);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(336, 20);
			this.textBox3.TabIndex = 3;
			this.textBox3.Text = "textBox3";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(230, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = ".......";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(240, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(230, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = ".......";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(352, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "MultiMilkShake";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(230, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = ".......";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(240, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(230, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = ".......";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 24);
			this.label5.TabIndex = 9;
			this.label5.Text = "Plain Text";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 24);
			this.label6.TabIndex = 10;
			this.label6.Text = "Encrypted Text";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(120, 24);
			this.label7.TabIndex = 11;
			this.label7.Text = "Decrypted Text";
			// 
			// prog
			// 
			this.prog.Location = new System.Drawing.Point(8, 112);
			this.prog.Name = "prog";
			this.prog.Size = new System.Drawing.Size(256, 23);
			this.prog.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 24);
			this.label8.TabIndex = 13;
			this.label8.Text = "Key";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(136, 8);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(336, 20);
			this.textBox4.TabIndex = 14;
			this.textBox4.Text = "1029384756qpwoeurytalskdjfhgzmxncbv i";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 13);
			this.ClientSize = new System.Drawing.Size(480, 214);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.prog);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Milk Shake Verification Tool";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			label4.Text = "Elapsed time: 0 sec.";
			Application.DoEvents();

			encrypt();
		}

		private bool encrypt()
		{
			bool b = false;

			try
			{
				en = new MilkShakeEngine.Engine(textBox4.Text);
				textBox2.Text = en.encrypt(textBox1.Text);
				textBox3.Text = en.decrypt(textBox2.Text);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				b = false;
				return b;
			}

			label1.Text = "Input length: " + textBox1.Text.Length;
			label2.Text = "Encrypted length: " + textBox2.Text.Length;

			if (textBox1.Text == textBox3.Text)
			{
				label3.Text = "Verified";
				b = true;
			}
			else
			{
				label3.Text = "Problem detected";
			}

			Application.DoEvents();
			return b;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			bool u;

			tim = 0;
			label4.Text = "Elapsed time: 0 sec.";
			Application.DoEvents();
			timer1.Enabled = true;

			prog.Maximum = 1000;
			prog.Value = 0;

			unique = 0;
			hist = new ArrayList();

			for (int n = 1; n <= 1000; n++)
			{
				if (encrypt())
				{
					u = true;
					for (int x = 0; x < hist.Count; x++)
					{
						if (textBox2.Text == hist[x].ToString()) 
						{
							u = false;
							break;
						}
					}
					if (u)
					{
						unique++;
						hist.Add(textBox2.Text);
					}

					label3.Text += " " + n.ToString() + " times (" + unique.ToString() + " unique)";
					prog.Value++;
					Application.DoEvents();
				}
				else
				{
					return;
				}
			}

			timer1.Enabled = false;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			tim++;
			label4.Text = "Elapsed time: " + tim.ToString() + " sec.";
		}
	}
}

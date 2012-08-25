using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

public partial class Form1 : System.Windows.Forms.Form
{
	[System.Diagnostics.DebuggerNonUserCode()]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
		this.Button1.BackColor = System.Drawing.Color.Crimson;
		this.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
		this.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.Font = new System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold);
		this.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.Button1.Location = new System.Drawing.Point(12, 597);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 23);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Solve";
		this.Button1.UseVisualStyleBackColor = false;
		//
		//Panel1
		//
		this.Panel1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)));
		this.Panel1.Location = new System.Drawing.Point(13, 12);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(560, 560);
		this.Panel1.TabIndex = 1;
		//
		//Label1
		//
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Tahoma", 10.0F);
		this.Label1.ForeColor = System.Drawing.Color.Navy;
		this.Label1.Location = new System.Drawing.Point(10, 575);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(524, 17);
		this.Label1.TabIndex = 2;
		this.Label1.Text = "There are 92 total solutions using the BackTracking method,  12 of which are dist" + "inct";
		this.Label1.Visible = false;
		//
		//Form1
		//
		this.AutoScaleDimensions = new System.Drawing.SizeF((float)(6.0), (float)(13.0));
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Silver;
		this.ClientSize = new System.Drawing.Size(581, 625);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Eight Queens Problem";
		this.ResumeLayout(false);
		this.PerformLayout();

		Button1.Click += new System.EventHandler(Button1_Click);
		base.Load += new System.EventHandler(Form1_Load);

	}
	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.Panel Panel1;
	internal System.Windows.Forms.Label Label1;

}

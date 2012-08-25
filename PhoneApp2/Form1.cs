using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

public partial class Form1
{

	private ChessBoard cb = new ChessBoard();
	private int i;

	private void Form1_Load(object sender, System.EventArgs e)
	{
		this.Show();
		MessageBox.Show("Add 8 queens to the board so that no queen attacks the other");
		cb.Dock = DockStyle.Fill;
		cb.GetSolutions();
		Panel1.Controls.Add(cb);
		Button1.BringToFront();
	}

	private void Button1_Click(object sender, System.EventArgs e)
	{
		Label1.Visible = true;
		if (i < cb.Solutions.Count)
		{
			cb.Cells = cb.Solutions[i];
			cb.DrawBoard();
			i += 1;
		}
		else
		{
			i = 0;
		}
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tristram_Status
{
	public partial class startup : Form
	{
		public startup()
		{
			InitializeComponent();
			var tmr = new Timer();
			tmr.Interval = 1500;
			tmr.Tick += timerResponse;
			tmr.Start();

			this.ShowInTaskbar = false;
			
		}

		private void timerResponse( Object Sender, EventArgs e ) {
			
			((Timer)Sender).Stop();
			new SysTrayHandler();
			Visible = false;

		}

		private void beijeLogo_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.benjaminhorn.se");
		}

	}
}

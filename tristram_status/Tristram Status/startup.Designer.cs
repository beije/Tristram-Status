using System.Drawing;
namespace Tristram_Status
{
	partial class startup
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.animatedLogo = new System.Windows.Forms.PictureBox();
			this.beije_logo = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.animatedLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.beije_logo)).BeginInit();
			this.SuspendLayout();
			// 
			// animatedLogo
			// 
			this.animatedLogo.BackColor = System.Drawing.Color.Transparent;
			this.animatedLogo.Image = global::Tristram_Status.Properties.Resources.tristramlogo;
			this.animatedLogo.Location = new System.Drawing.Point(169, 27);
			this.animatedLogo.Name = "animatedLogo";
			this.animatedLogo.Size = new System.Drawing.Size(303, 171);
			this.animatedLogo.TabIndex = 0;
			this.animatedLogo.TabStop = false;
			// 
			// beije_logo
			// 
			this.beije_logo.BackColor = System.Drawing.Color.Transparent;
			this.beije_logo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.beije_logo.Image = global::Tristram_Status.Properties.Resources.beijelogo;
			this.beije_logo.Location = new System.Drawing.Point(13, 212);
			this.beije_logo.Name = "beije_logo";
			this.beije_logo.Size = new System.Drawing.Size(23, 30);
			this.beije_logo.TabIndex = 2;
			this.beije_logo.TabStop = false;
			this.beije_logo.Click += new System.EventHandler(this.beijeLogo_Click);
			// 
			// startup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Tristram_Status.Properties.Resources.tristram_loading;
			this.ClientSize = new System.Drawing.Size(640, 251);
			this.Controls.Add(this.beije_logo);
			this.Controls.Add(this.animatedLogo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "startup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Status";
			((System.ComponentModel.ISupportInitialize)(this.animatedLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.beije_logo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.PictureBox animatedLogo;
		private System.Windows.Forms.PictureBox beije_logo;




	}
}


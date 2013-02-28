using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Tristram_Status
{
	public partial class SysTrayHandler : Form
	{
		private NotifyIcon trayIcon;
		private ContextMenu trayMenu;
		private Timer updateTimer;
		private Label eventTitle;
		private PictureBox hideNotification;
		private Label dateLabel;
		private DataHandler dh;
		private Update currentUpdate;

		private Timer animator;
		private Button view_profile;
		private double animatorCounter = 0;


		public SysTrayHandler() {
			InitializeComponent();

			this.dh = new DataHandler();
			this.TransparencyKey = Color.Turquoise;
			this.BackColor = Color.Turquoise;
			trayMenu = new ContextMenu();
			trayMenu.MenuItems.Add("Quit Tristram App", onExit);
			
			Icon theIcon = new Icon( System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Tristram_Status.Resources.tristram_icon.ico") );
			
			trayIcon = new NotifyIcon();
			trayIcon.Text = "Tristram Status";
			trayIcon.Icon = theIcon;

			trayIcon.ContextMenu = trayMenu;
			trayIcon.Visible = true;
			trayIcon.ShowBalloonTip(5000, "Tristram status", "Application is now running", ToolTipIcon.Info);
			
			Visible = true;
			int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
			int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
			this.SetDesktopLocation(x, y);

			// Animation timer
			this.animator = new Timer();
			this.animator.Interval = 20;
			this.animator.Tick += animate;
		}

		private Boolean toggleNotification( Boolean show = false ) {
			if( show == true ) {
				int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
				int y = Screen.PrimaryScreen.WorkingArea.Height;

				this.Visible = true;
					
				this.animatorCounter = 0;
				this.animator.Start();
			} else {
				this.Visible = false;
			}

			return this.Visible;
		}

		private void animate( Object Sender, EventArgs e ) {
			int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
			int y = Screen.PrimaryScreen.WorkingArea.Height;
			
			int endLocation = this.Height;
			int newPosition = (int) Math.Round( Math.Sin( this.animatorCounter / 20 ) * endLocation );
			
			this.Location = new Point(x, y - newPosition);
			
			if( newPosition + 5 >= endLocation ) {
				this.Location = new Point( x, y - this.Height );
				this.animatorCounter = 0;
				this.animator.Stop();
			} else {
				this.animatorCounter++;
			}
		}

		private void populateForm( Update upd ) {
			this.currentUpdate = upd;
			var date = upd.getHumanDate();

			this.dateLabel.Text = upd.getTextualDate();
			this.view_profile.MouseClick -= this.navigateToUrl;
			this.view_profile.MouseClick += this.navigateToUrl;
			this.eventTitle.Text = upd.message;
			this.toggleNotification( true );

		}
		public void navigateToUrl( Object Sender, EventArgs e ){
			System.Diagnostics.Process.Start( this.currentUpdate.userinfo.profileurl );

		}
		protected override void OnLoad(EventArgs e)
		{
			
			this.TopMost = true;
			this.updateTimer = new Timer();
			this.updateTimer.Interval = 10000;
			this.updateTimer.Tick += poller;
			this.updateTimer.Start();

			Visible = false;
			ShowInTaskbar = false;


			this.hideNotification.MouseEnter += setCloseActive;
			this.hideNotification.MouseLeave += setCloseInactive;

			this.view_profile.MouseEnter += buttonActiveBackground;
			this.view_profile.MouseLeave += buttonInactiveBackground;

			base.OnLoad(e);
		}
		private void poller( Object sender, EventArgs e ) {
			var upds = this.dh.getUpdates();
			
			if (upds.Count != 0 ) {
				this.populateForm( upds[0] );
			} else {
				this.toggleNotification(false);
			}
		}
		private void onExit( Object sender, EventArgs e) {
			Application.Exit();
		}

		protected override void Dispose(bool isDisposing) {
			if (isDisposing) 
			{
				trayIcon.Dispose();
			}
			base.Dispose(isDisposing);
		}

		private void InitializeComponent()
		{
			this.eventTitle = new System.Windows.Forms.Label();
			this.hideNotification = new System.Windows.Forms.PictureBox();
			this.dateLabel = new System.Windows.Forms.Label();
			this.view_profile = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.hideNotification)).BeginInit();
			this.SuspendLayout();
			// 
			// eventTitle
			// 
			this.eventTitle.BackColor = System.Drawing.Color.Transparent;
			this.eventTitle.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.eventTitle.ForeColor = System.Drawing.Color.White;
			this.eventTitle.Location = new System.Drawing.Point(26, 78);
			this.eventTitle.Name = "eventTitle";
			this.eventTitle.Size = new System.Drawing.Size(231, 138);
			this.eventTitle.TabIndex = 0;
			this.eventTitle.Text = "eventTitle";
			// 
			// hideNotification
			// 
			this.hideNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hideNotification.BackColor = System.Drawing.Color.Transparent;
			this.hideNotification.Cursor = System.Windows.Forms.Cursors.Hand;
			this.hideNotification.Image = global::Tristram_Status.Properties.Resources.closeInactive;
			this.hideNotification.Location = new System.Drawing.Point(263, 4);
			this.hideNotification.Margin = new System.Windows.Forms.Padding(1);
			this.hideNotification.Name = "hideNotification";
			this.hideNotification.Padding = new System.Windows.Forms.Padding(1);
			this.hideNotification.Size = new System.Drawing.Size(19, 19);
			this.hideNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.hideNotification.TabIndex = 1;
			this.hideNotification.TabStop = false;
			this.hideNotification.Click += new System.EventHandler(this.hideNotification_Click);
			// 
			// dateLabel
			// 
			this.dateLabel.AutoSize = true;
			this.dateLabel.BackColor = System.Drawing.Color.Transparent;
			this.dateLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.dateLabel.Location = new System.Drawing.Point(28, 216);
			this.dateLabel.Name = "dateLabel";
			this.dateLabel.Size = new System.Drawing.Size(35, 13);
			this.dateLabel.TabIndex = 2;
			this.dateLabel.Text = "label1";
			// 
			// view_profile
			// 
			this.view_profile.BackColor = System.Drawing.Color.Transparent;
			this.view_profile.BackgroundImage = global::Tristram_Status.Properties.Resources.button_inactive;
			this.view_profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.view_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.view_profile.Location = new System.Drawing.Point(27, 234);
			this.view_profile.Name = "view_profile";
			this.view_profile.Size = new System.Drawing.Size(232, 78);
			this.view_profile.TabIndex = 4;
			this.view_profile.UseVisualStyleBackColor = false;
			// 
			// SysTrayHandler
			// 
			this.BackgroundImage = global::Tristram_Status.Properties.Resources.background;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(287, 339);
			this.Controls.Add(this.view_profile);
			this.Controls.Add(this.dateLabel);
			this.Controls.Add(this.hideNotification);
			this.Controls.Add(this.eventTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SysTrayHandler";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Status";
			((System.ComponentModel.ISupportInitialize)(this.hideNotification)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private void setCloseActive(Object Sender, EventArgs e) 
		{
			this.hideNotification.Image = global::Tristram_Status.Properties.Resources.closeActive;
		}
		private void setCloseInactive(Object Sender, EventArgs e)
		{
			this.hideNotification.Image = global::Tristram_Status.Properties.Resources.closeInactive;
		}

		private void buttonInactiveBackground(Object Sender, EventArgs e)
		{
			this.view_profile.BackgroundImage = global::Tristram_Status.Properties.Resources.button_inactive;
		}

		private void buttonActiveBackground( Object Sender, EventArgs e ) {
			this.view_profile.BackgroundImage = global::Tristram_Status.Properties.Resources.profilebutton_active;
		}

		private void hideNotification_Click(object sender, EventArgs e)
		{
			this.toggleNotification( false );
		}



	}
}

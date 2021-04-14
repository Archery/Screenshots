
namespace TitlesForCasinos {
    partial class FCasinos {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCasinos));
            this.llDomain = new System.Windows.Forms.LinkLabel();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miReport = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewList = new System.Windows.Forms.ToolStripMenuItem();
            this.micbTransparent = new System.Windows.Forms.ToolStripComboBox();
            this.gbDesktop = new System.Windows.Forms.GroupBox();
            this.bDesktop12 = new System.Windows.Forms.Button();
            this.bDesktop11 = new System.Windows.Forms.Button();
            this.bDesktop10 = new System.Windows.Forms.Button();
            this.bDesktop9 = new System.Windows.Forms.Button();
            this.bDesktop8 = new System.Windows.Forms.Button();
            this.bDesktop7 = new System.Windows.Forms.Button();
            this.bDesktop6 = new System.Windows.Forms.Button();
            this.bDesktop5 = new System.Windows.Forms.Button();
            this.bDesktop4 = new System.Windows.Forms.Button();
            this.bDesktop3 = new System.Windows.Forms.Button();
            this.bDesktop2 = new System.Windows.Forms.Button();
            this.bDesktop1 = new System.Windows.Forms.Button();
            this.gbMobile = new System.Windows.Forms.GroupBox();
            this.bMobile12 = new System.Windows.Forms.Button();
            this.bMobile11 = new System.Windows.Forms.Button();
            this.bMobile9 = new System.Windows.Forms.Button();
            this.bMobile8 = new System.Windows.Forms.Button();
            this.bMobile6 = new System.Windows.Forms.Button();
            this.bMobile10 = new System.Windows.Forms.Button();
            this.bMobile7 = new System.Windows.Forms.Button();
            this.bMobile5 = new System.Windows.Forms.Button();
            this.bMobile4 = new System.Windows.Forms.Button();
            this.bMobile3 = new System.Windows.Forms.Button();
            this.bMobile2 = new System.Windows.Forms.Button();
            this.bMobile1 = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cMenu.SuspendLayout();
            this.gbDesktop.SuspendLayout();
            this.gbMobile.SuspendLayout();
            this.SuspendLayout();
            // 
            // llDomain
            // 
            this.llDomain.ContextMenuStrip = this.cMenu;
            this.llDomain.Dock = System.Windows.Forms.DockStyle.Top;
            this.llDomain.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.llDomain.LinkColor = System.Drawing.Color.Green;
            this.llDomain.Location = new System.Drawing.Point(0, 0);
            this.llDomain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llDomain.Name = "llDomain";
            this.llDomain.Size = new System.Drawing.Size(540, 35);
            this.llDomain.TabIndex = 0;
            this.llDomain.TabStop = true;
            this.llDomain.Text = "linkLabel1";
            this.llDomain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llDomain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDomain_LinkClicked);
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miReport,
            this.miNewList,
            this.micbTransparent});
            this.cMenu.Name = "cMenu";
            this.cMenu.ShowCheckMargin = true;
            this.cMenu.Size = new System.Drawing.Size(204, 75);
            // 
            // miReport
            // 
            this.miReport.Name = "miReport";
            this.miReport.Size = new System.Drawing.Size(203, 22);
            this.miReport.Text = "Report";
            this.miReport.Click += new System.EventHandler(this.miReport_Click);
            // 
            // miNewList
            // 
            this.miNewList.Name = "miNewList";
            this.miNewList.Size = new System.Drawing.Size(203, 22);
            this.miNewList.Text = "Open domains file";
            this.miNewList.Click += new System.EventHandler(this.miNewList_Click);
            // 
            // micbTransparent
            // 
            this.micbTransparent.Items.AddRange(new object[] {
            "100%",
            "75%",
            "50%",
            "25%",
            "5%"});
            this.micbTransparent.Name = "micbTransparent";
            this.micbTransparent.Size = new System.Drawing.Size(121, 23);
            this.micbTransparent.Text = "Transparent";
            this.micbTransparent.SelectedIndexChanged += new System.EventHandler(this.micbTransparent_SelectedIndexChanged);
            // 
            // gbDesktop
            // 
            this.gbDesktop.ContextMenuStrip = this.cMenu;
            this.gbDesktop.Controls.Add(this.bDesktop12);
            this.gbDesktop.Controls.Add(this.bDesktop11);
            this.gbDesktop.Controls.Add(this.bDesktop10);
            this.gbDesktop.Controls.Add(this.bDesktop9);
            this.gbDesktop.Controls.Add(this.bDesktop8);
            this.gbDesktop.Controls.Add(this.bDesktop7);
            this.gbDesktop.Controls.Add(this.bDesktop6);
            this.gbDesktop.Controls.Add(this.bDesktop5);
            this.gbDesktop.Controls.Add(this.bDesktop4);
            this.gbDesktop.Controls.Add(this.bDesktop3);
            this.gbDesktop.Controls.Add(this.bDesktop2);
            this.gbDesktop.Controls.Add(this.bDesktop1);
            this.gbDesktop.Location = new System.Drawing.Point(17, 53);
            this.gbDesktop.Margin = new System.Windows.Forms.Padding(4);
            this.gbDesktop.Name = "gbDesktop";
            this.gbDesktop.Padding = new System.Windows.Forms.Padding(4);
            this.gbDesktop.Size = new System.Drawing.Size(236, 573);
            this.gbDesktop.TabIndex = 1;
            this.gbDesktop.TabStop = false;
            // 
            // bDesktop12
            // 
            this.bDesktop12.Location = new System.Drawing.Point(9, 524);
            this.bDesktop12.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop12.Name = "bDesktop12";
            this.bDesktop12.Size = new System.Drawing.Size(219, 32);
            this.bDesktop12.TabIndex = 11;
            this.bDesktop12.Text = "button13";
            this.bDesktop12.UseVisualStyleBackColor = true;
            // 
            // bDesktop11
            // 
            this.bDesktop11.Location = new System.Drawing.Point(9, 479);
            this.bDesktop11.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop11.Name = "bDesktop11";
            this.bDesktop11.Size = new System.Drawing.Size(219, 32);
            this.bDesktop11.TabIndex = 10;
            this.bDesktop11.Text = "button14";
            this.bDesktop11.UseVisualStyleBackColor = true;
            // 
            // bDesktop10
            // 
            this.bDesktop10.Location = new System.Drawing.Point(9, 434);
            this.bDesktop10.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop10.Name = "bDesktop10";
            this.bDesktop10.Size = new System.Drawing.Size(219, 32);
            this.bDesktop10.TabIndex = 9;
            this.bDesktop10.Text = "button15";
            this.bDesktop10.UseVisualStyleBackColor = true;
            // 
            // bDesktop9
            // 
            this.bDesktop9.Location = new System.Drawing.Point(9, 389);
            this.bDesktop9.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop9.Name = "bDesktop9";
            this.bDesktop9.Size = new System.Drawing.Size(219, 32);
            this.bDesktop9.TabIndex = 8;
            this.bDesktop9.Text = "button16";
            this.bDesktop9.UseVisualStyleBackColor = true;
            // 
            // bDesktop8
            // 
            this.bDesktop8.Location = new System.Drawing.Point(9, 344);
            this.bDesktop8.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop8.Name = "bDesktop8";
            this.bDesktop8.Size = new System.Drawing.Size(219, 32);
            this.bDesktop8.TabIndex = 7;
            this.bDesktop8.Text = "button17";
            this.bDesktop8.UseVisualStyleBackColor = true;
            // 
            // bDesktop7
            // 
            this.bDesktop7.Location = new System.Drawing.Point(9, 300);
            this.bDesktop7.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop7.Name = "bDesktop7";
            this.bDesktop7.Size = new System.Drawing.Size(219, 32);
            this.bDesktop7.TabIndex = 6;
            this.bDesktop7.Text = "button18";
            this.bDesktop7.UseVisualStyleBackColor = true;
            // 
            // bDesktop6
            // 
            this.bDesktop6.Location = new System.Drawing.Point(9, 255);
            this.bDesktop6.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop6.Name = "bDesktop6";
            this.bDesktop6.Size = new System.Drawing.Size(219, 32);
            this.bDesktop6.TabIndex = 5;
            this.bDesktop6.Text = "button6";
            this.bDesktop6.UseVisualStyleBackColor = true;
            // 
            // bDesktop5
            // 
            this.bDesktop5.Location = new System.Drawing.Point(9, 210);
            this.bDesktop5.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop5.Name = "bDesktop5";
            this.bDesktop5.Size = new System.Drawing.Size(219, 32);
            this.bDesktop5.TabIndex = 4;
            this.bDesktop5.Text = "button5";
            this.bDesktop5.UseVisualStyleBackColor = true;
            // 
            // bDesktop4
            // 
            this.bDesktop4.Location = new System.Drawing.Point(9, 165);
            this.bDesktop4.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop4.Name = "bDesktop4";
            this.bDesktop4.Size = new System.Drawing.Size(219, 32);
            this.bDesktop4.TabIndex = 3;
            this.bDesktop4.Text = "button4";
            this.bDesktop4.UseVisualStyleBackColor = true;
            // 
            // bDesktop3
            // 
            this.bDesktop3.Location = new System.Drawing.Point(9, 120);
            this.bDesktop3.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop3.Name = "bDesktop3";
            this.bDesktop3.Size = new System.Drawing.Size(219, 32);
            this.bDesktop3.TabIndex = 2;
            this.bDesktop3.Text = "button3";
            this.bDesktop3.UseVisualStyleBackColor = true;
            this.bDesktop3.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bDesktop2
            // 
            this.bDesktop2.Location = new System.Drawing.Point(9, 76);
            this.bDesktop2.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop2.Name = "bDesktop2";
            this.bDesktop2.Size = new System.Drawing.Size(219, 32);
            this.bDesktop2.TabIndex = 1;
            this.bDesktop2.Text = "button2";
            this.bDesktop2.UseVisualStyleBackColor = true;
            this.bDesktop2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // bDesktop1
            // 
            this.bDesktop1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bDesktop1.Image = ((System.Drawing.Image)(resources.GetObject("bDesktop1.Image")));
            this.bDesktop1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDesktop1.Location = new System.Drawing.Point(9, 31);
            this.bDesktop1.Margin = new System.Windows.Forms.Padding(4);
            this.bDesktop1.Name = "bDesktop1";
            this.bDesktop1.Size = new System.Drawing.Size(219, 32);
            this.bDesktop1.TabIndex = 0;
            this.bDesktop1.Text = "button1";
            this.bDesktop1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bDesktop1.UseVisualStyleBackColor = true;
            this.bDesktop1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // gbMobile
            // 
            this.gbMobile.ContextMenuStrip = this.cMenu;
            this.gbMobile.Controls.Add(this.bMobile12);
            this.gbMobile.Controls.Add(this.bMobile11);
            this.gbMobile.Controls.Add(this.bMobile9);
            this.gbMobile.Controls.Add(this.bMobile8);
            this.gbMobile.Controls.Add(this.bMobile6);
            this.gbMobile.Controls.Add(this.bMobile10);
            this.gbMobile.Controls.Add(this.bMobile7);
            this.gbMobile.Controls.Add(this.bMobile5);
            this.gbMobile.Controls.Add(this.bMobile4);
            this.gbMobile.Controls.Add(this.bMobile3);
            this.gbMobile.Controls.Add(this.bMobile2);
            this.gbMobile.Controls.Add(this.bMobile1);
            this.gbMobile.Location = new System.Drawing.Point(291, 53);
            this.gbMobile.Margin = new System.Windows.Forms.Padding(4);
            this.gbMobile.Name = "gbMobile";
            this.gbMobile.Padding = new System.Windows.Forms.Padding(4);
            this.gbMobile.Size = new System.Drawing.Size(236, 573);
            this.gbMobile.TabIndex = 6;
            this.gbMobile.TabStop = false;
            this.gbMobile.Text = "mobile_";
            // 
            // bMobile12
            // 
            this.bMobile12.Location = new System.Drawing.Point(9, 524);
            this.bMobile12.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile12.Name = "bMobile12";
            this.bMobile12.Size = new System.Drawing.Size(219, 32);
            this.bMobile12.TabIndex = 17;
            this.bMobile12.Text = "button19";
            this.bMobile12.UseVisualStyleBackColor = true;
            // 
            // bMobile11
            // 
            this.bMobile11.Location = new System.Drawing.Point(9, 479);
            this.bMobile11.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile11.Name = "bMobile11";
            this.bMobile11.Size = new System.Drawing.Size(219, 32);
            this.bMobile11.TabIndex = 16;
            this.bMobile11.Text = "button20";
            this.bMobile11.UseVisualStyleBackColor = true;
            // 
            // bMobile9
            // 
            this.bMobile9.Location = new System.Drawing.Point(9, 389);
            this.bMobile9.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile9.Name = "bMobile9";
            this.bMobile9.Size = new System.Drawing.Size(219, 32);
            this.bMobile9.TabIndex = 15;
            this.bMobile9.Text = "button21";
            this.bMobile9.UseVisualStyleBackColor = true;
            // 
            // bMobile8
            // 
            this.bMobile8.Location = new System.Drawing.Point(9, 344);
            this.bMobile8.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile8.Name = "bMobile8";
            this.bMobile8.Size = new System.Drawing.Size(219, 32);
            this.bMobile8.TabIndex = 14;
            this.bMobile8.Text = "button22";
            this.bMobile8.UseVisualStyleBackColor = true;
            // 
            // bMobile6
            // 
            this.bMobile6.Location = new System.Drawing.Point(9, 255);
            this.bMobile6.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile6.Name = "bMobile6";
            this.bMobile6.Size = new System.Drawing.Size(219, 32);
            this.bMobile6.TabIndex = 13;
            this.bMobile6.Text = "button23";
            this.bMobile6.UseVisualStyleBackColor = true;
            // 
            // bMobile10
            // 
            this.bMobile10.Location = new System.Drawing.Point(9, 434);
            this.bMobile10.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile10.Name = "bMobile10";
            this.bMobile10.Size = new System.Drawing.Size(219, 32);
            this.bMobile10.TabIndex = 12;
            this.bMobile10.Text = "button24";
            this.bMobile10.UseVisualStyleBackColor = true;
            // 
            // bMobile7
            // 
            this.bMobile7.Location = new System.Drawing.Point(9, 300);
            this.bMobile7.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile7.Name = "bMobile7";
            this.bMobile7.Size = new System.Drawing.Size(219, 32);
            this.bMobile7.TabIndex = 5;
            this.bMobile7.Text = "button7";
            this.bMobile7.UseVisualStyleBackColor = true;
            // 
            // bMobile5
            // 
            this.bMobile5.Location = new System.Drawing.Point(9, 210);
            this.bMobile5.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile5.Name = "bMobile5";
            this.bMobile5.Size = new System.Drawing.Size(219, 32);
            this.bMobile5.TabIndex = 4;
            this.bMobile5.Text = "button8";
            this.bMobile5.UseVisualStyleBackColor = true;
            // 
            // bMobile4
            // 
            this.bMobile4.Location = new System.Drawing.Point(9, 165);
            this.bMobile4.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile4.Name = "bMobile4";
            this.bMobile4.Size = new System.Drawing.Size(219, 32);
            this.bMobile4.TabIndex = 3;
            this.bMobile4.Text = "button9";
            this.bMobile4.UseVisualStyleBackColor = true;
            // 
            // bMobile3
            // 
            this.bMobile3.Location = new System.Drawing.Point(9, 120);
            this.bMobile3.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile3.Name = "bMobile3";
            this.bMobile3.Size = new System.Drawing.Size(219, 32);
            this.bMobile3.TabIndex = 2;
            this.bMobile3.Text = "button10";
            this.bMobile3.UseVisualStyleBackColor = true;
            // 
            // bMobile2
            // 
            this.bMobile2.Location = new System.Drawing.Point(9, 76);
            this.bMobile2.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile2.Name = "bMobile2";
            this.bMobile2.Size = new System.Drawing.Size(219, 32);
            this.bMobile2.TabIndex = 1;
            this.bMobile2.Text = "button11";
            this.bMobile2.UseVisualStyleBackColor = true;
            // 
            // bMobile1
            // 
            this.bMobile1.Location = new System.Drawing.Point(9, 31);
            this.bMobile1.Margin = new System.Windows.Forms.Padding(4);
            this.bMobile1.Name = "bMobile1";
            this.bMobile1.Size = new System.Drawing.Size(219, 32);
            this.bMobile1.TabIndex = 0;
            this.bMobile1.Text = "button12";
            this.bMobile1.UseVisualStyleBackColor = true;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.ContextMenuStrip = this.cMenu;
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 646);
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.ScaleScrollBarForDpiChange = false;
            this.hScrollBar1.Size = new System.Drawing.Size(540, 28);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Value = 1;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // FCasinos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(540, 674);
            this.ContextMenuStrip = this.cMenu;
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.gbMobile);
            this.Controls.Add(this.gbDesktop);
            this.Controls.Add(this.llDomain);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FCasinos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Casino Screenshots";
            this.cMenu.ResumeLayout(false);
            this.gbDesktop.ResumeLayout(false);
            this.gbMobile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel llDomain;
        private System.Windows.Forms.GroupBox gbDesktop;
        private System.Windows.Forms.Button bDesktop12;
        private System.Windows.Forms.Button bDesktop11;
        private System.Windows.Forms.Button bDesktop10;
        private System.Windows.Forms.Button bDesktop9;
        private System.Windows.Forms.Button bDesktop8;
        private System.Windows.Forms.Button bDesktop7;
        private System.Windows.Forms.Button bDesktop6;
        private System.Windows.Forms.Button bDesktop5;
        private System.Windows.Forms.Button bDesktop4;
        private System.Windows.Forms.Button bDesktop3;
        private System.Windows.Forms.Button bDesktop2;
        private System.Windows.Forms.Button bDesktop1;
        private System.Windows.Forms.GroupBox gbMobile;
        private System.Windows.Forms.Button bMobile12;
        private System.Windows.Forms.Button bMobile11;
        private System.Windows.Forms.Button bMobile9;
        private System.Windows.Forms.Button bMobile8;
        private System.Windows.Forms.Button bMobile6;
        private System.Windows.Forms.Button bMobile10;
        private System.Windows.Forms.Button bMobile7;
        private System.Windows.Forms.Button bMobile5;
        private System.Windows.Forms.Button bMobile4;
        private System.Windows.Forms.Button bMobile3;
        private System.Windows.Forms.Button bMobile2;
        private System.Windows.Forms.Button bMobile1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem miReport;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem miNewList;
        private System.Windows.Forms.ToolStripComboBox micbTransparent;
    }
}


namespace thebestestgame
{
    partial class CAMTHEMAN
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.titlelabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.gameScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // titlelabel
            // 
            this.titlelabel.Font = new System.Drawing.Font("Ravie", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titlelabel.Location = new System.Drawing.Point(220, 9);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(305, 70);
            this.titlelabel.TabIndex = 0;
            this.titlelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Font = new System.Drawing.Font("Ravie", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.White;
            this.subtitleLabel.Location = new System.Drawing.Point(225, 212);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(300, 102);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameScore
            // 
            this.gameScore.BackColor = System.Drawing.Color.Transparent;
            this.gameScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gameScore.Location = new System.Drawing.Point(687, 2);
            this.gameScore.Name = "gameScore";
            this.gameScore.Size = new System.Drawing.Size(113, 34);
            this.gameScore.TabIndex = 2;
            // 
            // CAMTHEMAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.gameScore);
            this.Controls.Add(this.titlelabel);
            this.DoubleBuffered = true;
            this.Name = "CAMTHEMAN";
            this.Text = "CAMTHEMAN";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CAMTHEMAN_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CAMTHEMAN_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CAMTHEMAN_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label gameScore;
    }
}


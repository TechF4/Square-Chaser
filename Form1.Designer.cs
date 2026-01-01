namespace Square_Chaser
{
    partial class Form1
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
            this.playerTimers = new System.Windows.Forms.Timer(this.components);
            this.targetTimer = new System.Windows.Forms.Timer(this.components);
            this.p1scoreLabel = new System.Windows.Forms.Label();
            this.p2scoreLabel = new System.Windows.Forms.Label();
            this.winningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerTimers
            // 
            this.playerTimers.Enabled = true;
            this.playerTimers.Interval = 200;
            this.playerTimers.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // targetTimer
            // 
            this.targetTimer.Enabled = true;
            this.targetTimer.Interval = 10;
            this.targetTimer.Tick += new System.EventHandler(this.targetTimer_Tick);
            // 
            // p1scoreLabel
            // 
            this.p1scoreLabel.Font = new System.Drawing.Font("Ravie", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p1scoreLabel.Location = new System.Drawing.Point(0, 9);
            this.p1scoreLabel.Name = "p1scoreLabel";
            this.p1scoreLabel.Size = new System.Drawing.Size(373, 65);
            this.p1scoreLabel.TabIndex = 0;
            this.p1scoreLabel.Text = "Player 1 Score: 0";
            // 
            // p2scoreLabel
            // 
            this.p2scoreLabel.Font = new System.Drawing.Font("Ravie", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2scoreLabel.Location = new System.Drawing.Point(0, 74);
            this.p2scoreLabel.Name = "p2scoreLabel";
            this.p2scoreLabel.Size = new System.Drawing.Size(373, 65);
            this.p2scoreLabel.TabIndex = 1;
            this.p2scoreLabel.Text = "Player 2 Score: 0";
            // 
            // winningLabel
            // 
            this.winningLabel.Font = new System.Drawing.Font("Ravie", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winningLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.winningLabel.Location = new System.Drawing.Point(12, 243);
            this.winningLabel.Name = "winningLabel";
            this.winningLabel.Size = new System.Drawing.Size(792, 175);
            this.winningLabel.TabIndex = 2;
            this.winningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.winningLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(822, 653);
            this.Controls.Add(this.winningLabel);
            this.Controls.Add(this.p2scoreLabel);
            this.Controls.Add(this.p1scoreLabel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer playerTimers;
        private System.Windows.Forms.Timer targetTimer;
        private System.Windows.Forms.Label p1scoreLabel;
        private System.Windows.Forms.Label p2scoreLabel;
        private System.Windows.Forms.Label winningLabel;
    }
}


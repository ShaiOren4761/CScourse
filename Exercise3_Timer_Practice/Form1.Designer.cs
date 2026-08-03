namespace Exercise3_Timer_Practice
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
            this.rightBtn = new System.Windows.Forms.Button();
            this.fasterBtn = new System.Windows.Forms.Button();
            this.randomBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.clickable_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rightBtn
            // 
            this.rightBtn.Location = new System.Drawing.Point(240, 65);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(75, 23);
            this.rightBtn.TabIndex = 1;
            this.rightBtn.Text = ">>";
            this.rightBtn.UseVisualStyleBackColor = true;
            this.rightBtn.Click += new System.EventHandler(this.rightBtn_Click);
            // 
            // fasterBtn
            // 
            this.fasterBtn.Location = new System.Drawing.Point(407, 65);
            this.fasterBtn.Name = "fasterBtn";
            this.fasterBtn.Size = new System.Drawing.Size(75, 23);
            this.fasterBtn.TabIndex = 2;
            this.fasterBtn.Text = "faster";
            this.fasterBtn.UseVisualStyleBackColor = true;
            this.fasterBtn.Click += new System.EventHandler(this.fasterBtn_Click);
            // 
            // randomBtn
            // 
            this.randomBtn.Location = new System.Drawing.Point(326, 65);
            this.randomBtn.Name = "randomBtn";
            this.randomBtn.Size = new System.Drawing.Size(75, 23);
            this.randomBtn.TabIndex = 3;
            this.randomBtn.Text = "random";
            this.randomBtn.UseVisualStyleBackColor = true;
            this.randomBtn.Click += new System.EventHandler(this.randomBtn_Click);
            // 
            // leftBtn
            // 
            this.leftBtn.Location = new System.Drawing.Point(159, 65);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(75, 23);
            this.leftBtn.TabIndex = 4;
            this.leftBtn.Text = "<<";
            this.leftBtn.UseVisualStyleBackColor = true;
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            // 
            // clickable_label
            // 
            this.clickable_label.AutoSize = true;
            this.clickable_label.Location = new System.Drawing.Point(294, 35);
            this.clickable_label.Name = "clickable_label";
            this.clickable_label.Size = new System.Drawing.Size(14, 16);
            this.clickable_label.TabIndex = 5;
            this.clickable_label.Text = "0";
            this.clickable_label.Click += new System.EventHandler(this.clickable_label_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLICK ME!!!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clickable_label);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.randomBtn);
            this.Controls.Add(this.fasterBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.Button fasterBtn;
        private System.Windows.Forms.Button randomBtn;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.Label clickable_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}


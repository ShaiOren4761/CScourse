namespace Exercise3_Dynamic_Button_Creation
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
            this.label_Counter = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.radiobutton_blue = new System.Windows.Forms.RadioButton();
            this.radiobutton_red = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_moveCopy = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_Counter
            // 
            this.label_Counter.AutoSize = true;
            this.label_Counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Counter.Location = new System.Drawing.Point(378, 81);
            this.label_Counter.Name = "label_Counter";
            this.label_Counter.Size = new System.Drawing.Size(49, 54);
            this.label_Counter.TabIndex = 0;
            this.label_Counter.Text = "0";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(339, 149);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(121, 35);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start Counter";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(339, 192);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(121, 35);
            this.copyBtn.TabIndex = 2;
            this.copyBtn.Text = "Copy Counter";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // radiobutton_blue
            // 
            this.radiobutton_blue.AutoSize = true;
            this.radiobutton_blue.Location = new System.Drawing.Point(483, 245);
            this.radiobutton_blue.Name = "radiobutton_blue";
            this.radiobutton_blue.Size = new System.Drawing.Size(55, 20);
            this.radiobutton_blue.TabIndex = 3;
            this.radiobutton_blue.TabStop = true;
            this.radiobutton_blue.Text = "Blue";
            this.radiobutton_blue.UseVisualStyleBackColor = true;
            // 
            // radiobutton_red
            // 
            this.radiobutton_red.AutoSize = true;
            this.radiobutton_red.Location = new System.Drawing.Point(483, 271);
            this.radiobutton_red.Name = "radiobutton_red";
            this.radiobutton_red.Size = new System.Drawing.Size(54, 20);
            this.radiobutton_red.TabIndex = 4;
            this.radiobutton_red.TabStop = true;
            this.radiobutton_red.Text = "Red";
            this.radiobutton_red.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox_moveCopy
            // 
            this.checkBox_moveCopy.AutoSize = true;
            this.checkBox_moveCopy.Location = new System.Drawing.Point(368, 332);
            this.checkBox_moveCopy.Name = "checkBox_moveCopy";
            this.checkBox_moveCopy.Size = new System.Drawing.Size(98, 20);
            this.checkBox_moveCopy.TabIndex = 5;
            this.checkBox_moveCopy.Text = "Move Copy";
            this.checkBox_moveCopy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox_moveCopy);
            this.Controls.Add(this.radiobutton_red);
            this.Controls.Add(this.radiobutton_blue);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label_Counter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Counter;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.RadioButton radiobutton_blue;
        private System.Windows.Forms.RadioButton radiobutton_red;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_moveCopy;
    }
}


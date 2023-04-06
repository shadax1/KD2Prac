namespace TestKD2
{
    partial class TestKD2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestKD2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkLives = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkHP = new System.Windows.Forms.CheckBox();
            this.checkStamina = new System.Windows.Forms.CheckBox();
            this.checkHearts = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboHotkeys = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lives:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "HP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stamina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hearts:";
            // 
            // checkLives
            // 
            this.checkLives.AutoSize = true;
            this.checkLives.Location = new System.Drawing.Point(81, 19);
            this.checkLives.Name = "checkLives";
            this.checkLives.Size = new System.Drawing.Size(15, 14);
            this.checkLives.TabIndex = 14;
            this.checkLives.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Instant kill hotkey";
            // 
            // checkHP
            // 
            this.checkHP.AutoSize = true;
            this.checkHP.Location = new System.Drawing.Point(81, 45);
            this.checkHP.Name = "checkHP";
            this.checkHP.Size = new System.Drawing.Size(15, 14);
            this.checkHP.TabIndex = 17;
            this.checkHP.UseVisualStyleBackColor = true;
            // 
            // checkStamina
            // 
            this.checkStamina.AutoSize = true;
            this.checkStamina.Location = new System.Drawing.Point(81, 71);
            this.checkStamina.Name = "checkStamina";
            this.checkStamina.Size = new System.Drawing.Size(15, 14);
            this.checkStamina.TabIndex = 19;
            this.checkStamina.UseVisualStyleBackColor = true;
            // 
            // checkHearts
            // 
            this.checkHearts.AutoSize = true;
            this.checkHearts.Location = new System.Drawing.Point(81, 97);
            this.checkHearts.Name = "checkHearts";
            this.checkHearts.Size = new System.Drawing.Size(15, 14);
            this.checkHearts.TabIndex = 21;
            this.checkHearts.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkHP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkStamina);
            this.groupBox1.Controls.Add(this.checkHearts);
            this.groupBox1.Controls.Add(this.checkLives);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 120);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Freeze values";
            // 
            // comboHotkeys
            // 
            this.comboHotkeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHotkeys.FormattingEnabled = true;
            this.comboHotkeys.Location = new System.Drawing.Point(14, 157);
            this.comboHotkeys.Name = "comboHotkeys";
            this.comboHotkeys.Size = new System.Drawing.Size(121, 21);
            this.comboHotkeys.TabIndex = 26;
            this.comboHotkeys.SelectedIndexChanged += new System.EventHandler(this.comboHotkeys_SelectedIndexChanged);
            // 
            // TestKD2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 188);
            this.Controls.Add(this.comboHotkeys);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestKD2";
            this.Text = "KD2_Prac";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestKD2_FormClosed);
            this.Load += new System.EventHandler(this.TestKD2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkLives;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkHP;
        private System.Windows.Forms.CheckBox checkStamina;
        private System.Windows.Forms.CheckBox checkHearts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboHotkeys;
    }
}


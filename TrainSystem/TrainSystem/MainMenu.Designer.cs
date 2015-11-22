namespace WindowsFormsApplication1
{
    partial class MainMenu
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
            this.cmdSchedule = new System.Windows.Forms.Button();
            this.cmdTrains = new System.Windows.Forms.Button();
            this.cmdMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSchedule
            // 
            this.cmdSchedule.Location = new System.Drawing.Point(91, 137);
            this.cmdSchedule.Name = "cmdSchedule";
            this.cmdSchedule.Size = new System.Drawing.Size(172, 23);
            this.cmdSchedule.TabIndex = 0;
            this.cmdSchedule.Text = "View Schedule";
            this.cmdSchedule.UseVisualStyleBackColor = true;
            // 
            // cmdTrains
            // 
            this.cmdTrains.Location = new System.Drawing.Point(91, 166);
            this.cmdTrains.Name = "cmdTrains";
            this.cmdTrains.Size = new System.Drawing.Size(172, 23);
            this.cmdTrains.TabIndex = 1;
            this.cmdTrains.Text = "View Trains";
            this.cmdTrains.UseVisualStyleBackColor = true;
            // 
            // cmdMap
            // 
            this.cmdMap.Location = new System.Drawing.Point(91, 195);
            this.cmdMap.Name = "cmdMap";
            this.cmdMap.Size = new System.Drawing.Size(172, 23);
            this.cmdMap.TabIndex = 2;
            this.cmdMap.Text = "View Map";
            this.cmdMap.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 110);
            this.label1.TabIndex = 3;
            this.label1.Text = "Train Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 233);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdMap);
            this.Controls.Add(this.cmdTrains);
            this.Controls.Add(this.cmdSchedule);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSchedule;
        private System.Windows.Forms.Button cmdTrains;
        private System.Windows.Forms.Button cmdMap;
        private System.Windows.Forms.Label label1;
    }
}
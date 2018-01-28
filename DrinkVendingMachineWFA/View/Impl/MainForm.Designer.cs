namespace DrinkVendingMachineWFA.View.Impl
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dispenserTabPage = new System.Windows.Forms.TabPage();
            this.coinCRUDPage = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.dispenserTabPage);
            this.tabControl1.Controls.Add(this.coinCRUDPage);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1085, 563);
            this.tabControl1.TabIndex = 0;
            // 
            // dispenserTabPage
            // 
            this.dispenserTabPage.Location = new System.Drawing.Point(4, 25);
            this.dispenserTabPage.Name = "dispenserTabPage";
            this.dispenserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dispenserTabPage.Size = new System.Drawing.Size(1077, 534);
            this.dispenserTabPage.TabIndex = 0;
            this.dispenserTabPage.Text = "Vending Machine";
            this.dispenserTabPage.UseVisualStyleBackColor = true;
            // 
            // coinCRUDPage
            // 
            this.coinCRUDPage.Location = new System.Drawing.Point(4, 25);
            this.coinCRUDPage.Name = "coinCRUDPage";
            this.coinCRUDPage.Padding = new System.Windows.Forms.Padding(3);
            this.coinCRUDPage.Size = new System.Drawing.Size(1077, 534);
            this.coinCRUDPage.TabIndex = 1;
            this.coinCRUDPage.Text = "Coin CRUD";
            this.coinCRUDPage.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1077, 534);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Drink CRUD";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 563);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage dispenserTabPage;
        private System.Windows.Forms.TabPage coinCRUDPage;
        private System.Windows.Forms.TabPage tabPage3;
    }
}
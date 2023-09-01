namespace MOD_aeYCNy.form
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.npcFormBtn = new System.Windows.Forms.Button();
            this.itemBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.npcFormBtn);
            this.flowLayoutPanel1.Controls.Add(this.itemBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1383, 44);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // npcFormBtn
            // 
            this.npcFormBtn.Location = new System.Drawing.Point(3, 3);
            this.npcFormBtn.Name = "npcFormBtn";
            this.npcFormBtn.Size = new System.Drawing.Size(75, 23);
            this.npcFormBtn.TabIndex = 0;
            this.npcFormBtn.Text = "Npc操作";
            this.npcFormBtn.UseVisualStyleBackColor = true;
            // 
            // itemBtn
            // 
            this.itemBtn.Location = new System.Drawing.Point(84, 3);
            this.itemBtn.Name = "itemBtn";
            this.itemBtn.Size = new System.Drawing.Size(75, 23);
            this.itemBtn.TabIndex = 1;
            this.itemBtn.Text = "物品数据";
            this.itemBtn.UseVisualStyleBackColor = true;
            this.itemBtn.Click += new System.EventHandler(this.itemBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 45);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button npcFormBtn;
        private System.Windows.Forms.Button itemBtn;
    }
}
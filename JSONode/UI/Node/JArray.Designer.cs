namespace JSONode.UI.Node
{
    partial class JArray
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flowContents = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLeftFill = new System.Windows.Forms.Panel();
            this.pnlRightFill = new System.Windows.Forms.Panel();
            this.tblLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout
            // 
            this.tblLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tblLayout.ColumnCount = 3;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblLayout.Controls.Add(this.pnlRightFill, 2, 2);
            this.tblLayout.Controls.Add(this.flowContents, 1, 1);
            this.tblLayout.Controls.Add(this.pnlLeftFill, 0, 2);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 5;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblLayout.Size = new System.Drawing.Size(150, 150);
            this.tblLayout.TabIndex = 0;
            // 
            // flowContents
            // 
            this.flowContents.AutoScroll = true;
            this.flowContents.AutoSize = true;
            this.flowContents.BackColor = System.Drawing.SystemColors.Control;
            this.flowContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowContents.Location = new System.Drawing.Point(8, 8);
            this.flowContents.Margin = new System.Windows.Forms.Padding(0);
            this.flowContents.Name = "flowContents";
            this.tblLayout.SetRowSpan(this.flowContents, 3);
            this.flowContents.Size = new System.Drawing.Size(134, 134);
            this.flowContents.TabIndex = 0;
            // 
            // pnlLeftFill
            // 
            this.pnlLeftFill.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLeftFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftFill.Location = new System.Drawing.Point(0, 16);
            this.pnlLeftFill.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeftFill.Name = "pnlLeftFill";
            this.pnlLeftFill.Size = new System.Drawing.Size(8, 118);
            this.pnlLeftFill.TabIndex = 1;
            // 
            // pnlRightFill
            // 
            this.pnlRightFill.BackColor = System.Drawing.SystemColors.Control;
            this.pnlRightFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightFill.Location = new System.Drawing.Point(142, 16);
            this.pnlRightFill.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRightFill.Name = "pnlRightFill";
            this.pnlRightFill.Size = new System.Drawing.Size(8, 118);
            this.pnlRightFill.TabIndex = 2;
            // 
            // JArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayout);
            this.Name = "JArray";
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.FlowLayoutPanel flowContents;
        private System.Windows.Forms.Panel pnlRightFill;
        private System.Windows.Forms.Panel pnlLeftFill;
    }
}

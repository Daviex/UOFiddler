/***************************************************************************
 *
 * $Author: Turley
 * 
 * "THE BEER-WARE LICENSE"
 * As long as you retain this notice you can do whatever you want with 
 * this stuff. If we meet some day, and you think this stuff is worth it,
 * you can buy me a beer in return.
 *
 ***************************************************************************/

namespace UoFiddler.Plugin.GumpPreview.UserControls
{
    partial class GumpPreviewControl
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.GumpPictureBox = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.LayoutTextBox = new System.Windows.Forms.RichTextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.DataTextBox = new System.Windows.Forms.RichTextBox();
      this.GumpPreviewButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.GumpPictureBox)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
      this.tableLayoutPanel1.Controls.Add(this.GumpPictureBox, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.GumpPreviewButton, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1217, 739);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // GumpPictureBox
      // 
      this.GumpPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GumpPictureBox.Location = new System.Drawing.Point(246, 3);
      this.GumpPictureBox.Name = "GumpPictureBox";
      this.tableLayoutPanel1.SetRowSpan(this.GumpPictureBox, 3);
      this.GumpPictureBox.Size = new System.Drawing.Size(968, 733);
      this.GumpPictureBox.TabIndex = 0;
      this.GumpPictureBox.TabStop = false;
      this.GumpPictureBox.SizeChanged += new System.EventHandler(this.OnResizePreviewPic);
      this.GumpPictureBox.Click += new System.EventHandler(this.OnClickPreview);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.LayoutTextBox);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(237, 345);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Layout";
      // 
      // LayoutTextBox
      // 
      this.LayoutTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LayoutTextBox.Location = new System.Drawing.Point(3, 16);
      this.LayoutTextBox.Name = "LayoutTextBox";
      this.LayoutTextBox.Size = new System.Drawing.Size(231, 326);
      this.LayoutTextBox.TabIndex = 0;
      this.LayoutTextBox.Text = "";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.DataTextBox);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(3, 354);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(237, 345);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Data";
      // 
      // DataTextBox
      // 
      this.DataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DataTextBox.Location = new System.Drawing.Point(3, 16);
      this.DataTextBox.Name = "DataTextBox";
      this.DataTextBox.Size = new System.Drawing.Size(231, 326);
      this.DataTextBox.TabIndex = 0;
      this.DataTextBox.Text = "";
      // 
      // GumpPreviewButton
      // 
      this.GumpPreviewButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GumpPreviewButton.Location = new System.Drawing.Point(3, 705);
      this.GumpPreviewButton.Name = "GumpPreviewButton";
      this.GumpPreviewButton.Size = new System.Drawing.Size(237, 31);
      this.GumpPreviewButton.TabIndex = 3;
      this.GumpPreviewButton.Text = "Preview Gump";
      this.GumpPreviewButton.UseVisualStyleBackColor = true;
      this.GumpPreviewButton.Click += new System.EventHandler(this.OnClickPreview);
      // 
      // GumpPreviewControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.DoubleBuffered = true;
      this.Name = "GumpPreviewControl";
      this.Size = new System.Drawing.Size(1217, 739);
      this.Load += new System.EventHandler(this.OnLoad);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.GumpPictureBox)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox GumpPictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button GumpPreviewButton;
        private System.Windows.Forms.RichTextBox LayoutTextBox;
        private System.Windows.Forms.RichTextBox DataTextBox;
    }
}

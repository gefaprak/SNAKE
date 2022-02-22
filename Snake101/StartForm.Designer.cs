﻿namespace Snake101
{
  partial class StartForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
      this.btnLevel1 = new System.Windows.Forms.Button();
      this.btnLevel2 = new System.Windows.Forms.Button();
      this.txtPlayername = new System.Windows.Forms.TextBox();
      this.lsvHighscores = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnLevel1
      // 
      this.btnLevel1.BackColor = System.Drawing.Color.White;
      this.btnLevel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLevel1.Image = ((System.Drawing.Image)(resources.GetObject("btnLevel1.Image")));
      this.btnLevel1.Location = new System.Drawing.Point(12, 93);
      this.btnLevel1.Name = "btnLevel1";
      this.btnLevel1.Size = new System.Drawing.Size(265, 265);
      this.btnLevel1.TabIndex = 0;
      this.btnLevel1.UseVisualStyleBackColor = false;
      this.btnLevel1.Click += new System.EventHandler(this.btnLevel1_Click);
      // 
      // btnLevel2
      // 
      this.btnLevel2.BackColor = System.Drawing.Color.White;
      this.btnLevel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLevel2.Image = ((System.Drawing.Image)(resources.GetObject("btnLevel2.Image")));
      this.btnLevel2.Location = new System.Drawing.Point(283, 93);
      this.btnLevel2.Name = "btnLevel2";
      this.btnLevel2.Size = new System.Drawing.Size(265, 265);
      this.btnLevel2.TabIndex = 1;
      this.btnLevel2.UseVisualStyleBackColor = false;
      this.btnLevel2.Click += new System.EventHandler(this.btnLevel2_Click);
      // 
      // txtPlayername
      // 
      this.txtPlayername.Location = new System.Drawing.Point(12, 64);
      this.txtPlayername.Name = "txtPlayername";
      this.txtPlayername.PlaceholderText = "Player Name";
      this.txtPlayername.Size = new System.Drawing.Size(536, 23);
      this.txtPlayername.TabIndex = 2;
      // 
      // lsvHighscores
      // 
      this.lsvHighscores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
      this.lsvHighscores.Location = new System.Drawing.Point(12, 389);
      this.lsvHighscores.Name = "lsvHighscores";
      this.lsvHighscores.Size = new System.Drawing.Size(536, 126);
      this.lsvHighscores.TabIndex = 3;
      this.lsvHighscores.UseCompatibleStateImageBehavior = false;
      this.lsvHighscores.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Player";
      this.columnHeader1.Width = 150;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Level";
      this.columnHeader2.Width = 150;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "HighScore";
      this.columnHeader3.Width = 100;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(12, 363);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(536, 23);
      this.label1.TabIndex = 4;
      this.label1.Text = "HIGHSCORES";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(12, 6);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(536, 50);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 5;
      this.pictureBox1.TabStop = false;
      // 
      // StartForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(559, 527);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lsvHighscores);
      this.Controls.Add(this.txtPlayername);
      this.Controls.Add(this.btnLevel2);
      this.Controls.Add(this.btnLevel1);
      this.Name = "StartForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SNAKE 3000";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Button btnLevel1;
    private Button btnLevel2;
    private TextBox txtPlayername;
    private ListView lsvHighscores;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private Label label1;
    private PictureBox pictureBox1;
  }
}
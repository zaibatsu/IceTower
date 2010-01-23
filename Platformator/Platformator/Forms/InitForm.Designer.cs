namespace Platformator
{
 partial class InitForm
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
   System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitForm));
   this.button1 = new System.Windows.Forms.Button();
   this.listBox1 = new System.Windows.Forms.ListBox();
   this.progressBar1 = new System.Windows.Forms.ProgressBar();
   this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
   this.panel2 = new System.Windows.Forms.Panel();
   this.panel1 = new System.Windows.Forms.Panel();
   this.button2 = new System.Windows.Forms.Button();
   this.label2 = new System.Windows.Forms.Label();
   this.textBox1 = new System.Windows.Forms.TextBox();
   this.label1 = new System.Windows.Forms.Label();
   this.textBox2 = new System.Windows.Forms.TextBox();
   this.button3 = new System.Windows.Forms.Button();
   this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
   this.panel2.SuspendLayout();
   this.SuspendLayout();
   // 
   // button1
   // 
   this.button1.Enabled = false;
   this.button1.Location = new System.Drawing.Point(3, 104);
   this.button1.Name = "button1";
   this.button1.Size = new System.Drawing.Size(157, 27);
   this.button1.TabIndex = 0;
   this.button1.Text = "ok";
   this.button1.UseVisualStyleBackColor = true;
   this.button1.Click += new System.EventHandler(this.button1_Click);
   // 
   // listBox1
   // 
   this.listBox1.FormattingEnabled = true;
   this.listBox1.Location = new System.Drawing.Point(3, 3);
   this.listBox1.Name = "listBox1";
   this.listBox1.Size = new System.Drawing.Size(157, 95);
   this.listBox1.TabIndex = 1;
   this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
   // 
   // progressBar1
   // 
   this.progressBar1.Location = new System.Drawing.Point(3, 137);
   this.progressBar1.Name = "progressBar1";
   this.progressBar1.Size = new System.Drawing.Size(157, 23);
   this.progressBar1.TabIndex = 2;
   // 
   // panel2
   // 
   this.panel2.Controls.Add(this.panel1);
   this.panel2.Controls.Add(this.button2);
   this.panel2.Controls.Add(this.label2);
   this.panel2.Controls.Add(this.textBox1);
   this.panel2.Controls.Add(this.label1);
   this.panel2.Controls.Add(this.textBox2);
   this.panel2.Controls.Add(this.button3);
   this.panel2.Enabled = false;
   this.panel2.Location = new System.Drawing.Point(167, 3);
   this.panel2.Name = "panel2";
   this.panel2.Size = new System.Drawing.Size(418, 157);
   this.panel2.TabIndex = 13;
   // 
   // panel1
   // 
   this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
   this.panel1.Location = new System.Drawing.Point(9, 67);
   this.panel1.Name = "panel1";
   this.panel1.Size = new System.Drawing.Size(404, 87);
   this.panel1.TabIndex = 19;
   // 
   // button2
   // 
   this.button2.Location = new System.Drawing.Point(338, 29);
   this.button2.Name = "button2";
   this.button2.Size = new System.Drawing.Size(75, 23);
   this.button2.TabIndex = 18;
   this.button2.Text = "open";
   this.button2.UseVisualStyleBackColor = true;
   this.button2.Click += new System.EventHandler(this.button2_Click);
   // 
   // label2
   // 
   this.label2.AutoSize = true;
   this.label2.Location = new System.Drawing.Point(6, 39);
   this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(46, 13);
   this.label2.TabIndex = 16;
   this.label2.Text = "Texture:";
   // 
   // textBox1
   // 
   this.textBox1.Location = new System.Drawing.Point(82, 6);
   this.textBox1.Name = "textBox1";
   this.textBox1.Size = new System.Drawing.Size(250, 20);
   this.textBox1.TabIndex = 15;
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(6, 9);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(70, 13);
   this.label1.TabIndex = 13;
   this.label1.Text = "Name: plat + ";
   // 
   // textBox2
   // 
   this.textBox2.Location = new System.Drawing.Point(82, 32);
   this.textBox2.Name = "textBox2";
   this.textBox2.Size = new System.Drawing.Size(250, 20);
   this.textBox2.TabIndex = 17;
   // 
   // button3
   // 
   this.button3.Location = new System.Drawing.Point(338, 3);
   this.button3.Name = "button3";
   this.button3.Size = new System.Drawing.Size(75, 23);
   this.button3.TabIndex = 14;
   this.button3.Text = "save";
   this.button3.UseVisualStyleBackColor = true;
   this.button3.Click += new System.EventHandler(this.button3_Click_1);
   // 
   // openFileDialog1
   // 
   this.openFileDialog1.FileName = "openFileDialog1";
   // 
   // InitForm
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(587, 162);
   this.Controls.Add(this.panel2);
   this.Controls.Add(this.progressBar1);
   this.Controls.Add(this.listBox1);
   this.Controls.Add(this.button1);
   this.MaximizeBox = false;
   this.MinimizeBox = false;
   this.Name = "InitForm";
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Choose script";
   this.Load += new System.EventHandler(this.InitForm_Load);
   this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InitForm_FormClosed);
   this.panel2.ResumeLayout(false);
   this.panel2.PerformLayout();
   this.ResumeLayout(false);

  }

  #endregion

  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.ListBox listBox1;
  private System.Windows.Forms.ProgressBar progressBar1;
  public System.Windows.Forms.SaveFileDialog saveFileDialog1;
  private System.Windows.Forms.Panel panel2;
  private System.Windows.Forms.Panel panel1;
  private System.Windows.Forms.Button button2;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.TextBox textBox1;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.TextBox textBox2;
  private System.Windows.Forms.Button button3;
  public System.Windows.Forms.OpenFileDialog openFileDialog1;
 }
}
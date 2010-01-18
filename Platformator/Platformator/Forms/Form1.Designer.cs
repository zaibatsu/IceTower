namespace Platformator
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
   this.groupBox1 = new System.Windows.Forms.GroupBox();
   this.gameControl = new Platformator.GameControl();
   this.SuspendLayout();
   // 
   // groupBox1
   // 
   this.groupBox1.Location = new System.Drawing.Point(646, 12);
   this.groupBox1.Name = "groupBox1";
   this.groupBox1.Size = new System.Drawing.Size(134, 110);
   this.groupBox1.TabIndex = 4;
   this.groupBox1.TabStop = false;
   this.groupBox1.Text = "groupBox1";
   // 
   // gameControl
   // 
   this.gameControl.Location = new System.Drawing.Point(0, 0);
   this.gameControl.Name = "gameControl";
   this.gameControl.Size = new System.Drawing.Size(640, 480);
   this.gameControl.TabIndex = 3;
   this.gameControl.Text = "GameControl";
   this.gameControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameControl_MouseClick);
   this.gameControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gameControl_MouseUp);
   // 
   // Form1
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(1016, 573);
   this.Controls.Add(this.groupBox1);
   this.Controls.Add(this.gameControl);
   this.Name = "Form1";
   this.Text = "Form1";
   this.Load += new System.EventHandler(this.Form1_Load);
   this.ResumeLayout(false);

  }

  #endregion

  private GameControl gameControl;
  private System.Windows.Forms.GroupBox groupBox1;

 }
}


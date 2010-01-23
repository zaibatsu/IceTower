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
   this.nameTextbox = new System.Windows.Forms.TextBox();
   this.simButton = new System.Windows.Forms.Button();
   this.globalTab = new System.Windows.Forms.TabControl();
   this.tabPage1 = new System.Windows.Forms.TabPage();
   this.addTextureGeom = new System.Windows.Forms.Button();
   this.addCircle = new System.Windows.Forms.Button();
   this.addEllipse = new System.Windows.Forms.Button();
   this.addBox = new System.Windows.Forms.Button();
   this.tabPage2 = new System.Windows.Forms.TabPage();
   this.label7 = new System.Windows.Forms.Label();
   this.frictionBox = new System.Windows.Forms.TextBox();
   this.isStatcBox = new System.Windows.Forms.CheckBox();
   this.propertsTab = new System.Windows.Forms.TabControl();
   this.tabPage3 = new System.Windows.Forms.TabPage();
   this.label6 = new System.Windows.Forms.Label();
   this.boxHeight = new System.Windows.Forms.TextBox();
   this.label5 = new System.Windows.Forms.Label();
   this.boxWidth = new System.Windows.Forms.TextBox();
   this.tabPage4 = new System.Windows.Forms.TabPage();
   this.label16 = new System.Windows.Forms.Label();
   this.circleRad = new System.Windows.Forms.TextBox();
   this.tabPage5 = new System.Windows.Forms.TabPage();
   this.label18 = new System.Windows.Forms.Label();
   this.ellipseRadY = new System.Windows.Forms.TextBox();
   this.label19 = new System.Windows.Forms.Label();
   this.ellipseRadX = new System.Windows.Forms.TextBox();
   this.tabPage6 = new System.Windows.Forms.TabPage();
   this.label15 = new System.Windows.Forms.Label();
   this.textureGeomOpenFile = new System.Windows.Forms.Button();
   this.textureGeomTexture = new System.Windows.Forms.TextBox();
   this.label21 = new System.Windows.Forms.Label();
   this.textureGeomHeight = new System.Windows.Forms.TextBox();
   this.label22 = new System.Windows.Forms.Label();
   this.textureGeomWidth = new System.Windows.Forms.TextBox();
   this.label17 = new System.Windows.Forms.Label();
   this.smileBut = new System.Windows.Forms.Button();
   this.massTextBox = new System.Windows.Forms.TextBox();
   this.button5 = new System.Windows.Forms.Button();
   this.button3 = new System.Windows.Forms.Button();
   this.label4 = new System.Windows.Forms.Label();
   this.heightTextbox = new System.Windows.Forms.TextBox();
   this.widthTextbox = new System.Windows.Forms.TextBox();
   this.label3 = new System.Windows.Forms.Label();
   this.label2 = new System.Windows.Forms.Label();
   this.label1 = new System.Windows.Forms.Label();
   this.pushTexture = new System.Windows.Forms.Button();
   this.textureTextbox = new System.Windows.Forms.TextBox();
   this.label8 = new System.Windows.Forms.Label();
   this.checkBox2 = new System.Windows.Forms.CheckBox();
   this.textBox8 = new System.Windows.Forms.TextBox();
   this.label9 = new System.Windows.Forms.Label();
   this.textBox9 = new System.Windows.Forms.TextBox();
   this.label10 = new System.Windows.Forms.Label();
   this.textBox10 = new System.Windows.Forms.TextBox();
   this.label11 = new System.Windows.Forms.Label();
   this.checkBox3 = new System.Windows.Forms.CheckBox();
   this.textBox11 = new System.Windows.Forms.TextBox();
   this.label12 = new System.Windows.Forms.Label();
   this.textBox12 = new System.Windows.Forms.TextBox();
   this.label13 = new System.Windows.Forms.Label();
   this.textBox13 = new System.Windows.Forms.TextBox();
   this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
   this.gameControl = new Platformator.GameControl();
   this.globalTab.SuspendLayout();
   this.tabPage1.SuspendLayout();
   this.tabPage2.SuspendLayout();
   this.propertsTab.SuspendLayout();
   this.tabPage3.SuspendLayout();
   this.tabPage4.SuspendLayout();
   this.tabPage5.SuspendLayout();
   this.tabPage6.SuspendLayout();
   this.SuspendLayout();
   // 
   // nameTextbox
   // 
   this.nameTextbox.Location = new System.Drawing.Point(99, 35);
   this.nameTextbox.Name = "nameTextbox";
   this.nameTextbox.Size = new System.Drawing.Size(100, 20);
   this.nameTextbox.TabIndex = 0;
   this.nameTextbox.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // simButton
   // 
   this.simButton.Location = new System.Drawing.Point(526, 12);
   this.simButton.Name = "simButton";
   this.simButton.Size = new System.Drawing.Size(101, 23);
   this.simButton.TabIndex = 6;
   this.simButton.Text = "simulation (OFF)";
   this.simButton.UseVisualStyleBackColor = true;
   this.simButton.Click += new System.EventHandler(this.simButton_Click);
   // 
   // globalTab
   // 
   this.globalTab.Controls.Add(this.tabPage1);
   this.globalTab.Controls.Add(this.tabPage2);
   this.globalTab.Location = new System.Drawing.Point(646, 12);
   this.globalTab.Name = "globalTab";
   this.globalTab.SelectedIndex = 0;
   this.globalTab.Size = new System.Drawing.Size(367, 415);
   this.globalTab.TabIndex = 7;
   this.globalTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.globalTab_Selected);
   // 
   // tabPage1
   // 
   this.tabPage1.Controls.Add(this.addTextureGeom);
   this.tabPage1.Controls.Add(this.addCircle);
   this.tabPage1.Controls.Add(this.addEllipse);
   this.tabPage1.Controls.Add(this.addBox);
   this.tabPage1.ImageKey = "(none)";
   this.tabPage1.Location = new System.Drawing.Point(4, 22);
   this.tabPage1.Name = "tabPage1";
   this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
   this.tabPage1.Size = new System.Drawing.Size(359, 389);
   this.tabPage1.TabIndex = 0;
   this.tabPage1.Text = "Objects";
   this.tabPage1.UseVisualStyleBackColor = true;
   // 
   // addTextureGeom
   // 
   this.addTextureGeom.Location = new System.Drawing.Point(3, 93);
   this.addTextureGeom.Name = "addTextureGeom";
   this.addTextureGeom.Size = new System.Drawing.Size(83, 23);
   this.addTextureGeom.TabIndex = 9;
   this.addTextureGeom.Text = "texture geom";
   this.addTextureGeom.UseVisualStyleBackColor = true;
   // 
   // addCircle
   // 
   this.addCircle.Location = new System.Drawing.Point(3, 64);
   this.addCircle.Name = "addCircle";
   this.addCircle.Size = new System.Drawing.Size(83, 23);
   this.addCircle.TabIndex = 8;
   this.addCircle.Text = "circle";
   this.addCircle.UseVisualStyleBackColor = true;
   // 
   // addEllipse
   // 
   this.addEllipse.Location = new System.Drawing.Point(3, 35);
   this.addEllipse.Name = "addEllipse";
   this.addEllipse.Size = new System.Drawing.Size(83, 23);
   this.addEllipse.TabIndex = 7;
   this.addEllipse.Text = "ellipse";
   this.addEllipse.UseVisualStyleBackColor = true;
   // 
   // addBox
   // 
   this.addBox.Location = new System.Drawing.Point(3, 6);
   this.addBox.Name = "addBox";
   this.addBox.Size = new System.Drawing.Size(83, 23);
   this.addBox.TabIndex = 6;
   this.addBox.Text = "box";
   this.addBox.UseVisualStyleBackColor = true;
   this.addBox.Click += new System.EventHandler(this.addBox_Click);
   // 
   // tabPage2
   // 
   this.tabPage2.Controls.Add(this.nameTextbox);
   this.tabPage2.Controls.Add(this.label7);
   this.tabPage2.Controls.Add(this.frictionBox);
   this.tabPage2.Controls.Add(this.isStatcBox);
   this.tabPage2.Controls.Add(this.propertsTab);
   this.tabPage2.Controls.Add(this.label17);
   this.tabPage2.Controls.Add(this.smileBut);
   this.tabPage2.Controls.Add(this.massTextBox);
   this.tabPage2.Controls.Add(this.button5);
   this.tabPage2.Controls.Add(this.button3);
   this.tabPage2.Controls.Add(this.label4);
   this.tabPage2.Controls.Add(this.heightTextbox);
   this.tabPage2.Controls.Add(this.widthTextbox);
   this.tabPage2.Controls.Add(this.label3);
   this.tabPage2.Controls.Add(this.label2);
   this.tabPage2.Controls.Add(this.label1);
   this.tabPage2.Controls.Add(this.pushTexture);
   this.tabPage2.Controls.Add(this.textureTextbox);
   this.tabPage2.Location = new System.Drawing.Point(4, 22);
   this.tabPage2.Name = "tabPage2";
   this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
   this.tabPage2.Size = new System.Drawing.Size(359, 389);
   this.tabPage2.TabIndex = 1;
   this.tabPage2.Text = "Properties";
   this.tabPage2.UseVisualStyleBackColor = true;
   // 
   // label7
   // 
   this.label7.AutoSize = true;
   this.label7.Location = new System.Drawing.Point(43, 165);
   this.label7.Name = "label7";
   this.label7.Size = new System.Drawing.Size(41, 13);
   this.label7.TabIndex = 28;
   this.label7.Text = "Friction";
   // 
   // frictionBox
   // 
   this.frictionBox.Location = new System.Drawing.Point(99, 165);
   this.frictionBox.Name = "frictionBox";
   this.frictionBox.Size = new System.Drawing.Size(100, 20);
   this.frictionBox.TabIndex = 27;
   this.frictionBox.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // isStatcBox
   // 
   this.isStatcBox.AutoSize = true;
   this.isStatcBox.Location = new System.Drawing.Point(205, 142);
   this.isStatcBox.Name = "isStatcBox";
   this.isStatcBox.Size = new System.Drawing.Size(60, 17);
   this.isStatcBox.TabIndex = 26;
   this.isStatcBox.Text = "isStatic";
   this.isStatcBox.UseVisualStyleBackColor = true;
   this.isStatcBox.CheckedChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // propertsTab
   // 
   this.propertsTab.Controls.Add(this.tabPage3);
   this.propertsTab.Controls.Add(this.tabPage4);
   this.propertsTab.Controls.Add(this.tabPage5);
   this.propertsTab.Controls.Add(this.tabPage6);
   this.propertsTab.Location = new System.Drawing.Point(42, 190);
   this.propertsTab.Name = "propertsTab";
   this.propertsTab.SelectedIndex = 0;
   this.propertsTab.Size = new System.Drawing.Size(260, 127);
   this.propertsTab.TabIndex = 13;
   this.propertsTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.propertsTab_Selected);
   // 
   // tabPage3
   // 
   this.tabPage3.Controls.Add(this.label6);
   this.tabPage3.Controls.Add(this.boxHeight);
   this.tabPage3.Controls.Add(this.label5);
   this.tabPage3.Controls.Add(this.boxWidth);
   this.tabPage3.Location = new System.Drawing.Point(4, 22);
   this.tabPage3.Name = "tabPage3";
   this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
   this.tabPage3.Size = new System.Drawing.Size(252, 101);
   this.tabPage3.TabIndex = 0;
   this.tabPage3.Text = "Box";
   this.tabPage3.UseVisualStyleBackColor = true;
   // 
   // label6
   // 
   this.label6.AutoSize = true;
   this.label6.Location = new System.Drawing.Point(3, 41);
   this.label6.Name = "label6";
   this.label6.Size = new System.Drawing.Size(61, 13);
   this.label6.TabIndex = 16;
   this.label6.Text = "PhysHeight";
   // 
   // boxHeight
   // 
   this.boxHeight.Location = new System.Drawing.Point(80, 38);
   this.boxHeight.Name = "boxHeight";
   this.boxHeight.Size = new System.Drawing.Size(100, 20);
   this.boxHeight.TabIndex = 15;
   this.boxHeight.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // label5
   // 
   this.label5.AutoSize = true;
   this.label5.Location = new System.Drawing.Point(3, 15);
   this.label5.Name = "label5";
   this.label5.Size = new System.Drawing.Size(58, 13);
   this.label5.TabIndex = 14;
   this.label5.Text = "PhysWidth";
   // 
   // boxWidth
   // 
   this.boxWidth.Location = new System.Drawing.Point(80, 12);
   this.boxWidth.Name = "boxWidth";
   this.boxWidth.Size = new System.Drawing.Size(100, 20);
   this.boxWidth.TabIndex = 13;
   this.boxWidth.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // tabPage4
   // 
   this.tabPage4.Controls.Add(this.label16);
   this.tabPage4.Controls.Add(this.circleRad);
   this.tabPage4.Location = new System.Drawing.Point(4, 22);
   this.tabPage4.Name = "tabPage4";
   this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
   this.tabPage4.Size = new System.Drawing.Size(252, 101);
   this.tabPage4.TabIndex = 1;
   this.tabPage4.Text = "Circle";
   this.tabPage4.UseVisualStyleBackColor = true;
   // 
   // label16
   // 
   this.label16.AutoSize = true;
   this.label16.Location = new System.Drawing.Point(3, 15);
   this.label16.Name = "label16";
   this.label16.Size = new System.Drawing.Size(63, 13);
   this.label16.TabIndex = 28;
   this.label16.Text = "PhysRadius";
   // 
   // circleRad
   // 
   this.circleRad.Location = new System.Drawing.Point(80, 12);
   this.circleRad.Name = "circleRad";
   this.circleRad.Size = new System.Drawing.Size(100, 20);
   this.circleRad.TabIndex = 27;
   this.circleRad.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // tabPage5
   // 
   this.tabPage5.Controls.Add(this.label18);
   this.tabPage5.Controls.Add(this.ellipseRadY);
   this.tabPage5.Controls.Add(this.label19);
   this.tabPage5.Controls.Add(this.ellipseRadX);
   this.tabPage5.Location = new System.Drawing.Point(4, 22);
   this.tabPage5.Name = "tabPage5";
   this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
   this.tabPage5.Size = new System.Drawing.Size(252, 101);
   this.tabPage5.TabIndex = 2;
   this.tabPage5.Text = "Ellipse";
   this.tabPage5.UseVisualStyleBackColor = true;
   // 
   // label18
   // 
   this.label18.AutoSize = true;
   this.label18.Location = new System.Drawing.Point(3, 41);
   this.label18.Name = "label18";
   this.label18.Size = new System.Drawing.Size(70, 13);
   this.label18.TabIndex = 23;
   this.label18.Text = "PhysRadiusY";
   // 
   // ellipseRadY
   // 
   this.ellipseRadY.Location = new System.Drawing.Point(80, 38);
   this.ellipseRadY.Name = "ellipseRadY";
   this.ellipseRadY.Size = new System.Drawing.Size(100, 20);
   this.ellipseRadY.TabIndex = 22;
   this.ellipseRadY.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // label19
   // 
   this.label19.AutoSize = true;
   this.label19.Location = new System.Drawing.Point(3, 15);
   this.label19.Name = "label19";
   this.label19.Size = new System.Drawing.Size(70, 13);
   this.label19.TabIndex = 21;
   this.label19.Text = "PhysRadiusX";
   // 
   // ellipseRadX
   // 
   this.ellipseRadX.Location = new System.Drawing.Point(80, 12);
   this.ellipseRadX.Name = "ellipseRadX";
   this.ellipseRadX.Size = new System.Drawing.Size(100, 20);
   this.ellipseRadX.TabIndex = 20;
   this.ellipseRadX.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // tabPage6
   // 
   this.tabPage6.Controls.Add(this.label15);
   this.tabPage6.Controls.Add(this.textureGeomOpenFile);
   this.tabPage6.Controls.Add(this.textureGeomTexture);
   this.tabPage6.Controls.Add(this.label21);
   this.tabPage6.Controls.Add(this.textureGeomHeight);
   this.tabPage6.Controls.Add(this.label22);
   this.tabPage6.Controls.Add(this.textureGeomWidth);
   this.tabPage6.Location = new System.Drawing.Point(4, 22);
   this.tabPage6.Name = "tabPage6";
   this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
   this.tabPage6.Size = new System.Drawing.Size(252, 101);
   this.tabPage6.TabIndex = 3;
   this.tabPage6.Text = "TextureGeom";
   this.tabPage6.UseVisualStyleBackColor = true;
   // 
   // label15
   // 
   this.label15.AutoSize = true;
   this.label15.Location = new System.Drawing.Point(6, 67);
   this.label15.Name = "label15";
   this.label15.Size = new System.Drawing.Size(43, 13);
   this.label15.TabIndex = 29;
   this.label15.Text = "Texture";
   // 
   // textureGeomOpenFile
   // 
   this.textureGeomOpenFile.Location = new System.Drawing.Point(192, 66);
   this.textureGeomOpenFile.Name = "textureGeomOpenFile";
   this.textureGeomOpenFile.Size = new System.Drawing.Size(45, 23);
   this.textureGeomOpenFile.TabIndex = 28;
   this.textureGeomOpenFile.Text = "...";
   this.textureGeomOpenFile.UseVisualStyleBackColor = true;
   // 
   // textureGeomTexture
   // 
   this.textureGeomTexture.Location = new System.Drawing.Point(80, 64);
   this.textureGeomTexture.Name = "textureGeomTexture";
   this.textureGeomTexture.Size = new System.Drawing.Size(100, 20);
   this.textureGeomTexture.TabIndex = 27;
   this.textureGeomTexture.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // label21
   // 
   this.label21.AutoSize = true;
   this.label21.Location = new System.Drawing.Point(6, 41);
   this.label21.Name = "label21";
   this.label21.Size = new System.Drawing.Size(61, 13);
   this.label21.TabIndex = 23;
   this.label21.Text = "PhysHeight";
   // 
   // textureGeomHeight
   // 
   this.textureGeomHeight.Location = new System.Drawing.Point(80, 38);
   this.textureGeomHeight.Name = "textureGeomHeight";
   this.textureGeomHeight.Size = new System.Drawing.Size(100, 20);
   this.textureGeomHeight.TabIndex = 22;
   this.textureGeomHeight.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // label22
   // 
   this.label22.AutoSize = true;
   this.label22.Location = new System.Drawing.Point(6, 15);
   this.label22.Name = "label22";
   this.label22.Size = new System.Drawing.Size(58, 13);
   this.label22.TabIndex = 21;
   this.label22.Text = "PhysWidth";
   // 
   // textureGeomWidth
   // 
   this.textureGeomWidth.Location = new System.Drawing.Point(80, 12);
   this.textureGeomWidth.Name = "textureGeomWidth";
   this.textureGeomWidth.Size = new System.Drawing.Size(100, 20);
   this.textureGeomWidth.TabIndex = 20;
   this.textureGeomWidth.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // label17
   // 
   this.label17.AutoSize = true;
   this.label17.Location = new System.Drawing.Point(42, 143);
   this.label17.Name = "label17";
   this.label17.Size = new System.Drawing.Size(32, 13);
   this.label17.TabIndex = 25;
   this.label17.Text = "Mass";
   // 
   // smileBut
   // 
   this.smileBut.Location = new System.Drawing.Point(205, 33);
   this.smileBut.Name = "smileBut";
   this.smileBut.Size = new System.Drawing.Size(97, 23);
   this.smileBut.TabIndex = 12;
   this.smileBut.Text = "^_^";
   this.smileBut.UseVisualStyleBackColor = true;
   this.smileBut.Click += new System.EventHandler(this.smileBut_Click);
   // 
   // massTextBox
   // 
   this.massTextBox.Location = new System.Drawing.Point(99, 139);
   this.massTextBox.Name = "massTextBox";
   this.massTextBox.Size = new System.Drawing.Size(100, 20);
   this.massTextBox.TabIndex = 24;
   this.massTextBox.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // button5
   // 
   this.button5.Location = new System.Drawing.Point(205, 111);
   this.button5.Name = "button5";
   this.button5.Size = new System.Drawing.Size(97, 23);
   this.button5.TabIndex = 11;
   this.button5.Text = "get from Texture";
   this.button5.UseVisualStyleBackColor = true;
   this.button5.Click += new System.EventHandler(this.getHeightTexture);
   // 
   // button3
   // 
   this.button3.Location = new System.Drawing.Point(205, 85);
   this.button3.Name = "button3";
   this.button3.Size = new System.Drawing.Size(97, 23);
   this.button3.TabIndex = 10;
   this.button3.Text = "get from Texture";
   this.button3.UseVisualStyleBackColor = true;
   this.button3.Click += new System.EventHandler(this.getWidthTexture);
   // 
   // label4
   // 
   this.label4.AutoSize = true;
   this.label4.Location = new System.Drawing.Point(42, 116);
   this.label4.Name = "label4";
   this.label4.Size = new System.Drawing.Size(38, 13);
   this.label4.TabIndex = 9;
   this.label4.Text = "Height";
   // 
   // heightTextbox
   // 
   this.heightTextbox.Location = new System.Drawing.Point(99, 113);
   this.heightTextbox.Name = "heightTextbox";
   this.heightTextbox.Size = new System.Drawing.Size(100, 20);
   this.heightTextbox.TabIndex = 8;
   this.heightTextbox.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // widthTextbox
   // 
   this.widthTextbox.Location = new System.Drawing.Point(99, 87);
   this.widthTextbox.Name = "widthTextbox";
   this.widthTextbox.Size = new System.Drawing.Size(100, 20);
   this.widthTextbox.TabIndex = 7;
   this.widthTextbox.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // label3
   // 
   this.label3.AutoSize = true;
   this.label3.Location = new System.Drawing.Point(42, 90);
   this.label3.Name = "label3";
   this.label3.Size = new System.Drawing.Size(35, 13);
   this.label3.TabIndex = 6;
   this.label3.Text = "Width";
   // 
   // label2
   // 
   this.label2.AutoSize = true;
   this.label2.Location = new System.Drawing.Point(42, 64);
   this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(43, 13);
   this.label2.TabIndex = 5;
   this.label2.Text = "Texture";
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(42, 38);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(35, 13);
   this.label1.TabIndex = 4;
   this.label1.Text = "Name";
   // 
   // pushTexture
   // 
   this.pushTexture.Location = new System.Drawing.Point(205, 59);
   this.pushTexture.Name = "pushTexture";
   this.pushTexture.Size = new System.Drawing.Size(97, 23);
   this.pushTexture.TabIndex = 3;
   this.pushTexture.Text = "...";
   this.pushTexture.UseVisualStyleBackColor = true;
   this.pushTexture.Click += new System.EventHandler(this.pushTextureClick);
   // 
   // textureTextbox
   // 
   this.textureTextbox.Location = new System.Drawing.Point(99, 61);
   this.textureTextbox.Name = "textureTextbox";
   this.textureTextbox.Size = new System.Drawing.Size(100, 20);
   this.textureTextbox.TabIndex = 1;
   this.textureTextbox.TextChanged += new System.EventHandler(this.ParametersChanged);
   // 
   // label8
   // 
   this.label8.AutoSize = true;
   this.label8.Location = new System.Drawing.Point(8, 71);
   this.label8.Name = "label8";
   this.label8.Size = new System.Drawing.Size(32, 13);
   this.label8.TabIndex = 18;
   this.label8.Text = "Mass";
   // 
   // checkBox2
   // 
   this.checkBox2.AutoSize = true;
   this.checkBox2.Location = new System.Drawing.Point(187, 70);
   this.checkBox2.Name = "checkBox2";
   this.checkBox2.Size = new System.Drawing.Size(60, 17);
   this.checkBox2.TabIndex = 19;
   this.checkBox2.Text = "isStatic";
   this.checkBox2.UseVisualStyleBackColor = true;
   // 
   // textBox8
   // 
   this.textBox8.Location = new System.Drawing.Point(72, 68);
   this.textBox8.Name = "textBox8";
   this.textBox8.Size = new System.Drawing.Size(100, 20);
   this.textBox8.TabIndex = 17;
   // 
   // label9
   // 
   this.label9.AutoSize = true;
   this.label9.Location = new System.Drawing.Point(8, 45);
   this.label9.Name = "label9";
   this.label9.Size = new System.Drawing.Size(61, 13);
   this.label9.TabIndex = 16;
   this.label9.Text = "PhysHeight";
   // 
   // textBox9
   // 
   this.textBox9.Location = new System.Drawing.Point(72, 42);
   this.textBox9.Name = "textBox9";
   this.textBox9.Size = new System.Drawing.Size(100, 20);
   this.textBox9.TabIndex = 15;
   // 
   // label10
   // 
   this.label10.AutoSize = true;
   this.label10.Location = new System.Drawing.Point(8, 19);
   this.label10.Name = "label10";
   this.label10.Size = new System.Drawing.Size(58, 13);
   this.label10.TabIndex = 14;
   this.label10.Text = "PhysWidth";
   // 
   // textBox10
   // 
   this.textBox10.Location = new System.Drawing.Point(72, 16);
   this.textBox10.Name = "textBox10";
   this.textBox10.Size = new System.Drawing.Size(100, 20);
   this.textBox10.TabIndex = 13;
   // 
   // label11
   // 
   this.label11.AutoSize = true;
   this.label11.Location = new System.Drawing.Point(8, 71);
   this.label11.Name = "label11";
   this.label11.Size = new System.Drawing.Size(32, 13);
   this.label11.TabIndex = 18;
   this.label11.Text = "Mass";
   // 
   // checkBox3
   // 
   this.checkBox3.AutoSize = true;
   this.checkBox3.Location = new System.Drawing.Point(187, 70);
   this.checkBox3.Name = "checkBox3";
   this.checkBox3.Size = new System.Drawing.Size(60, 17);
   this.checkBox3.TabIndex = 19;
   this.checkBox3.Text = "isStatic";
   this.checkBox3.UseVisualStyleBackColor = true;
   // 
   // textBox11
   // 
   this.textBox11.Location = new System.Drawing.Point(72, 68);
   this.textBox11.Name = "textBox11";
   this.textBox11.Size = new System.Drawing.Size(100, 20);
   this.textBox11.TabIndex = 17;
   // 
   // label12
   // 
   this.label12.AutoSize = true;
   this.label12.Location = new System.Drawing.Point(8, 45);
   this.label12.Name = "label12";
   this.label12.Size = new System.Drawing.Size(61, 13);
   this.label12.TabIndex = 16;
   this.label12.Text = "PhysHeight";
   // 
   // textBox12
   // 
   this.textBox12.Location = new System.Drawing.Point(72, 42);
   this.textBox12.Name = "textBox12";
   this.textBox12.Size = new System.Drawing.Size(100, 20);
   this.textBox12.TabIndex = 15;
   // 
   // label13
   // 
   this.label13.AutoSize = true;
   this.label13.Location = new System.Drawing.Point(8, 19);
   this.label13.Name = "label13";
   this.label13.Size = new System.Drawing.Size(58, 13);
   this.label13.TabIndex = 14;
   this.label13.Text = "PhysWidth";
   // 
   // textBox13
   // 
   this.textBox13.Location = new System.Drawing.Point(72, 16);
   this.textBox13.Name = "textBox13";
   this.textBox13.Size = new System.Drawing.Size(100, 20);
   this.textBox13.TabIndex = 13;
   // 
   // openFileDialog1
   // 
   this.openFileDialog1.FileName = "openFileDialog1";
   // 
   // gameControl
   // 
   this.gameControl.Location = new System.Drawing.Point(0, 0);
   this.gameControl.Name = "gameControl";
   this.gameControl.Size = new System.Drawing.Size(640, 480);
   this.gameControl.TabIndex = 3;
   this.gameControl.Text = "GameControl";
   this.gameControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gameControl_MouseMove_1);
   this.gameControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gameControl_MouseDown);
   this.gameControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gameControl_MouseUp);
   // 
   // Form1
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(1016, 573);
   this.Controls.Add(this.globalTab);
   this.Controls.Add(this.simButton);
   this.Controls.Add(this.gameControl);
   this.Name = "Form1";
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Form1";
   this.Load += new System.EventHandler(this.Form1_Load);
   this.globalTab.ResumeLayout(false);
   this.tabPage1.ResumeLayout(false);
   this.tabPage2.ResumeLayout(false);
   this.tabPage2.PerformLayout();
   this.propertsTab.ResumeLayout(false);
   this.tabPage3.ResumeLayout(false);
   this.tabPage3.PerformLayout();
   this.tabPage4.ResumeLayout(false);
   this.tabPage4.PerformLayout();
   this.tabPage5.ResumeLayout(false);
   this.tabPage5.PerformLayout();
   this.tabPage6.ResumeLayout(false);
   this.tabPage6.PerformLayout();
   this.ResumeLayout(false);

  }

  #endregion

  private GameControl gameControl;
  public System.Windows.Forms.Button simButton;
  private System.Windows.Forms.TabControl globalTab;
  private System.Windows.Forms.TabPage tabPage1;
  private System.Windows.Forms.TabPage tabPage2;
  private System.Windows.Forms.Button addBox;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.Button pushTexture;
  private System.Windows.Forms.TextBox textureTextbox;
  private System.Windows.Forms.Label label4;
  private System.Windows.Forms.TextBox heightTextbox;
  private System.Windows.Forms.TextBox widthTextbox;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.Button smileBut;
  private System.Windows.Forms.Button button5;
  private System.Windows.Forms.Button button3;
  private System.Windows.Forms.TabControl propertsTab;
  private System.Windows.Forms.TabPage tabPage3;
  private System.Windows.Forms.TabPage tabPage4;
  private System.Windows.Forms.TabPage tabPage5;
  private System.Windows.Forms.TabPage tabPage6;
  private System.Windows.Forms.Label label6;
  private System.Windows.Forms.TextBox boxHeight;
  private System.Windows.Forms.Label label5;
  private System.Windows.Forms.TextBox boxWidth;
  private System.Windows.Forms.CheckBox isStatcBox;
  private System.Windows.Forms.Label label17;
  private System.Windows.Forms.TextBox massTextBox;
  private System.Windows.Forms.Label label18;
  private System.Windows.Forms.TextBox ellipseRadY;
  private System.Windows.Forms.Label label19;
  private System.Windows.Forms.TextBox ellipseRadX;
  private System.Windows.Forms.Label label21;
  private System.Windows.Forms.TextBox textureGeomHeight;
  private System.Windows.Forms.Label label22;
  private System.Windows.Forms.TextBox textureGeomWidth;
  private System.Windows.Forms.Label label8;
  private System.Windows.Forms.CheckBox checkBox2;
  private System.Windows.Forms.TextBox textBox8;
  private System.Windows.Forms.Label label9;
  private System.Windows.Forms.TextBox textBox9;
  private System.Windows.Forms.Label label10;
  private System.Windows.Forms.TextBox textBox10;
  private System.Windows.Forms.Label label11;
  private System.Windows.Forms.CheckBox checkBox3;
  private System.Windows.Forms.TextBox textBox11;
  private System.Windows.Forms.Label label12;
  private System.Windows.Forms.TextBox textBox12;
  private System.Windows.Forms.Label label13;
  private System.Windows.Forms.TextBox textBox13;
  private System.Windows.Forms.Label label15;
  private System.Windows.Forms.Button textureGeomOpenFile;
  private System.Windows.Forms.TextBox textureGeomTexture;
  private System.Windows.Forms.Button addTextureGeom;
  private System.Windows.Forms.Button addCircle;
  private System.Windows.Forms.Button addEllipse;
  private System.Windows.Forms.TextBox nameTextbox;
  private System.Windows.Forms.Label label16;
  private System.Windows.Forms.TextBox circleRad;
  private System.Windows.Forms.Label label7;
  private System.Windows.Forms.TextBox frictionBox;
  private System.Windows.Forms.OpenFileDialog openFileDialog1;

 }
}


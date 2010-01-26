using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DarkSide;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Platformator
{
 public partial class Form1 : Form
 {
  #region INSTANCE
  private static Form1 _instance = null;
  public static Form1 Instance
  {
   get
   {
    if (_instance == null)
    {
     _instance = new Form1();
    }
    return _instance;
   }
   set
   {
    _instance = value;
   }
  }
  #endregion

  public Form1()
  {
   _instance = this;
   InitializeComponent();
  }
  public void Form1_Load(object sender, EventArgs e)
  {
   string dir = Path.GetFullPath("platformator.exe").Replace("platformator.exe", "") + "scripts\\";
   DirectoryInfo info = new DirectoryInfo(dir);
   FileInfo[] files = info.GetFiles();
   foreach (FileInfo file in files)
   {
    if (file.Name == "ContentPipeline.xml") File.Delete(file.FullName);
    ContentFactory.Instance.Build(file.FullName);
   }


   InitForm initForm = new InitForm();
   initForm.ShowDialog(this);
   this.MouseWheel += gameControl_MouseMove_1;
   widthTextbox.TextChanged += widthTextChanged;
   heightTextbox.TextChanged += heightTextChanged;
  }

  Vector2 campos = new Vector2(0, 0);
  private void gameControl_MouseMove_1(object sender, MouseEventArgs e)
  {
   PLATFORMER pl = Game1.Instance.platformer;

   if (e.Delta != 0) pl.p.camera.Height -= 5 * pl.p.time.dt * e.Delta;


   if (cameraMove && campos != Vector2.Zero)
   {
    campos -= new Vector2(e.X, e.Y);
    campos = new Vector2(campos.X, -campos.Y) * pl.p.time.dt * pl.p.camera.Height / 10;
    pl.p.camera.Position = campos;
   }
   if (ObjectFactory.Instance.click == true)
    ObjectFactory.Instance.setPos(Cursor.Position.X - DesktopLocation.X - GameControl.Instance.Location.X,
     Cursor.Position.Y - DesktopLocation.Y - GameControl.Instance.Location.Y - 22);

   campos = new Vector2(e.X, e.Y);

   pl.p.camera.Position = Vector2.Zero;
   pl.p.camera.Update();
  }



  bool cameraMove = false;
  private void gameControl_MouseUp(object sender, MouseEventArgs e)
  {
   cameraMove = false;
   campos = new Vector2(e.X, e.Y);
  }
  private void gameControl_MouseDown(object sender, MouseEventArgs e)
  {
   cameraMove = true;
   Cursor.Current = System.Windows.Forms.Cursors.NoMove2D;
   campos = new Vector2(e.X, e.Y);
   if (e.Button != MouseButtons.Left) return;
   if (ObjectFactory.Instance.click)
   {
    ObjectFactory.Instance.click = false;
    globalIndex = -1;
    geomTabIndex = -1;
    ClearProperties();
    globalTab.SelectedTab = globalTab.TabPages[0];
   }
   else
   {
    OBJECT obj = ObjectFactory.Instance.Intersect(Cursor.Position.X - DesktopLocation.X - GameControl.Instance.Location.X,
                                                  Cursor.Position.Y - DesktopLocation.Y - GameControl.Instance.Location.Y - 22);
    if (obj != null)
    {
     globalTab.SelectedTab = globalTab.TabPages[1];
     PushObjProperties(obj);
     cameraMove = false;
    }
    else
    {
     globalTab.SelectedTab = globalTab.TabPages[0];
     ClearProperties();
    }
   }
  }


  private void simButton_Click(object sender, EventArgs e)
  {
   if (simButton.Text == "simulation (OFF)") simButton.Text = "simulation (ON)";
   else simButton.Text = "simulation (OFF)";
  }

  private void PushObjProperties(OBJECT obj)
  {
   nameTextbox.Text = obj.name.ToString();
   textureTextbox.Text = obj.mesh.texname;
   widthTextbox.Text = obj.mesh.wh.X.ToString();
   heightTextbox.Text = obj.mesh.wh.Y.ToString();
   massTextBox.Text = obj.objDesc[0].mass.ToString();
   if (obj.geomType == GEOMTYPE.box)
   {
    boxWidth.Text = obj.objDesc[0].wh.X.ToString();
    boxHeight.Text = obj.objDesc[0].wh.Y.ToString();
    geomTabIndex = 0;
    propertsTab.SelectedTab = propertsTab.TabPages[0];
   }
   if (obj.geomType == GEOMTYPE.circle)
   {
    circleRad.Text = obj.objDesc[0].radius.ToString();
    geomTabIndex = 1;
    propertsTab.SelectedTab = propertsTab.TabPages[1];
   }
   if (obj.geomType == GEOMTYPE.ellipse)
   {
    ellipseRadX.Text = obj.objDesc[0].xradius.ToString();
    ellipseRadY.Text = obj.objDesc[0].yradius.ToString();
    geomTabIndex = 2;
    propertsTab.SelectedTab = propertsTab.TabPages[2];
   }
   if (obj.geomType == GEOMTYPE.verts)
   {
    textureGeomWidth.Text = obj.mesh.wh.X.ToString();
    textureGeomHeight.Text = obj.mesh.wh.Y.ToString();
    textureGeomTexture.Text = obj.mesh.tex.Name.ToString();
    geomTabIndex = 3;
    propertsTab.SelectedTab = propertsTab.TabPages[3];
   }
   frictionBox.Text = obj.objDesc[0].geom.FrictionCoefficient.ToString();
   isStatcBox.Checked = obj.objDesc[0].body.IsStatic;
   ObjectFactory.Instance.makeLast(obj);
   ObjectFactory.Instance.click = true;
  }
  private void ClearProperties()
  {
   nameTextbox.Text = "";
   textureTextbox.Text = "";
   widthTextbox.Text = "";
   heightTextbox.Text = "";
   massTextBox.Text = "";
   boxWidth.Text = "";
   boxHeight.Text = "";
   circleRad.Text = "";
   ellipseRadX.Text = "";
   ellipseRadY.Text = "";
   textureGeomHeight.Text = "";
   textureGeomWidth.Text = "";
   textureGeomTexture.Text = "";
   frictionBox.Text = "";
   isStatcBox.Checked = false;
   globalIndex = -1;
   geomTabIndex = -1;
  }

  int globalIndex = -1;
  int geomTabIndex = -1;
  private void smileBut_Click(object sender, EventArgs e)
  {
   if (smileBut.Text == "O___________O") smileBut.Text = "^_^";
   smileBut.Text = smileBut.Text.Insert(1, "_");
   if (smileBut.Text.Length > 12) smileBut.Text = "O___________O";
  }


  private void addBox_Click(object sender, EventArgs e)
  {
   ClearProperties();
   globalTab.SelectedTab = globalTab.TabPages[1];
   globalIndex = 1;
   geomTabIndex = 0;

   nameTextbox.Text = "box" + ObjectFactory.Instance.boxCount.ToString();
   textureTextbox.Text = "none";

   Texture2D tex = Game1.Instance.Content.Load<Texture2D>("textures/none");

   widthTextbox.Text = "1";
   heightTextbox.Text = "1";
   frictionBox.Text = "1";

   propertsTab.SelectedTab = propertsTab.TabPages[geomTabIndex];

   massTextBox.Text = "1";
   boxWidth.Text = "1";
   boxHeight.Text = "1";

   ObjectFactory.Instance.nextGeomType = GEOMTYPE.box;
   ObjectFactory.Instance.click = true;
   ObjectFactory.Instance.addBox(Game1.Instance.platformer.p, nameTextbox.Text, textureTextbox.Text,
     new Vector2(Convert.ToSingle(widthTextbox.Text), Convert.ToSingle(heightTextbox.Text)),
     new Vector2(Convert.ToSingle(boxWidth.Text), Convert.ToSingle(boxHeight.Text)),
     Convert.ToSingle(massTextBox.Text), Convert.ToSingle(frictionBox.Text), isStatcBox.Checked);
  }
  private void addCircle_Click(object sender, EventArgs e)
  {
   ClearProperties();
   globalTab.SelectedTab = globalTab.TabPages[1];
   globalIndex = 1;
   geomTabIndex = 1;

   nameTextbox.Text = "circle" + ObjectFactory.Instance.circleCount.ToString();
   textureTextbox.Text = "none";

   Texture2D tex = Game1.Instance.Content.Load<Texture2D>("textures/none");

   widthTextbox.Text = "2";
   heightTextbox.Text = "2";
   frictionBox.Text = "1";

   propertsTab.SelectedTab = propertsTab.TabPages[geomTabIndex];

   massTextBox.Text = "1";
   circleRad.Text = "1";

   ObjectFactory.Instance.nextGeomType = GEOMTYPE.circle;
   ObjectFactory.Instance.click = true;
   ObjectFactory.Instance.addCircle(Game1.Instance.platformer.p, nameTextbox.Text, textureTextbox.Text,
     new Vector2(Convert.ToSingle(widthTextbox.Text), Convert.ToSingle(heightTextbox.Text)),
     Convert.ToSingle(circleRad.Text),
     Convert.ToSingle(massTextBox.Text), Convert.ToSingle(frictionBox.Text), isStatcBox.Checked);
  }
  private void addEllipse_Click(object sender, EventArgs e)
  {
   ClearProperties();
   globalTab.SelectedTab = globalTab.TabPages[1];
   globalIndex = 1;
   geomTabIndex = 2;

   nameTextbox.Text = "ellipse" + ObjectFactory.Instance.ellipseCount.ToString();
   textureTextbox.Text = "none";

   Texture2D tex = Game1.Instance.Content.Load<Texture2D>("textures/none");

   widthTextbox.Text = "2";
   heightTextbox.Text = "2";
   frictionBox.Text = "1";

   propertsTab.SelectedTab = propertsTab.TabPages[geomTabIndex];

   massTextBox.Text = "1";
   ellipseRadX.Text = "1";
   ellipseRadY.Text = "1";

   ObjectFactory.Instance.nextGeomType = GEOMTYPE.ellipse;
   ObjectFactory.Instance.click = true;
   ObjectFactory.Instance.addEllipse(Game1.Instance.platformer.p, nameTextbox.Text, textureTextbox.Text,
     new Vector2(Convert.ToSingle(widthTextbox.Text), Convert.ToSingle(heightTextbox.Text)),
     new Vector2(Convert.ToSingle(ellipseRadX.Text), Convert.ToSingle(ellipseRadY.Text)),
     Convert.ToSingle(massTextBox.Text), Convert.ToSingle(frictionBox.Text), isStatcBox.Checked);
  }



  private void globalTab_Selected(object sender, TabControlEventArgs e)
  {
   if (globalIndex != -1) globalTab.SelectedTab = globalTab.TabPages[globalIndex];
  }
  private void propertsTab_Selected(object sender, TabControlEventArgs e)
  {
   if (geomTabIndex != -1) propertsTab.SelectedTab = propertsTab.TabPages[geomTabIndex];
  }

  private void ParametersChanged(object sender, EventArgs e)
  {
   if ((sender as Control).Text.ToString() == "") return;
   if (ObjectFactory.Instance.click && ObjectFactory.Instance.nextGeomType == GEOMTYPE.box)
   {
    ObjectFactory.Instance.removeLast();
    ObjectFactory.Instance.addBox(Game1.Instance.platformer.p, nameTextbox.Text, textureTextbox.Text,
     new Vector2(Convert.ToSingle(widthTextbox.Text), Convert.ToSingle(heightTextbox.Text)),
     new Vector2(Convert.ToSingle(boxWidth.Text), Convert.ToSingle(boxHeight.Text)),
     Convert.ToSingle(massTextBox.Text), Convert.ToSingle(frictionBox.Text), isStatcBox.Checked);
   }
   if (ObjectFactory.Instance.click && ObjectFactory.Instance.nextGeomType == GEOMTYPE.circle)
   {
    ObjectFactory.Instance.removeLast();
    ObjectFactory.Instance.addCircle(Game1.Instance.platformer.p, nameTextbox.Text, textureTextbox.Text,
      new Vector2(Convert.ToSingle(widthTextbox.Text), Convert.ToSingle(heightTextbox.Text)),
      Convert.ToSingle(circleRad.Text),
      Convert.ToSingle(massTextBox.Text), Convert.ToSingle(frictionBox.Text), isStatcBox.Checked);
   }
   if (ObjectFactory.Instance.click && ObjectFactory.Instance.nextGeomType == GEOMTYPE.ellipse)
   {
    ObjectFactory.Instance.removeLast();
    ObjectFactory.Instance.addEllipse(Game1.Instance.platformer.p, nameTextbox.Text, textureTextbox.Text,
      new Vector2(Convert.ToSingle(widthTextbox.Text), Convert.ToSingle(heightTextbox.Text)),
      new Vector2(Convert.ToSingle(ellipseRadX.Text), Convert.ToSingle(ellipseRadY.Text)),
      Convert.ToSingle(massTextBox.Text), Convert.ToSingle(frictionBox.Text), isStatcBox.Checked);
   }
  }
  private void widthTextChanged(object sender, EventArgs e)
  {
   if ((sender as Control).Text.ToString() == "") return;
   if (!ObjectFactory.Instance.click) return;
   if (ObjectFactory.Instance.nextGeomType == GEOMTYPE.box)
   {
    boxWidth.Text = (Convert.ToSingle(widthTextbox.Text) / 1).ToString();
   }
   if (ObjectFactory.Instance.nextGeomType == GEOMTYPE.circle)
   {
    circleRad.Text = (Convert.ToSingle(widthTextbox.Text) / 2).ToString();
   }
   if (ObjectFactory.Instance.nextGeomType == GEOMTYPE.ellipse)
   {
    ellipseRadX.Text = (Convert.ToSingle(widthTextbox.Text) / 2).ToString();
   }
  }
  private void heightTextChanged(object sender, EventArgs e)
  {
   if ((sender as Control).Text.ToString() == "") return;
   if (!ObjectFactory.Instance.click) return;
   if (ObjectFactory.Instance.nextGeomType == GEOMTYPE.box)
   {
    boxHeight.Text = (Convert.ToSingle(heightTextbox.Text) / 1).ToString();
   }
   if (ObjectFactory.Instance.nextGeomType == GEOMTYPE.circle)
   {
    circleRad.Text = (Convert.ToSingle(heightTextbox.Text) / 2).ToString();
   }
   if (ObjectFactory.Instance.nextGeomType == GEOMTYPE.ellipse)
   {
    ellipseRadY.Text = (Convert.ToSingle(heightTextbox.Text) / 2).ToString();
   }
  }

  private void pushTextureClick(object sender, EventArgs e)
  {
   string s = getName();
   if (s != "error") textureTextbox.Text = s;
  }
  private string getName()
  {
   openFileDialog1.RestoreDirectory = true;
   openFileDialog1.InitialDirectory = Path.GetFullPath("textures");
   openFileDialog1.Filter = "(*.BMP;*.JPG;*.JPEG;*.GIF;*.TGA;*.DDS)|*.BMP;*.JPG;*.JPEG;*.GIF;*.TGA;*.DDS";
   openFileDialog1.ShowDialog();
   if (openFileDialog1.FileName == "") return "error";

   if (ContentFactory.Instance.Build(openFileDialog1.FileName) == false) return "error";
   return Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
  }

  private void getWidthTexture(object sender, EventArgs e)
  {
   if (ObjectFactory.Instance.click) widthTextbox.Text = ObjectFactory.Instance.focusObj.mesh.tex.Width.ToString();
  }
  private void getHeightTexture(object sender, EventArgs e)
  {
   if (ObjectFactory.Instance.click) heightTextbox.Text = ObjectFactory.Instance.focusObj.mesh.tex.Height.ToString();
  }

  private void exitToolStripMenuItem_Click(object sender, EventArgs e)
  {
   this.Close();
  }

  private void openToolStripMenuItem_Click(object sender, EventArgs e)
  {
   this.Hide();
   InitForm.Instance = new InitForm();
   InitForm.Instance.InitForm_Load(null, null);
   InitForm.Instance.listBox1.ClearSelected();
   InitForm.Instance.listBox1.SelectedItems.Add(InitForm.Instance.listBox1.Items[InitForm.Instance.listBox1.Items.Count - 1]);
   InitForm.Instance.Show();
   InitForm.Instance.OpenSave.Text = "open";
   InitForm.Instance.listBox1.Text = "add lua script";
   InitForm.Instance.button3_Click_1(null, null);
  }

  private void newToolStripMenuItem_Click(object sender, EventArgs e)
  {
   this.Hide();
   InitForm.Instance = new InitForm();
   InitForm.Instance.InitForm_Load(null, null);
   InitForm.Instance.listBox1.ClearSelected();
   InitForm.Instance.listBox1.SelectedItems.Add(InitForm.Instance.listBox1.Items[InitForm.Instance.listBox1.Items.Count - 2]);
   InitForm.Instance.listBox1.Update();
   InitForm.Instance.listBox1.Refresh();

   InitForm.Instance.OpenSave.Text = "save";
   InitForm.Instance.listBox1.Text = "new script";
   InitForm.Instance.Show();
   InitForm.Instance.button3_Click_1(null, null);
  }

  private void saveToolStripMenuItem_Click(object sender, EventArgs e)
  {
   string luafile = Path.GetDirectoryName("platformator.exe") + "scripts\\" + GameControl.Instance.editorname + ".lua";
   File.Delete(luafile);

   DEVICE_PACK p = GameControl.Instance.game.platformer.p;
   FileStream file = File.Open(luafile, FileMode.OpenOrCreate) as FileStream;
   StreamWriter sw = new StreamWriter(file);
   sw.WriteLine("p=platp");


   sw.WriteLine("\n\nwh = Vector2(80, 60)");
   sw.WriteLine("background = MESH2D()");
   sw.WriteLine("background:Init(p, \"background_1\", \"background\", wh, \"all\")");
   sw.WriteLine("background.Position = Vector2(0, 0)");


   sw.WriteLine("\n\nwh = Vector2(100, 40)");
   sw.WriteLine("ground = OBJECT()");
   sw.WriteLine("ground.debugVerts = true");
   sw.WriteLine("ground:Init(p,\"" + (p.lua.getObject("ground") as OBJECT).mesh.texname + "\", \"background\", wh, \"all\")");
   sw.WriteLine("ground:makeVerts(\"" + (p.lua.getObject("ground") as OBJECT).mesh.texname + "\", wh)");
   sw.WriteLine("ground:setFriction(0)");


   sw.WriteLine("\n\nplayer = PLAYER()");
   sw.WriteLine("pos = Vector2(0,10)");
   sw.WriteLine("player:Init(p)");
   sw.WriteLine("player.Position = pos");


   sw.WriteLine("\n\nwh = Vector2(3, 3)");
   sw.WriteLine("oops = MESH2D()");
   sw.WriteLine("oops:Init(p, \"oops_1\", \"oops\", wh, \"updateOnly\")");


   sw.WriteLine("\n\n");

   foreach (OBJECT obj in ObjectFactory.Instance.objList)
   {
    sw.WriteLine("\n\n");
    sw.WriteLine("wh = Vector2(" + ToFloat(obj.objDesc[0].wh.X.ToString()) + ", " + ToFloat(obj.objDesc[0].wh.Y.ToString()) + " )");
    sw.WriteLine(obj.name + " = OBJECT()");
    sw.WriteLine(obj.name + ".name =" + "\"" + obj.name + "\"");
    sw.WriteLine(obj.name + ":Init(p, \"" + obj.mesh.texname + "\"" + ", \"ui\", wh, \"all\")");


    if (obj.geomType == GEOMTYPE.box) sw.WriteLine(obj.name + ":makeBox(" + ToFloat(obj.objDesc[0].wh.X.ToString()) + ", " + ToFloat(obj.objDesc[0].wh.Y.ToString()) + ", " + ToFloat(obj.objDesc[0].mass.ToString()) + ")");
    if (obj.geomType == GEOMTYPE.circle) sw.WriteLine(obj.name + ":makeCircle(" + ToFloat(obj.objDesc[0].radius.ToString()) + ", " + ToFloat(obj.objDesc[0].mass.ToString()) + ")");
    if (obj.geomType == GEOMTYPE.ellipse) sw.WriteLine(obj.name + ":makeEllipse(" + ToFloat(obj.objDesc[0].xradius.ToString()) + ", " + ToFloat(obj.objDesc[0].xradius.ToString()) + ", " + ToFloat(obj.objDesc[0].mass.ToString()) + ")");

    sw.WriteLine(obj.name + ".Position = Vector2(" + ToFloat(obj.objDesc[0].geom.Position.X.ToString()) + ", " + ToFloat(obj.objDesc[0].geom.Position.Y.ToString()) + " )");
    sw.WriteLine(obj.name + ".Rotation = " + ToFloat(obj.Rotation.ToString()));
    sw.WriteLine(obj.name + ":setFriction(" + ToFloat(obj.objDesc[0].geom.FrictionCoefficient.ToString()) + ")");
   }

   sw.Close();
   file.Close();
  }
  string ToFloat(string s)
  {
   return s.Replace(",", ".");
  }


 }//for
}//namespace

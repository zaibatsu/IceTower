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
  }
  #endregion

  public Form1()
  {
   _instance = this;
   InitializeComponent();
  }
  private void Form1_Load(object sender, EventArgs e)
  {
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

   if (e.Delta > 0) pl.p.camera.Height -= 1000 * pl.p.time.dt;
   if (e.Delta < 0) pl.p.camera.Height += 1000 * pl.p.time.dt;


   if (cameraMove && campos != Vector2.Zero)
   {
    campos -= new Vector2(e.X, e.Y);
    campos = new Vector2(campos.X,-campos.Y) * pl.p.time.dt * pl.p.camera.Height/10;
    pl.p.camera.Position = campos;
   }
   if (ObjectFactory.Instance.click == true) ObjectFactory.Instance.setPos(Cursor.Position.X - DesktopLocation.X, Cursor.Position.Y - DesktopLocation.Y - 22);

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
   if (ObjectFactory.Instance.click && e.Button == MouseButtons.Left)
   {
    ObjectFactory.Instance.click = false;
    globalIndex = -1;
    geomTabIndex = -1;
    ClearProperties();
    globalTab.SelectedTab = globalTab.TabPages[0];
   }
   else
   {
    OBJECT obj = ObjectFactory.Instance.Intersect(Cursor.Position.X - DesktopLocation.X, Cursor.Position.Y - DesktopLocation.Y - 22);
    if (obj != null)
    {
     globalTab.SelectedTab = globalTab.TabPages[1];
     PushObjProperties(obj);
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
   textureTextbox.Text = obj.mesh.tex.Name.ToString();
   widthTextbox.Text = obj.mesh.wh.X.ToString();
   heightTextbox.Text = obj.mesh.wh.Y.ToString();
   massTextBox.Text = obj.objDesc[0].mass.ToString();
   if (obj.geomType == GEOMTYPE.box)
   {
    boxWidth.Text = obj.objDesc[0].wh.X.ToString();
    boxHeight.Text = obj.objDesc[0].wh.Y.ToString();
   }
   if (obj.geomType == GEOMTYPE.circle)
   {
    circleRad.Text = obj.objDesc[0].radius.ToString();
   }
   if (obj.geomType == GEOMTYPE.box)
   {
    ellipseRadX.Text = obj.objDesc[0].xradius.ToString();
    ellipseRadY.Text = obj.objDesc[0].yradius.ToString();
   }
   if (obj.geomType == GEOMTYPE.verts)
   {
    textureGeomWidth.Text = obj.mesh.wh.X.ToString();
    textureGeomHeight.Text = obj.mesh.wh.Y.ToString();
    textureGeomTexture.Text = obj.mesh.tex.Name.ToString();
   }
   frictionBox.Text = obj.objDesc[0].geom.FrictionCoefficient.ToString();
   isStatcBox.Checked = obj.objDesc[0].body.IsStatic;
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
   globalTab.SelectedTab = globalTab.TabPages[1];
   globalIndex = 1;
   geomTabIndex = 0;

   nameTextbox.Text = "box" + ObjectFactory.Instance.boxCount.ToString();
   textureTextbox.Text = "none";

   Texture2D tex = Game1.Instance.Content.Load<Texture2D>("textures/none");
   ObjectFactory.Instance.texList.Add(tex);

   widthTextbox.Text = "1";
   heightTextbox.Text = "1";
   frictionBox.Text = "1";

   propertsTab.SelectedTab = propertsTab.TabPages[0];

   massTextBox.Text = "1";
   boxWidth.Text = "1";
   boxHeight.Text = "1";

   ObjectFactory.Instance.nextGeomType = GEOMTYPE.box;
   ObjectFactory.Instance.click = true;
   ObjectFactory.Instance.addBox(Game1.Instance.platformer.p, "nothing", "none", new Vector2(1, 1), new Vector2(1, 1), 1, 1, false);
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
   if (ObjectFactory.Instance.click && ObjectFactory.Instance.nextGeomType == GEOMTYPE.box)
   {
    ObjectFactory.Instance.removeLast();
    ObjectFactory.Instance.addBox(Game1.Instance.platformer.p, nameTextbox.Text, textureTextbox.Text,
     new Vector2(Convert.ToInt32(widthTextbox.Text), Convert.ToInt32(heightTextbox.Text)),
     new Vector2(Convert.ToInt32(boxWidth.Text), Convert.ToInt32(boxHeight.Text)),
     Convert.ToInt32(massTextBox.Text), Convert.ToInt32(frictionBox.Text), isStatcBox.Checked);
   }
  }
  private void widthTextChanged(object sender, EventArgs e)
  {
   if (ObjectFactory.Instance.click && ObjectFactory.Instance.nextGeomType == GEOMTYPE.box)
   {
    boxWidth.Text = widthTextbox.Text;
   }
  }
  private void heightTextChanged(object sender, EventArgs e)
  {
   if (ObjectFactory.Instance.click && ObjectFactory.Instance.nextGeomType == GEOMTYPE.box)
   {
    boxHeight.Text = heightTextbox.Text;
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


 }//for
}//namespace

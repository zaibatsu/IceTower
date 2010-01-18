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

namespace Platformator
{
 public partial class Form1 : Form
 {
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

  InitForm initForm = null;
  public Form1()
  {
   _instance = this;
   InitializeComponent();
  }


  private void button1_Click(object sender, EventArgs e)
  {
   ObjectFactory.Instance.addCibylia(gameControl.game.platformer.p);
  }
  private void gameControl_Click(object sender, EventArgs e)
  {
   if(ObjectFactory.Instance.click)
   {
    string s = ObjectFactory.Instance.setPos(Cursor.Position.X - DesktopLocation.X, Cursor.Position.Y - DesktopLocation.Y - 22);
    ObjectFactory.Instance.click = false;
   }
   else
   {
    campos = Game1.Instance.platformer.player.Position;
    cameraMove = true;
   }
  }


  Vector2 campos = new Vector(0, 0);
  private void gameControl_MouseMove(object sender, MouseEventArgs e)
  {
   if (cameraMove)
   {
    campos += sender as Point;
    Game1.Instance.p.camera.Position = campos;
   }
   else
   {
    if (ObjectFactory.Instance.click == false) return;
    string s = ObjectFactory.Instance.setPos(Cursor.Position.X - DesktopLocation.X, Cursor.Position.Y - DesktopLocation.Y - 22);
   }
  }
  private void Form1_Load(object sender, EventArgs e)
  {
   initForm = new InitForm();
   initForm.ShowDialog(this);
  }


  bool cameraMove = false;
  private void gameControl_MouseUp(object sender, MouseEventArgs e)
  {
   cameraMove = false;
  }

 }//form
}//namespace

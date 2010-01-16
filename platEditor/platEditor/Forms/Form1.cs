using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace platEditor
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
   string s = ObjectFactory.Instance.setPos(Cursor.Position.X - DesktopLocation.X, Cursor.Position.Y - DesktopLocation.Y - 22);
   ObjectFactory.Instance.click = false;
  }

  private void gameControl_MouseMove(object sender, MouseEventArgs e)
  {
   if (ObjectFactory.Instance.click == false) return;
   string s = ObjectFactory.Instance.setPos(Cursor.Position.X - DesktopLocation.X, Cursor.Position.Y - DesktopLocation.Y - 22);
  }

  private void Form1_Load(object sender, EventArgs e)
  {
   initForm = new InitForm();
   initForm.ShowDialog(this);
  }

 }//form
}//namespace

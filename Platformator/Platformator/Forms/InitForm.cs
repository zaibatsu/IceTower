using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DarkSide;
using Microsoft.Xna.Framework.Graphics;

namespace Platformator
{
 public partial class InitForm : Form
 {
  private static InitForm _instance = null;
  public static InitForm Instance
  {
   get
   {
    if (_instance == null)
    {
     _instance = new InitForm();
    }
    return _instance;
   }
  }


  public InitForm()
  {
   _instance = this;
   InitializeComponent();
  }
  private void InitForm_Load(object sender, EventArgs e)
  {
   string path = ".\\Content\\";
   String fullPath = Path.GetFullPath(Path.GetDirectoryName(path));

   String[] scripts = Directory.GetFiles(fullPath, "*.lil");
   listBox1.Items.Clear();

   string temp;
   foreach (string s in scripts)
   {
    temp = s.Remove(0, fullPath.Length + 1);
    if (temp.Substring(0, 4) != "plat") continue;
    listBox1.Items.Add(temp);
   }
   listBox1.Items.Add("new script");
   listBox1.Items.Add("add lua script");
  }
  private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
  {
   panel2.Enabled = true;
   progressBar1.Maximum = 9;
   progressBar1.Minimum = 0;
   textBox1.Text = "";
   textBox2.Text = "";

   if (listBox1.Text.Substring(0, 4) == "plat")
   {
    progressBar1.Value = 9;

    button1.Enabled = true;
    textBox1.Text = listBox1.Text;
    button2.Enabled = false;
    button3.Enabled = false;

    textBox1.Enabled = false;
    textBox2.Enabled = false;
    button3.Text = "save";
   }
   if (listBox1.Text == "new script")
   {
    progressBar1.Value = 3;
    button1.Enabled = false;
    textBox1.Text = "";
    button2.Enabled = true;
    button3.Enabled = true;

    textBox1.Enabled = true;
    textBox2.Enabled = true;
    button3.Text = "save";
   }
   if (listBox1.Text == "add lua script")
   {
    progressBar1.Value = 3;
    button1.Enabled = false;
    textBox1.Text = "";
    button2.Enabled = false;
    button3.Enabled = true;
    button3.Text = "open";

    textBox1.Enabled = true;
    textBox2.Enabled = false;
   }
  }
  private void button1_Click(object sender, EventArgs e)
  {
   button1.Enabled = false;
   if (textBox1.Text == "") return;

   button1.Text = "wait...";
   progressBar1.Value = 1;
   if (listBox1.Text == "new script")
   {
    FileStream file = saveFileDialog1.OpenFile() as FileStream;
    StreamWriter sw = new StreamWriter(file);
    sw.WriteLine("p=platp");
    sw.WriteLine("\n\nwh = Vector2(80, 60)");
    sw.WriteLine("background = MESH2D()");

    sw.WriteLine("background:Init(p,\"" + Path.GetFileNameWithoutExtension(textBox2.Text) + "\", \"background\", wh, \"all\")");
    sw.WriteLine("background.Position = Vector2(0, 0)");

    sw.WriteLine("\n\nplayer = PLAYER()");
    sw.WriteLine("pos = Vector2(0,50)");
    sw.WriteLine("player:Init(p)");
    sw.WriteLine("player.Position = pos");
    sw.Close();
    file.Close();

    progressBar1.Value += 2;
    button1.Text = "Compiling texture...";
    if (ContentFactory.Instance.Build(textBox2.Text) == false)
    {
     MessageBox.Show("Error texture content building.");
     return;
    }
    progressBar1.Value += 2;
    button1.Text = "Compiling script...";
    if (ContentFactory.Instance.Build(textBox1.Text) == false)
    {
     MessageBox.Show("Error script content building.");
     return;
    }
    progressBar1.Value += 2;
    button1.Text = "OK ;)";
   }
   progressBar1.Value += 10;
   GameControl.Instance.InitEditor(Path.GetFileNameWithoutExtension(textBox1.Text));
   this.Hide();
  }
  private void InitForm_FormClosed(object sender, FormClosedEventArgs e)
  {
   Form1.Instance.Dispose();
   Form1.Instance.Close();
  }
  private void button3_Click_1(object sender, EventArgs e)
  {
   if (button3.Text == "open")
   {
    openFileDialog1.RestoreDirectory = true;
    openFileDialog1.InitialDirectory = Path.GetFullPath("scripts");
    openFileDialog1.Filter = "(*.lua)|*.lua";
    openFileDialog1.ShowDialog();
    if (Path.GetFileNameWithoutExtension(openFileDialog1.FileName).Substring(0, 4) != "plat") return;
    if (openFileDialog1.FileName == "") return;
    textBox1.Text = openFileDialog1.FileName;
    progressBar1.Value = 9;
    button1.Enabled = true;

    return;
   }
   saveFileDialog1.RestoreDirectory = true;
   saveFileDialog1.InitialDirectory = Path.GetFullPath("scripts");
   saveFileDialog1.Filter = "(*.lua)|*.lua";
   saveFileDialog1.ShowDialog();
   if (saveFileDialog1.FileName == "") return;
   textBox1.Text = saveFileDialog1.FileName;
   if (!Path.GetFileName(textBox1.Text).Contains("plat"))
   {
    textBox1.Text = "plat" + Path.GetFileName(textBox1.Text);
    saveFileDialog1.FileName = saveFileDialog1.FileName.Replace(Path.GetFileName(saveFileDialog1.FileName), textBox1.Text);
    textBox1.Text = saveFileDialog1.FileName;
   }
   if (textBox2.Text != "")
   {
    progressBar1.Value = 9;
    button1.Enabled = true;
   }
   else progressBar1.Value += 3;
  }
  private void button2_Click(object sender, EventArgs e)
  {
   openFileDialog1.RestoreDirectory = true;
   openFileDialog1.InitialDirectory = Path.GetFullPath("textures");
   openFileDialog1.Filter = "(*.BMP;*.JPG;*.JPEG;*.GIF;*.TGA;*.DDS)|*.BMP;*.JPG;*.JPEG;*.GIF;*.TGA;*.DDS";
   openFileDialog1.ShowDialog();
   if (openFileDialog1.FileName == "") return;
   textBox2.Text = openFileDialog1.FileName;
   if (textBox1.Text != "")
   {
    progressBar1.Value = 9;
    button1.Enabled = true;
   }
   else progressBar1.Value += 3;
  }


 }//class
}//ns

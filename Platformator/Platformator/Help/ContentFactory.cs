using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XnaDevRu.ContentBuilder;
using XnaDevRu.ContentBuilder.Framework;
using System.IO;

namespace Platformator
{
 class ContentFactory
 {
  private static ContentFactory _instance = null;
  public static ContentFactory Instance
  {
   get
   {
    if (_instance == null)
    {
     _instance = new ContentFactory();
    }
    return _instance;
   }
  }

  private ContentProject _project = new ContentProject();

  ContentFactory()
  {
   _instance = this;
  }
  public void Clear()
  {
   return;
//    while (_project.ContentFiles.Count!=0)
//    {
//     _project.ContentFiles.Remove(_project.ContentFiles[0]);
//    }
  }
  public bool Build(string fileName)
  {
   string exepath = System.Windows.Forms.Application.StartupPath;
   ContentFactory.Instance.Clear();
   string ext = Path.GetExtension(fileName).ToLower();
   _project.ProjectOptions.RootDirectory = Path.GetFullPath(fileName).Replace(Path.GetFileName(fileName), "");
   switch (ext)
   {
    case ".bmp":
    case ".jpg":
    case ".jpeg":
    case ".tga":
    case ".dds":

     _project.ProjectOptions.OutputDirectory = exepath + "/Content/textures";
     _project.ProjectOptions.IntermediateDirectory = exepath + "/Content/temp";

     break;
    case ".lua":

     _project.ProjectOptions.OutputDirectory = exepath + "/Content/scripts";
     _project.ProjectOptions.IntermediateDirectory = exepath + "/Content/temp";

     break;
   }

   _project.InitContentFile(fileName);
   bool ret = _project.Build(false);

   if(ext == ".lua")
   {
    string outlilfile = exepath + "/Content/" + Path.GetFileNameWithoutExtension(fileName) + ".lil";
    string lilfile = exepath + "/Content/scripts/" + Path.GetFileNameWithoutExtension(fileName) + ".lil";
    File.Delete(outlilfile);
    File.Move(lilfile, exepath + "/Content/" + Path.GetFileNameWithoutExtension(fileName) + ".lil");

    string outpdbfile = exepath + "/Content/" + Path.GetFileNameWithoutExtension(fileName) + ".pdb";
    string pdbfile = exepath + "/Content/scripts/" + Path.GetFileNameWithoutExtension(fileName) + ".pdb";
    File.Delete(outpdbfile);
    File.Move(pdbfile, exepath + "/Content/" + Path.GetFileNameWithoutExtension(fileName) + ".pdb");
   }

   return ret;
  }

 }//class
}//ns

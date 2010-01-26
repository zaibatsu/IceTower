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
  string prepath = "";

  ContentFactory()
  {
   _instance = this;
  }
  public bool Build(string fileName)
  {
   if (prepath != "" && File.Exists(prepath)) File.Move(prepath, prepath + "TEMP");

   string exepath = System.Windows.Forms.Application.StartupPath;
   _project = new ContentProject();

   string ext = Path.GetExtension(fileName).ToLower();
   _project.ProjectOptions.RootDirectory = Path.GetFullPath(fileName).Replace(Path.GetFileName(fileName), "");
   switch (ext)
   {
    case ".bmp":
    case ".jpg":
    case ".jpeg":
    case ".tga":
    case ".dds":

     _project.ProjectOptions.OutputDirectory = _project.ProjectOptions.RootDirectory;
     _project.ProjectOptions.IntermediateDirectory = _project.ProjectOptions.RootDirectory;

     break;
    case ".lua":

     _project.ProjectOptions.OutputDirectory = _project.ProjectOptions.RootDirectory;
     _project.ProjectOptions.IntermediateDirectory = _project.ProjectOptions.RootDirectory;

     break;
   }



   _project.InitContentFile(fileName);
   bool ret = _project.Build(false);
   if (ret == false) return false;

   if (prepath != "" && File.Exists(prepath + "TEMP")) File.Move(prepath + "TEMP", prepath);
   prepath = _project.ProjectOptions.OutputDirectory + "\\" +Path.GetFileNameWithoutExtension(fileName) + ".xnb";

   switch(ext)
   {
    case ".lua":
    string outlilfile = _project.ProjectOptions.OutputDirectory + Path.GetFileNameWithoutExtension(fileName) + ".lil";
    string outpdbfile = _project.ProjectOptions.OutputDirectory + Path.GetFileNameWithoutExtension(fileName) + ".pdb";
    string outxnbfile = _project.ProjectOptions.OutputDirectory + Path.GetFileNameWithoutExtension(fileName) + ".xnb";
    string contPipeli = _project.ProjectOptions.OutputDirectory + "ContentPipeline.xml";
    File.Delete(contPipeli);


    if (Path.GetDirectoryName(fileName) != (exepath + "\\scripts"))
    {
     File.Copy(fileName, exepath + "\\scripts\\" + Path.GetFileNameWithoutExtension(fileName) + ".lua");
     File.Delete(fileName);
    }


    string xnbfile = exepath + "\\Content\\scripts\\" + Path.GetFileNameWithoutExtension(fileName) + ".xnb";
    File.Delete(xnbfile);
    File.Move(outxnbfile, xnbfile);

    string lilfile = exepath + "\\Content\\" + Path.GetFileNameWithoutExtension(fileName) + ".lil";
    File.Delete(lilfile);
    File.Move(outlilfile, lilfile);

    string pdbfile = exepath + "\\Content\\" + Path.GetFileNameWithoutExtension(fileName) + ".pdb";
    File.Delete(pdbfile);
    File.Move(outpdbfile, pdbfile);

    break;

    case ".bmp":
    case ".jpg":
    case ".jpeg":
    case ".tga":
    case ".dds":
    // 

    string outfile = _project.ProjectOptions.OutputDirectory + Path.GetFileNameWithoutExtension(fileName) + ".xnb";
    contPipeli = _project.ProjectOptions.OutputDirectory + "ContentPipeline.xml";
    File.Delete(contPipeli);

    string file = exepath + "\\Content\\textures\\" + Path.GetFileNameWithoutExtension(fileName) + ".xnb";
    File.Delete(file);
    File.Move(outfile, file);


    break;
   }
 
   return ret;
  }

 }//class
}//ns

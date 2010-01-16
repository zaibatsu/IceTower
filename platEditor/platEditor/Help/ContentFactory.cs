using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XnaDevRu.ContentBuilder;
using XnaDevRu.ContentBuilder.Framework;
using System.IO;

namespace platEditor
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
  public bool InitContent(string fileName)
  {
   string ext = Path.GetExtension(fileName).ToLower();
   _project.ProjectOptions.RootDirectory = Path.GetFullPath(fileName).Replace(Path.GetFileName(fileName), "");
   switch (ext)
   {
    case ".bmp":
    case ".jpg":
    case ".jpeg":
    case ".tga":
    case ".dds":

     _project.ProjectOptions.OutputDirectory = _project.ProjectOptions.RootDirectory.Replace("Debug\\textures", "Debug\\Content\\textures");
     _project.ProjectOptions.IntermediateDirectory = _project.ProjectOptions.RootDirectory;

     break;
   }

   _project.InitContentFile(fileName);
   return _project.Build(false);
  }
 }
}

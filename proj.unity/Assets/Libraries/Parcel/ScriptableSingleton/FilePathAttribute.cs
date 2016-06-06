using System;
using UnityEditorInternal;

namespace ParcelTool
{
  [AttributeUsage(AttributeTargets.Class)]
  public class FilePathAttribute : Attribute
  {
    /// <summary>
    /// The location this file path is releative too.
    /// </summary>
    public enum Location
    {
      PreferencesFolder,
      ProjectFolder
    }

    /// <summary>
    /// The filepath where this attribute is pointing. 
    /// </summary>
    public string filepath { get; protected set; }

    public FilePathAttribute(string relativePath, FilePathAttribute.Location location)
    {
      if (string.IsNullOrEmpty(relativePath))
      {
        return;
      }
      if (relativePath[0] == '/')
      {
        relativePath = relativePath.Substring(1);
      }
      if (location == FilePathAttribute.Location.PreferencesFolder)
      {
        filepath = InternalEditorUtility.unityPreferencesFolder + "/" + relativePath;
      }
      else
      {
        filepath = relativePath;
      }
    }
  }
}

using System.IO;
using UnityEditor;

namespace ParcelTool
{

  /// <summary>
  /// Used to setup all the strings we need to write for each asset. 
  /// </summary>
  public struct AssetMeta
  {
    private string m_Typename;
    private string m_AssetPath;
    private string m_Fullpath;
    private string m_Name;
    private string m_PrettyName;
    private bool m_IsResourceItem;

    public AssetMeta(string fullPath)
    {
      m_Fullpath = fullPath;
      UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(fullPath);
      m_Typename = asset.GetType().Name;

      m_IsResourceItem = m_Fullpath.Contains("/Resources/");
      m_Name = Path.GetFileNameWithoutExtension(m_Fullpath);
      m_PrettyName = StringHelpers.ToPrettyName(m_Name, true);
      m_Name = StringHelpers.ToVariableName(m_Name);

      if (m_IsResourceItem)
      {
        int pathIndex = m_Fullpath.IndexOf("/Resources/") + 11 /* 11 is how many chars the resources folder is */;
        m_AssetPath = m_Fullpath.Substring(pathIndex, fullPath.Length - pathIndex);
        m_AssetPath = m_AssetPath.Replace(Path.GetExtension(m_AssetPath), string.Empty);
      }
      else
      {
        m_AssetPath = m_Name;
      }

    }

    /// <summary>
    /// Returns true if this item belongs in the resources folder false if not. 
    /// </summary>
    public bool isResourceItem
    {
      get
      {
        return m_IsResourceItem;
      }
    }

    /// <summary>
    /// The name of the asset. 
    /// </summary>
    public string name
    {
      get
      {
        return m_Name;
      }
    }

    /// <summary>
    /// The name of the asset with spaces before capital letters. 
    /// </summary>
    public string prettyName
    {
      get
      {
        return m_PrettyName;
      }
    }

    /// <summary>
    /// The string version of it's type used to print. .GetType().Name; 
    /// </summary>
    public string typeName
    {
      get
      {
        return m_Typename;
      }
    }

    /// <summary>
    /// The full path from the root of the project to where this asset is. 
    /// </summary>
    public string fullPath
    {
      get
      {
        return m_Fullpath;
      }
    }

    /// <summary>
    /// The path from the resources folder (if a resource item) or just the asset name if it's in an
    /// Asset Bundle. 
    /// </summary>
    public string assetPath
    {
      get
      {
        return m_AssetPath;
      }
    }
  }
}

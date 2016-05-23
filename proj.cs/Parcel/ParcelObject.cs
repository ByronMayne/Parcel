using System;
using UnityEngine;

namespace ParcelTool
{ 
  [Serializable]
  public struct ParcelObject 
  {
    [SerializeField]
    private string m_AssetPath;
    [SerializeField]
    private string m_Bundlename;

    public string assetPath
    {
      get { return m_AssetPath; }
      private set { m_AssetPath = value; }
    }

    public string bundleName
    {
      get { return m_Bundlename; }
      private set { m_Bundlename = value; }
    }

    public ParcelObject(string assetPath, string bundleName)
    {
      m_AssetPath = assetPath;
      m_Bundlename = bundleName;
    }
  }
}

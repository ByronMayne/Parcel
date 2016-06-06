

using UnityEngine;

namespace ParcelTool
{
  [FilePath("ParcelSettings", FilePathAttribute.Location.ProjectFolder)]
  public class ParcelSettings : ScriptableSingleton<ParcelSettings>
  {
    [Tooltip("If true a class will be generated behind the scenes that will have a static field for every object in your asset Bundles.")]
    private bool m_GenerateBundleMap;

    [Tooltip("If true Asset Bundles will be loaded at runtime for testing. If false Asset DataBase will also be used at runtime in the editor only.")]
    private bool m_UseAssetBundleInPlayMode;

    /// <summary>
    /// Should Parcel generate a resource map for all your resources?
    /// </summary>
    public bool generateBundleMap
    {
      get { return m_GenerateBundleMap; }
      set { m_GenerateBundleMap = value; }
    }

    /// <summary>
    /// Should Parcel uses Asset Bundles at Runtime or use the Asset Database in the Editor? 
    /// </summary>
    public bool useAssetBundleInPlayMode
    {
      get { return m_UseAssetBundleInPlayMode; }
      set { m_UseAssetBundleInPlayMode = value; }
    }
  }
}

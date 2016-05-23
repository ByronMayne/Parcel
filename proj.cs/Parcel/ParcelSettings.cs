

using UnityEngine;

namespace ParcelTool
{
  [FilePath("ParcelSettings", FilePathAttribute.Location.ProjectFolder)]
  public class ParcelSettings : ScriptableSingleton<ParcelSettings>
  {
    [Tooltip("If true a class will be generated behind the scenes that will have a static field for every object in your asset Bundles.")]
    private bool m_GenerateBundleMap;


    /// <summary>
    /// Should Parcel generate a resource map for all your resources?
    /// </summary>
    public bool generateBundleMap
    {
      get { return m_GenerateBundleMap; }
      set { m_GenerateBundleMap = value; }
    }

  }
}

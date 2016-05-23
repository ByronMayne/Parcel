
using UnityEngine;

namespace ParcelTool
{
  public static partial class Parcel
  {
    public static GameObject Instantiate(string assetName, string bundleName)
    {
      return Instantiate(new ParcelObject(assetName, bundleName));
    }

    public static GameObject Instantiate(ParcelObject parcelObject)
    {
      return null;
    }
  }
}

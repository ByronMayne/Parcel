
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ParcelTool
{
  public static partial class Parcel
  {
    public static GameObject Instantiate(string assetPath, string bundleName)
    {
      return Instantiate(new ParcelObject(assetPath, bundleName));
    }

    public static GameObject Instantiate(ParcelObject parcelObject)
    {
      if (!Application.isPlaying)
      {
        Debug.LogError("Error! Parcel is not used to Instantiate objects at Edit time.");
        return null;
      }
      else
      {
        if (Application.isEditor)
        {
          if (!ParcelSettings.instance.useAssetBundleInPlayMode)
          {
            LoadAssetFromAssetDatabase<GameObject>(parcelObject);
          }
        }

        return LoadAssetFromBundle<GameObject>(parcelObject);
      }
    }

    private static T LoadAssetFromAssetDatabase<T>(ParcelObject parcelObject) where T : Object
    {
#if UNITY_EDITOR
      return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(parcelObject.assetPath);
#else
      return null; 
#endif
    }

    private static T LoadAssetFromBundle<T>(ParcelObject parcelObject) where T : Object
    {
      return null;
    }


  }
}

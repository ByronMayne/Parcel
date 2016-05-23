using UnityEngine;

namespace ParcelTool
{

	public static partial class Parcel
	{

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="assetName">The name of the asset you want to load.</param>
    /// <param name="bundleName">The bundle the asset belongs in.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this Transform transform, string assetName, string bundleName )
    {
      return Instantiate(assetName, bundleName);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="parcelObject">The parcel object that you want to Instantiate.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this Transform transform, ParcelObject parcelObject )
    {
      return Instantiate(parcelObject);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="assetName">The name of the asset you want to load.</param>
    /// <param name="bundleName">The bundle the asset belongs in.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this GameObject gameobject, string assetName, string bundleName )
    {
      return Instantiate(assetName, bundleName);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="parcelObject">The parcel object that you want to Instantiate.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this GameObject gameobject, ParcelObject parcelObject )
    {
      return Instantiate(parcelObject);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="assetName">The name of the asset you want to load.</param>
    /// <param name="bundleName">The bundle the asset belongs in.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this MonoBehaviour monobehaviour, string assetName, string bundleName )
    {
      return Instantiate(assetName, bundleName);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="parcelObject">The parcel object that you want to Instantiate.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this MonoBehaviour monobehaviour, ParcelObject parcelObject )
    {
      return Instantiate(parcelObject);
    }
	}
}


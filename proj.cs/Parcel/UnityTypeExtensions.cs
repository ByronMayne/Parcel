using UnityEngine;

namespace ParcelTool
{

	public static class UnityTypeExtensions
	{

    #region -= Transform Extensions =-
    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="assetName">The name of the asset you want to load.</param>
    /// <param name="bundleName">The bundle the asset belongs in.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this Transform transform, string assetPath, string bundleName )
    {
      return Instantiate(transform, assetPath, bundleName);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="parcelObject">The parcel object that you want to Instantiate.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this Transform transform, ParcelObject parcelObject )
    {
      return Instantiate(transform, parcelObject);
    }
    #endregion

    #region -= GameObject Extensions =-
    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="assetName">The name of the asset you want to load.</param>
    /// <param name="bundleName">The bundle the asset belongs in.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this GameObject gameobject, string assetPath, string bundleName )
    {
      return Instantiate(gameobject, assetPath, bundleName);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="parcelObject">The parcel object that you want to Instantiate.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this GameObject gameobject, ParcelObject parcelObject )
    {
      return Instantiate(gameobject, parcelObject);
    }
    #endregion

    #region -= MonoBehaviour Extensions =-
    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="assetName">The name of the asset you want to load.</param>
    /// <param name="bundleName">The bundle the asset belongs in.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this MonoBehaviour monobehaviour, string assetPath, string bundleName )
    {
      return Instantiate(monobehaviour, assetPath, bundleName);
    }

    /// <summary>
    /// Instantiate a new GameObject from Parcel using asset bundles at runtime and AssetDatabase at edit time.
    /// </summary>
    /// <param name="parcelObject">The parcel object that you want to Instantiate.</param>
    /// <returns>The instantiated prefab.</returns>
    public static GameObject Instantiate( this MonoBehaviour monobehaviour, ParcelObject parcelObject )
    {
      return Instantiate(monobehaviour, parcelObject);
    }
    #endregion

	}
}


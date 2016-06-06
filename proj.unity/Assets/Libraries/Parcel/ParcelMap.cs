

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

namespace ParcelTool
{
  public delegate void OnAssetDownloadCompleteDelegate<T>(T asset);
  public delegate void AssetRequestDelegate();

  public static class ParcelBundles
  {
    /// <summary>
    /// If true in the editor at play mode we will load using Asset Bundles
    /// instead of the Asset Database. It is much quicker to use Asset Database. 
    /// </summary>
    public static bool UseBundlesInEditor = false;
    public static bool UseAssetDatabaseToLoad
    {
      get
      {

#if UNITY_EDITOR
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
          return UseBundlesInEditor;
        }
#endif
        return false;
      }
    }

    public static class ui
    {
      private const string m_BundleName = "ui";
      private static AssetBundle m_Bundle;
      private static IBundleDownloader m_BundleDownloader;
      private static List<AssetRequestDelegate> m_QueueAssetRequests = new List<AssetRequestDelegate>();
      private static GameObject m_BackButtonOff = null;
      private static GameObject m_BackButtonOn = null;


      public static void GetBackButtonOff(OnAssetDownloadCompleteDelegate<GameObject> assignmentFunction)
      {
        if (m_Bundle != null)
        {
          if (assignmentFunction != null)
          {
            assignmentFunction(GetBackButtonOff());
          }
          else
          {
            m_QueueAssetRequests.Add(() => { assignmentFunction(GetBackButtonOff()); });
          }
        }
      }

      public static GameObject GetBackButtonOff()
      {
        if (m_BackButtonOff == null)
        {
#if UNITY_EDITOR
          if (ParcelBundles.UseAssetDatabaseToLoad)
          {
            m_BackButtonOff = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/BackButtonOff.prefab");
            return m_BackButtonOff;
          }
#endif
          m_BackButtonOff = m_Bundle.LoadAsset<GameObject>("BackButtonOff");
        }
        return m_BackButtonOff;
      }


      public static void GetBackButtonOn(OnAssetDownloadCompleteDelegate<GameObject> assignmentFunction)
      {
        if (m_Bundle != null)
        {
          if (assignmentFunction != null)
          {
            assignmentFunction(GetBackButtonOn());
          }
          else
          {
            m_QueueAssetRequests.Add(() => { assignmentFunction(GetBackButtonOn()); });
          }
        }
      }

      public static GameObject GetBackButtonOn()
      {
        if (m_BackButtonOn == null)
        {
#if UNITY_EDITOR
          if (ParcelBundles.UseAssetDatabaseToLoad)
          {
            m_BackButtonOn = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/BackButtonOn.prefab");
            return m_BackButtonOn;
          }
#endif
          m_BackButtonOn = m_Bundle.LoadAsset<GameObject>("BackButtonOn");
        }
        return m_BackButtonOn;
      }
      public static void DownloadBundle(IBundleDownloader bundleDownloader)
      {
        m_BundleDownloader = bundleDownloader;
        bundleDownloader.StartCoroutine(DownloadBundleRoutine());
      }

      private static IEnumerator DownloadBundleRoutine()
      {
        WWW www = WWW.LoadFromCacheOrDownload(m_BundleDownloader.GetBundleURL(m_BundleName), 0);
        do
        {
          yield return new WaitForEndOfFrame();
          m_BundleDownloader.OnBundleDownloadProgressUpdated(m_BundleName, www.progress);
        } while (!www.isDone);

        if (string.IsNullOrEmpty(www.error))
        {
          m_BundleDownloader.OnBundleDownloadComplete(m_BundleName);
          m_Bundle = www.assetBundle;

          // Fire off all requests.
          for (int i = 0; i < m_QueueAssetRequests.Count; i++)
          {
            m_QueueAssetRequests[i]();
          }
          m_QueueAssetRequests.Clear();
        }
        else
        {
          m_BundleDownloader.OnBundleDownloadFailed(m_BundleName, www.url, www.error);
          m_Bundle = null;
        }


      }

      public static void UnloadBundle(MonoBehaviour coroutineRunner)
      {

      }
    }
    public static class weapons
    {
      private const string m_BundleName = "weapons";
      private static AssetBundle m_Bundle;
      private static IBundleDownloader m_BundleDownloader;
      private static List<AssetRequestDelegate> m_QueueAssetRequests = new List<AssetRequestDelegate>();
      private static GameObject m_Bullet_One = null;
      private static GameObject m_Bullet_Two = null;
      private static GameObject m_Weapon_Fire_One = null;
      private static GameObject m_Weapon_Fire_Two = null;


      public static void GetBullet_One(OnAssetDownloadCompleteDelegate<GameObject> assignmentFunction)
      {
        if (m_Bundle != null)
        {
          if (assignmentFunction != null)
          {
            assignmentFunction(GetBullet_One());
          }
          else
          {
            m_QueueAssetRequests.Add(() => { assignmentFunction(GetBullet_One()); });
          }
        }
      }

      public static GameObject GetBullet_One()
      {
        if (m_Bullet_One == null)
        {
#if UNITY_EDITOR
          if (ParcelBundles.UseAssetDatabaseToLoad)
          {
            m_Bullet_One = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/Resources/Ammo/Bullet_One.prefab");
            return m_Bullet_One;
          }
#endif
          m_Bullet_One = Resources.Load<GameObject>("Ammo/Bullet_One");
        }
        return m_Bullet_One;
      }


      public static void GetBullet_Two(OnAssetDownloadCompleteDelegate<GameObject> assignmentFunction)
      {
        if (m_Bundle != null)
        {
          if (assignmentFunction != null)
          {
            assignmentFunction(GetBullet_Two());
          }
          else
          {
            m_QueueAssetRequests.Add(() => { assignmentFunction(GetBullet_Two()); });
          }
        }
      }

      public static GameObject GetBullet_Two()
      {
        if (m_Bullet_Two == null)
        {
#if UNITY_EDITOR
          if (ParcelBundles.UseAssetDatabaseToLoad)
          {
            m_Bullet_Two = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/Resources/Ammo/Bullet_Two.prefab");
            return m_Bullet_Two;
          }
#endif
          m_Bullet_Two = Resources.Load<GameObject>("Ammo/Bullet_Two");
        }
        return m_Bullet_Two;
      }


      public static void GetWeapon_Fire_One(OnAssetDownloadCompleteDelegate<GameObject> assignmentFunction)
      {
        if (m_Bundle != null)
        {
          if (assignmentFunction != null)
          {
            assignmentFunction(GetWeapon_Fire_One());
          }
          else
          {
            m_QueueAssetRequests.Add(() => { assignmentFunction(GetWeapon_Fire_One()); });
          }
        }
      }

      public static GameObject GetWeapon_Fire_One()
      {
        if (m_Weapon_Fire_One == null)
        {
#if UNITY_EDITOR
          if (ParcelBundles.UseAssetDatabaseToLoad)
          {
            m_Weapon_Fire_One = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/Resources/Weapon_Fire_One.prefab");
            return m_Weapon_Fire_One;
          }
#endif
          m_Weapon_Fire_One = Resources.Load<GameObject>("Weapon_Fire_One");
        }
        return m_Weapon_Fire_One;
      }


      public static void GetWeapon_Fire_Two(OnAssetDownloadCompleteDelegate<GameObject> assignmentFunction)
      {
        if (m_Bundle != null)
        {
          if (assignmentFunction != null)
          {
            assignmentFunction(GetWeapon_Fire_Two());
          }
          else
          {
            m_QueueAssetRequests.Add(() => { assignmentFunction(GetWeapon_Fire_Two()); });
          }
        }
      }

      public static GameObject GetWeapon_Fire_Two()
      {
        if (m_Weapon_Fire_Two == null)
        {
#if UNITY_EDITOR
          if (ParcelBundles.UseAssetDatabaseToLoad)
          {
            m_Weapon_Fire_Two = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UI/Resources/Weapon_Fire_Two.prefab");
            return m_Weapon_Fire_Two;
          }
#endif
          m_Weapon_Fire_Two = Resources.Load<GameObject>("Weapon_Fire_Two");
        }
        return m_Weapon_Fire_Two;
      }
      public static void DownloadBundle(IBundleDownloader bundleDownloader)
      {
        m_BundleDownloader = bundleDownloader;
        bundleDownloader.StartCoroutine(DownloadBundleRoutine());
      }

      private static IEnumerator DownloadBundleRoutine()
      {
        WWW www = WWW.LoadFromCacheOrDownload(m_BundleDownloader.GetBundleURL(m_BundleName), 0);
        do
        {
          yield return new WaitForEndOfFrame();
          m_BundleDownloader.OnBundleDownloadProgressUpdated(m_BundleName, www.progress);
        } while (!www.isDone);

        if (string.IsNullOrEmpty(www.error))
        {
          m_BundleDownloader.OnBundleDownloadComplete(m_BundleName);
          m_Bundle = www.assetBundle;

          // Fire off all requests.
          for (int i = 0; i < m_QueueAssetRequests.Count; i++)
          {
            m_QueueAssetRequests[i]();
          }
          m_QueueAssetRequests.Clear();
        }
        else
        {
          m_BundleDownloader.OnBundleDownloadFailed(m_BundleName, www.url, www.error);
          m_Bundle = null;
        }


      }

      public static void UnloadBundle(MonoBehaviour coroutineRunner)
      {

      }
    }
  }
}


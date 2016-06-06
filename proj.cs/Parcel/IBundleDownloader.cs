using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ParcelTool
{
  public interface IBundleDownloader
  {
    /// <summary>
    /// Gets called by Parcel when it's about to download a bundle. O
    /// </summary>
    /// <param name="bundleName">The name of the bundle that Parcel requires the URL for.</param>
    /// <returns>The full url to where the bundle should be downloaded.</returns>
    string GetBundleURL(string bundleName);

    /// <summary>
    /// This is called just before a bundle is about to be downloaded. This is called before GetBundleURL(); This
    /// is where you should pop up loading screens or anything else. 
    /// </summary>
    /// <param name="bundleName"></param>
    void OnBundleDownloadRequired(string bundleName);

    /// <summary>
    /// Called when the asset bundle has finished downloading.
    /// </summary>
    /// <param name="bundleName">The name of the bundle we downloaded.</param>
    void OnBundleDownloadComplete(string bundleName);

    /// <summary>
    /// Called every frame when a bundle is being downloaded. 
    /// </summary>
    /// <param name="bundleName">The name of the bundle that is downloading</param>
    /// <param name="progress">A value between 0 and 1 for the current progress of the download.</param>
    void OnBundleDownloadProgressUpdated(string bundleName, float progress);

    /// <summary>
    /// Called when Parcel tried to download a bundle but it failed for some reason. 
    /// </summary>
    /// <param name="bundleName">The name of the bundled that failed.</param>
    /// <param name="url">The url where it was trying to download from.</param>
    /// <param name="error">The error message that Unity returned back.</param>
    void OnBundleDownloadFailed(string bundleName, string url, string error);

    /// <summary>
    /// Any MonoBehaviour class will have this method. This is used for downloading the bundles
    /// internally.
    /// </summary>
    Coroutine StartCoroutine(IEnumerator routine);
  }
}

using UnityEditor;
using UnityEngine;

public class MenuItems
{
  [MenuItem("Tools/Print GUID and Path")]
  public static void PrintAssetPath()
  {
    string path = AssetDatabase.GetAssetPath(Selection.activeObject);
    string guid = AssetDatabase.AssetPathToGUID(path);
    Debug.Log("Path: " + path);
    Debug.Log("GUID: " + guid);
  }
}
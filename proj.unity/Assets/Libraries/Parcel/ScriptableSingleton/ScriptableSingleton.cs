using System;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif

namespace ParcelTool
{
  public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
  {
    private static T m_Instance;

    /// <summary>
    /// Gets our static instance from memory or loads
    /// one from disk. 
    /// </summary>
    public static T instance
    {
      get
      {
        if (m_Instance == null)
        {
          CreateAndLoad();
        }
        return m_Instance;
      }
    }

    /// <summary>
    /// The constructor checks to make sure we don't have two instances in memory. 
    /// </summary>
    protected ScriptableSingleton()
    {
      if (m_Instance != null)
      {
        Debug.LogError("ScriptableSingleton already exists. Did you query the singleton in a constructor?");
      }
      else
      {
        m_Instance = (this as T);
      }
    }

    /// <summary>
    /// Creates a new instance of a Scriptable Singleton 
    /// and populates it in the project. 
    /// </summary>
    private static void CreateAndLoad()
    {
      string filePath = GetFilePath();
      if (!string.IsNullOrEmpty(filePath))
      {
#if UNITY_EDITOR
        InternalEditorUtility.LoadSerializedFileAndForget(filePath);
#endif
      }
      if (m_Instance == null)
      {
        T t = CreateInstance<T>();
        t.hideFlags = HideFlags.HideAndDontSave;
      }
    }

    /// <summary>
    /// Saves the singleton to disk to be used. 
    /// </summary>
    /// <param name="saveAsText">Should it be serialized as text?</param>
    protected virtual void Save(bool saveAsText)
    {
      if (m_Instance == null)
      {
        Debug.Log("Cannot save ScriptableSingleton: no instance!");
        return;
      }
      string filePath = GetFilePath();
      if (!string.IsNullOrEmpty(filePath))
      {
        string directoryName = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryName))
        {
          Directory.CreateDirectory(directoryName);
        }

#if UNITY_EDITOR
        InternalEditorUtility.SaveToSerializedFileAndForget(new T[] { m_Instance}, filePath, saveAsText);
#endif
      }
    }
    private static string GetFilePath()
    {
      Type typeFromHandle = typeof(T);
      object[] customAttributes = typeFromHandle.GetCustomAttributes(true);
      object[] array = customAttributes;
      for (int i = 0; i < array.Length; i++)
      {
        object obj = array[i];
        if (obj is FilePathAttribute)
        {
          FilePathAttribute filePathAttribute = obj as FilePathAttribute;
          return filePathAttribute.filepath;
        }
      }
      return null;
    }
  }
}

using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text;
using System;
using System.Reflection;
using System.IO;

namespace ParcelTool
{
  public class ParcelMenuItems
  {
    public static string AssemblyDirectory
    {
      get
      {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(path);
      }
    }



    [MenuItem("Tools/Build Map")]
    private static void BuildAssetMap()
    {
      string[] bundleNames = AssetDatabase.GetAllAssetBundleNames();
      AssetBundleBuild[] bundles = new AssetBundleBuild[bundleNames.Length];

      for (int i = 0; i < bundleNames.Length; i++)
      {
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = bundleNames[i];
        build.assetNames = AssetDatabase.GetAssetPathsFromAssetBundle(bundleNames[i]);
        bundles[i] = build;
      }

      //ParcelBundleGenerator map = new ParcelBundleGenerator();
      //Dictionary<string, object> session = new Dictionary<string, object>();
      //session.Add("m_Bundles", bundles);
      //map.Session = session;
      //map.Initialize();
      //string classDef = map.TransformText();
      //File.WriteAllText(Application.dataPath + @"/Libraries/Parcel/ParcelMap.cs", classDef);
      //AssetDatabase.Refresh();

      // Get our assemblies that we need to reference 
      //string userDLLPath = Application.dataPath.Replace("/Assets", @"Library/ScriptAssemblies/Assembly-CSharp.dll");
      //string engineDLLPath = Application.dataPath.Replace("/Assets", @"Library/UnityAssemblies/UnityEditor.dll");
      //string editorDLLPath = Application.dataPath.Replace("/Assets", @"Library/UnityAssemblies/UnityEngine.dll");


      //CompilerParameters parameters = new CompilerParameters();
      //parameters.GenerateExecutable = false;
      //parameters.OutputAssembly = Application.dataPath + @"/Libraries/Parcel/ParcelMap.dll";
      // Add the references
      //parameters.ReferencedAssemblies.Add(userDLLPath);
      //parameters.ReferencedAssemblies.Add(engineDLLPath);
      //parameters.ReferencedAssemblies.Add(editorDLLPath);
      // Create a compiler
      //var compiler = CodeDomProvider.CreateProvider("CSharp");
      // Compile the code
      //var results = compiler.CompileAssemblyFromSource(parameters, classDef);

      //Debug.Log(parameters.OutputAssembly);
      // Cleanup. 
      
      //compiler.Dispose();
    }
  }
}

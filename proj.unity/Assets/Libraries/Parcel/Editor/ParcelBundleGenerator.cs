﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ParcelTool
{
    using System;
    using System.IO;
    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class ParcelBundleGenerator : ParcelBundleGeneratorBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(" \r\n");
            this.Write(@"
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif
using System.Collections;
using System.Collections.Generic;

namespace ParcelTool
{
	public delegate void OnAssetDownloadCompleteDelegate<T>( T asset );
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
                if(EditorApplication.isPlayingOrWillChangePlaymode)
                {
                    return UseBundlesInEditor; 
                }
#endif
                return false;
            }
        }

");
 for( int x = 0; x < m_Bundles.Length; x++) 
   {
	   AssetMeta[] m_BundleMeta = new AssetMeta[m_Bundles[x].assetNames.Length];

	   for(int y = 0; y < m_BundleMeta.Length; y++)
       {
		   // Create a new bundle item for each of our files. 
		   m_BundleMeta[y] = new AssetMeta(m_Bundles[x].assetNames[y]); 
       }

	   // Write our new class
		WriteLine("public static class {0} ", m_Bundles[x].assetBundleName);
		WriteLine("{");
		PushIndent("  ");
		{
			// Write Fields
			WriteLine("private const string m_BundleName = \"{0}\";", m_Bundles[x].assetBundleName);
			WriteLine("private static AssetBundle m_Bundle;");
			WriteLine("private static IBundleDownloader m_BundleDownloader;");
			WriteLine("private static List<AssetRequestDelegate> m_QueueAssetRequests = new List<AssetRequestDelegate>();");
	    	ForEach( m_BundleMeta, WriteFiled);

			// Write Properties
			ForEach( m_BundleMeta, WriteProperty);

			// Write Functions 
			WriteBundleFunctions(m_Bundles[x].assetBundleName);
        }
		PopIndent();
		WriteLine("}");
   }

            this.Write("\t}\r\n}\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
 
/// <summary>
/// Used to write the field for each asset meta. 
/// </summary>
public void WriteFiled(AssetMeta meta)
{

this.Write("\tprivate static ");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.typeName));

this.Write(" m_");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write(" = null;\r\n");


} 


public void WriteBundleFunctions(string bundleName)
{

this.Write(@"	public static void DownloadBundle(IBundleDownloader bundleDownloader)
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
	
	  if(string.IsNullOrEmpty(www.error))
	  {
		m_BundleDownloader.OnBundleDownloadComplete(m_BundleName);
		m_Bundle = www.assetBundle;
	
		// Fire off all requests.
		for( int i = 0; i < m_QueueAssetRequests.Count; i++)
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
");


}

/// <summary>
/// Used to write the property for each asset meta. 
/// </summary>
public void WriteProperty(AssetMeta meta)
{

this.Write(" \r\n\r\npublic static void Get");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write("(OnAssetDownloadCompleteDelegate<");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.typeName));

this.Write("> assignmentFunction)\r\n{\r\n\tif( m_Bundle != null )\r\n\t{\r\n\t\tif( assignmentFunction !" +
        "= null )\r\n\t\t{\r\n\t\t\tassignmentFunction( Get");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write("() ); \r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\tm_QueueAssetRequests.Add( () => { assignmentFunction" +
        "( Get");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write("() ); } );\r\n\t\t}\r\n\t}\r\n}\r\n\r\npublic static ");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.typeName));

this.Write(" Get");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write("() \r\n{\r\n\tif( m_");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write(" == null )\r\n\t{\r\n#if UNITY_EDITOR\r\n\t\tif(ParcelBundles.UseAssetDatabaseToLoad)\r\n\t\t{" +
        "\r\n\t\t\tm_");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write(" = AssetDatabase.LoadAssetAtPath<");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.typeName));

this.Write(">( \"");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.fullPath));

this.Write("\" );\r\n\t\t\treturn m_");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write(";\r\n\t\t}\r\n#endif\r\n");

 if ( meta.isResourceItem ) { 
this.Write("\t\tm_");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write(" = Resources.Load<");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.typeName));

this.Write(">( \"");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.assetPath));

this.Write("\" );\r\n");

 } else { 
this.Write("\t\tm_");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write(" = m_Bundle.LoadAsset<");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.typeName));

this.Write(">( \"");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.assetPath));

this.Write("\" );\r\n");

}
this.Write("\t}\r\n\treturn m_");

this.Write(this.ToStringHelper.ToStringWithCulture(meta.name));

this.Write(";\r\n}\r\n");


}


public void ForEach( AssetMeta[] bundleMetaArray, System.Action<AssetMeta> action )
{
	for(int i = 0; i < bundleMetaArray.Length; i++)
    {
		action(bundleMetaArray[i]);
    }
}

/// <summary>
/// Used to setup all the strings we need to write for each asset. 
/// </summary>
public struct AssetMeta
{
	private string m_Typename; 
	private string m_AssetPath;
	private string m_Fullpath;
	private string m_Name;
	private bool m_IsResourceItem;

	public AssetMeta(string fullPath)
    {
		m_Fullpath = fullPath;
		UnityEngine.Object asset =  AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(fullPath);
		m_Typename = asset.GetType().Name; 

		m_IsResourceItem = m_Fullpath.Contains("/Resources/");
		m_Name = Path.GetFileNameWithoutExtension(m_Fullpath);

		if(m_IsResourceItem)
        {
			int pathIndex = m_Fullpath.IndexOf("/Resources/") + 11 /* 11 is how many chars the resources folder is */;
			m_AssetPath = m_Fullpath.Substring(pathIndex, fullPath.Length - pathIndex);
		    m_AssetPath = m_AssetPath.Replace(Path.GetExtension(m_AssetPath), string.Empty);
        }
		else
        {
			m_AssetPath = m_Name;
        }

    }

	public bool isResourceItem
    {
		get
        {
			return m_IsResourceItem;
        }
    }

	public string name
    {
		get
        {
			return m_Name;
        }
    }

	public string typeName
    {
		get
        {
			return m_Typename;
        }
    }

	public string fullPath
    {
		get 
        {
			return m_Fullpath; 
        }
    }

	public string assetPath
    {
		get
        {
			return m_AssetPath;
        }
    }


}
	


private UnityEditor.AssetBundleBuild[] _m_BundlesField;

/// <summary>
/// Access the m_Bundles parameter of the template.
/// </summary>
private global::UnityEditor.AssetBundleBuild[] m_Bundles
{
    get
    {
        return this._m_BundlesField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool m_BundlesValueAcquired = false;
if (this.Session.ContainsKey("m_Bundles"))
{
    this._m_BundlesField = ((global::UnityEditor.AssetBundleBuild[])(this.Session["m_Bundles"]));
    m_BundlesValueAcquired = true;
}
if ((m_BundlesValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("m_Bundles");
    if ((data != null))
    {
        this._m_BundlesField = ((global::UnityEditor.AssetBundleBuild[])(data));
    }
}


    }
}


    }
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class ParcelBundleGeneratorBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}

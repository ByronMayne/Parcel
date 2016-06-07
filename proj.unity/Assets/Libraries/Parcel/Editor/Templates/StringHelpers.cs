
using System.Text;
using System.Text.RegularExpressions;

namespace ParcelTool
{
  public static class StringHelpers
  {
    /// <summary>
    /// Takes a string and removes all spaces and invalid characters. This string would be valid for
    /// a variable name. 
    /// </summary>
    public static string ToVariableName(string name)
    {
      string pattern = "[\\~#%&*{}/:<>!~^*()+-`?|\"-] ";
      Regex regex = new Regex(pattern);
      return regex.Replace(name, string.Empty);
    }

    /// <summary>
    /// Takes a string an inserts spaces before every capital letter and removes all
    /// invalid characters. 
    /// </summary>
    public static string ToPrettyName(string name, bool preserveAcronyms)
    {
      if (string.IsNullOrEmpty(name))
      {
        return string.Empty;
      }

      string pattern = "[\\~#%&*{}/:<>!~^*()+-`?|\"-]";

      name = name.Replace('_', ' ');
      Regex regEx = new Regex(pattern);
      StringBuilder newText = new StringBuilder(name.Length * 2);
      name = regEx.Replace(name, string.Empty);

      newText.Append(name[0]);
      for (int i = 1; i < name.Length; i++)
      {
        if (char.IsUpper(name[i]))
        {
          if ((name[i - 1] != ' ' && !char.IsUpper(name[i - 1])) || (preserveAcronyms && char.IsUpper(name[i - 1]) && i < name.Length - 1 && !char.IsUpper(name[i + 1])))
          {
            newText.Append(' ');
          }
        }
        newText.Append(name[i]);
      }
      return newText.ToString();
    }
  }
}

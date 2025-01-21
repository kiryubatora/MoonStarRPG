using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Obvious.Soap.Editor
{
    public class SoapSettings : ScriptableObject
    {
        public EVariableDisplayMode VariableDisplayMode = EVariableDisplayMode.Default;
        public ENamingCreationMode NamingOnCreationMode = ENamingCreationMode.Auto;
        public ECreatePathMode CreatePathMode = ECreatePathMode.Auto;
        public ERaiseEventInEditorMode RaiseEventsInEditor;
        public bool CanEventsBeRaisedInEditor => RaiseEventsInEditor == ERaiseEventInEditorMode.Enabled;
        [FormerlySerializedAs("Categories")] public List<string> Tags = new List<string> { "None" };

        public int GetTagIndex(string tagName)
        {
            if (!Tags.Contains(tagName))
            {
                Debug.LogWarning($"Tag {tagName} does not exist. Returning 0.");
                return 0;
            }

            return Tags.IndexOf(tagName);
        }

        public int GetTagIndex(int fromIndex)
        {
            if (fromIndex < 0 || fromIndex >= Tags.Count)
            {
                Debug.LogWarning($"Tag index {fromIndex} out of range. Returning 0.");
                return 0;
            }

            return fromIndex;
        }
    }

    public enum EVariableDisplayMode
    {
        Default,
        Minimal
    }

    public enum ENamingCreationMode
    {
        Auto,
        Manual
    }


    public enum ECreatePathMode
    {
        Auto,
        Manual
    }

    public enum ERaiseEventInEditorMode
    {
        Disabled,
        Enabled
    }
}
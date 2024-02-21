using UnityEngine;
using UnityEditor;
namespace UAPT.SerializableVariable
{
    public class SerializableDecimalDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var obj = property.serializedObject.targetObject;
            var inst = (SerializableDecimal)this.fieldInfo.GetValue(obj);
            var fieldRect = EditorGUI.PrefixLabel(position, label);
            string text = GUI.TextField(fieldRect, inst.Value.ToString());
            if (GUI.changed)
            {
                decimal val;
                if (decimal.TryParse(text, out val))
                {
                    inst.Value = val;
                    property.serializedObject.ApplyModifiedProperties();
                }
            }
        }
    }
}


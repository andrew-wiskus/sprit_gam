using UnityEditor;
using UnityEngine;

//[CustomPropertyDrawer(typeof(ChipModStat))]
public class ChipModStatDrawer : PropertyDrawer {

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 5;

        var typeRect = new Rect(position.x, position.y, 30, position.height);
        var increase_amountRect = new Rect(position.x + 100, position.y, 50, position.height);
        //var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);
        EditorGUI.PropertyField(increase_amountRect, property.FindPropertyRelative("increase_amount"), GUIContent.none);
        //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();

    }

}

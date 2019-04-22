using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(AudioManager))]
public class AudioManagerEditor : Editor {


    private void OnEnable()
    {
        AudioManager audioManager = (AudioManager)target;
        //audioManager.nameProperty.Clear();

        for (int i = 0; i < 20; i++)
        {
            audioManager.nameProperty.Add(i.ToString()+" ");
        }
       
    }

    public override void OnInspectorGUI()
    {
       
        base.OnInspectorGUI();
        AudioManager audioManager =(AudioManager)target;
       // var serializedObject = new SerializedObject(target);
       
        SerializedProperty list = serializedObject.FindProperty("audioSources");
        //serializedObject.Update();
        EditorGUILayout.PropertyField(list);
        

         
        
        for (int i = 0; i < list.arraySize; i++)
        {
            
            // audioManager.nameProperty.Add(i.ToString());
            GUILayout.BeginHorizontal();
            
            audioManager.nameProperty[i] = GUILayout.TextField(audioManager.nameProperty[i], GUILayout.Width(80));
            EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i),GUIContent.none);
            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("-"))
            {
                audioManager.audioSources.RemoveAt(i);
            }
                GUILayout.EndHorizontal();
        }
        if (GUILayout.Button("+"))
        {
          
            audioManager.audioSources.Add(new AudioSource());
            audioManager.nameProperty[audioManager.nameProperty.Count - 1] = (audioManager.nameProperty.Count - 1).ToString() + " ";
        }
        
       



    }
}

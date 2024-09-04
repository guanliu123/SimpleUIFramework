using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

//定义要扩展的组件
[CustomEditor(typeof(UIContainer))]
public class UIContainerInspector:Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        //取得目标组件
        UIContainer targetUIContainer = (UIContainer)target;
        int del = -1;

        foreach (UIContainer.UISet uiSet in targetUIContainer.sets)
        {
            //横向布局，名字、Transform和类型
            EditorGUILayout.BeginHorizontal();

            int index = targetUIContainer.sets.IndexOf(uiSet);

            EditorGUILayout.LabelField(index+".",GUILayout.Width((20.0f)));
            
            //设置名字文本框
            if (string.IsNullOrEmpty(uiSet.name) && uiSet.tf != null)
            {
                //如果用户懒得手动添加名字就默认为物品的名字
                uiSet.name = uiSet.tf.name;
            }
            uiSet.name = EditorGUILayout.TextField(uiSet.name).Trim();//去空格
            //设置Transform
            uiSet.tf = EditorGUILayout.ObjectField(uiSet.tf, typeof(Transform), true) as Transform;
            //设置类型，UIContainer中客制化的枚举类
            uiSet.type = (UIContainer.COMPONENT_TYPE)EditorGUILayout.EnumPopup(uiSet.type);

            if (GUILayout.Button("-"))
            {
                //不立刻删除，而是在循环外删除
                del = index;
            }
            
            EditorGUILayout.EndHorizontal();
        }
        
        EditorGUILayout.Space();
        if (GUILayout.Button("Add"))
        {
            UIContainer.UISet uiSet = new UIContainer.UISet();
            targetUIContainer.sets.Add(uiSet);
        }
        if (del >= 0)
        {
            targetUIContainer.sets.RemoveAt(del);
            del = -1;
        }
        
        EditorGUILayout.Space();
        //保存
        if (GUILayout.Button("Save"))
        {
            SaveChange();
        }
        EditorGUILayout.HelpBox(
            "After editing the Prefab, you must click [Save] to make the necessary changes"
            ,MessageType.Warning
            );
    }

    private void SaveChange()
    {
        PrefabStage obj = PrefabStageUtility.GetCurrentPrefabStage();
        PrefabUtility.SaveAsPrefabAsset(obj.prefabContentsRoot, obj.assetPath);
    }
}

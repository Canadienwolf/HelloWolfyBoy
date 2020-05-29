using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ConversationBuilderWindow : EditorWindow
{
    [MenuItem("Random Conversation System/Conversation Builder")]
    static void Init()
    {
        ConversationBuilderWindow window =
            (ConversationBuilderWindow) EditorWindow.GetWindow(typeof(ConversationBuilderWindow));
        window.Show();
    }


    private void OnGUI()
    {
        if (GUILayout.Button("Convert Database to Ingame Asset"))
        {
            ConvertDatabaseToAsset();
        }
    }

    private void ConvertDatabaseToAsset()
    {
        IDataSetBuilder builder =
            new SqliteDataSetBuild("D:\\nord\\gl\\gl2\\HelloWolfyBoy_Master\\story_db\\StoryAccess.sqlite");
        
        ConversationBuilder conversationBuilder=new ConversationBuilder(builder);

        var dataSet = builder.BuildDataSet();
    }
}
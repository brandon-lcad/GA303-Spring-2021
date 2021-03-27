using System;
using Scriptables;
using UnityEditor;
using UnityEngine;
using static  Settings.CustomGameSettings;

namespace Editor
{
    /**
     * Quest Creator
     * Editor window to generate new quests within the game.
     */
    public class QuestCreatorEditor : EditorWindow
    {
        private const string ASSETS_PATH = QUEST_ASSETS_PATH + "/{0}.asset";
        private const GameContentType CONTENT_TYPE = GameContentType.Quest;
        private QuestData quest;

        public float labelWidth = 150f;
        public float textareaHeight = 100f;
    
        [MenuItem("Game/Quest Creator")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(QuestCreatorEditor));
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture>(QUEST_CREATOR_ICON_PATH);
            GUIContent titleContent = new GUIContent("Quest Creator", icon);
            window.titleContent = titleContent;
        }

        private void OnEnable()
        {
            CreateQuestInstance();
        }

        private void OnGUI()
        {
            DisplayQuestOptions();

            GUILayout.Space(20f);
            if (GUILayout.Button("Save"))
            {
                SaveQuest();
                ClearForm();
            }
        }

        void CreateQuestInstance()
        {
            quest = CreateInstance<QuestData>();
            quest.itemType = ItemType.Quest;
        }
        
        void SaveQuest()
        {
            quest.GenerateId();
            var path = String.Format(ASSETS_PATH, quest.GetItemId());
            var newPath = AssetDatabase.GenerateUniqueAssetPath(path);
            AssetDatabase.CreateAsset(quest, newPath);
            AssetDatabase.SaveAssets();
        }

        void ClearForm()
        {
            CreateQuestInstance();
        }
    
        void DisplayQuestOptions()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Quest Options", EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
            GUILayout.Space(20f);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Title", GUILayout.Width(labelWidth));
            quest.itemName = EditorGUILayout.TextField(quest.itemName);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Description", GUILayout.Width(labelWidth));
            quest.itemDescription = EditorGUILayout.TextArea(quest.itemDescription,GUILayout.Height(textareaHeight));
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Quest Icon", GUILayout.Width(labelWidth));
            quest.itemIcon = EditorGUILayout.ObjectField(quest.itemIcon,typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Objective", GUILayout.Width(labelWidth));
            quest.questObjective = EditorGUILayout.IntField(quest.questObjective);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Objective Quantity", GUILayout.Width(labelWidth));
            quest.invQuantity = EditorGUILayout.IntSlider(quest.invQuantity,0, 100);        
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
                
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward Type", GUILayout.Width(labelWidth));
            quest.rewardType = (QuestData.RewardType) EditorGUILayout.EnumPopup(QuestData.RewardType.Currency);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward Amount", GUILayout.Width(labelWidth));
            quest.rewardAmount = EditorGUILayout.IntField(quest.rewardAmount);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Reward Icon", GUILayout.Width(labelWidth));
            quest.rewardImage = EditorGUILayout.ObjectField(quest.rewardImage, typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        }
    }
}
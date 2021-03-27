using System;
using UnityEditor;
using UnityEngine;
using static Settings.CustomGameSettings;

namespace Editor
{
    /**
     * Item Creator
     * Quick and easy tool to generate new items within the game.
     */
    public class ItemCreatorEditor : EditorWindow
    {
        
        private readonly string assetsPath = ITEM_ASSETS_PATH + "/{0}.asset";
        private const GameContentType CONTENT_TYPE = GameContentType.Loot;
        private GameItem m_gameGameItem;
    
        public float labelWidth = 150f;
    
        [MenuItem("Game/Loot Creator")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow(typeof(ItemCreatorEditor));
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture>(ITEM_CREATOR_ICON_PATH);
            GUIContent titleContent = new GUIContent("Loot Creator", icon);
            window.titleContent = titleContent;
        }

        private void OnEnable()
        {
            CreateLootableInstance();
        }

        private void OnGUI()
        {
            DisplayLootableOptions();

            GUILayout.Space(20f);
            if (GUILayout.Button("Save"))
            {
                SaveLootable();
                ClearForm();
            }
        }

        void CreateLootableInstance()
        {
            m_gameGameItem = CreateInstance<GameItem>();
        }

        void SaveLootable()
        {
            m_gameGameItem.GenerateId();                 // TODO: Automate this.
        
            // Finally, save the new asset to the specified location.
            var path = String.Format(assetsPath, m_gameGameItem.GetItemId());
            var newTitle = AssetDatabase.GenerateUniqueAssetPath(path);
            AssetDatabase.CreateAsset(m_gameGameItem, newTitle);
            AssetDatabase.SaveAssets();
        }

        void ClearForm()
        {
            CreateLootableInstance();
        }

        void DisplayLootableOptions()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Options", EditorStyles.boldLabel);
            GUILayout.EndHorizontal();
            GUILayout.Space(20f);
            
            GUILayout.Space(5);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Type", GUILayout.Width(labelWidth));
            m_gameGameItem.itemType = (ItemType) EditorGUILayout.EnumPopup(m_gameGameItem.itemType);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Name", GUILayout.Width(labelWidth));
            m_gameGameItem.itemName = EditorGUILayout.TextField(m_gameGameItem.itemName);
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Description", GUILayout.Width(labelWidth));
            m_gameGameItem.itemDescription = EditorGUILayout.TextArea(m_gameGameItem.itemDescription,GUILayout.Height(100));
            GUILayout.EndHorizontal();
        
            GUILayout.Space(5);
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Icon", GUILayout.Width(labelWidth));
            m_gameGameItem.itemIcon = EditorGUILayout.ObjectField(m_gameGameItem.itemIcon, typeof(Sprite), true) as Sprite;
            GUILayout.EndHorizontal();
        
        }
    }
}
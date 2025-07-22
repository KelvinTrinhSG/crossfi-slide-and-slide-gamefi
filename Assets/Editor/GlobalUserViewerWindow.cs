// Editor/GlobalUserViewerWindow.cs
using UnityEditor;
using UnityEngine;

namespace MyGame.Web3.API
{
    public class GlobalUserViewerWindow : EditorWindow
    {
        [MenuItem("Tools/Global User Viewer")]
        public static void ShowWindow()
        {
            GetWindow<GlobalUserViewerWindow>("Global User Viewer");
        }

        void OnGUI()
        {
            GUILayout.Label("🔎 Realtime Global User Data", EditorStyles.boldLabel);

            if (Application.isPlaying)
            {
                DrawField("Username", GlobalUser.Username, Color.cyan);
                DrawField("Wallet Address", GlobalUser.WalletAddress, Color.yellow);
                DrawField("Private Key", GlobalUser.PrivateKey, new Color(1f, 0.5f, 0.5f)); // hồng nhạt
                DrawField("Mnemonic", GlobalUser.Mnemonic, new Color(0.9f, 0.8f, 0.5f));
                DrawField("Balance", GlobalUser.WalletBalance, Color.green);
            }
            else
            {
                EditorGUILayout.HelpBox("Run the game to see live user data.", MessageType.Info);
            }
        }

        void DrawField(string label, string value, Color color)
        {
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel);

            // Lưu GUI màu cũ
            var originalColor = GUI.color;
            GUI.color = color;

            EditorGUILayout.SelectableLabel(value, EditorStyles.textField, GUILayout.Height(18));

            // Khôi phục màu GUI
            GUI.color = originalColor;

            GUILayout.Space(4); // khoảng cách giữa các dòng
        }
    }
}

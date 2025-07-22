// Editor/BackendTesterEditor.cs
using UnityEditor;
using UnityEngine;

namespace MyGame.Web3.API
{
    [CustomEditor(typeof(BackendTester))]
    public class BackendTesterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var tester = (BackendTester)target;

            GUILayout.Space(10);
            if (GUILayout.Button("🚀 Signup")) tester.Signup();
            if (GUILayout.Button("🔐 Login")) tester.Login();
            if (GUILayout.Button("💼 Create Wallet")) tester.CreateWallet();
            if (GUILayout.Button("📥 Import Wallet")) tester.ImportWallet();
            if (GUILayout.Button("💰 Get Balance")) tester.GetBalance();

        }
    }
}
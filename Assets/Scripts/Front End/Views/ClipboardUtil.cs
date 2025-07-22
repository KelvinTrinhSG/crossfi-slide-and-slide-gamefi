using System.Runtime.InteropServices;
using UnityEngine;

public static class ClipboardUtil
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void CopyToClipboard(string text);
#endif

    public static void Copy(string text)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        CopyToClipboard(text);
#else
        GUIUtility.systemCopyBuffer = text;
        Debug.Log("✅ Copied to clipboard (native): " + text);
#endif
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Scene and Button Settings")]
    [SerializeField] private string targetSceneName = "FortuneSpinWheel";
    [SerializeField] private Button switchButton;

    private void Start()
    {
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(SwitchToTargetScene);
        }
        else
        {
            Debug.LogWarning("Switch Button is not assigned!");
        }
    }

    public void SwitchToTargetScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name is empty!");
        }
    }
}

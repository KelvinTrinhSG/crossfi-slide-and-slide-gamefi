using UnityEngine;
using TMPro;
using SgLib; // Nếu CoinManager nằm trong namespace SgLib

public class CoinUIUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        UpdateCoinUI(CoinManager.Instance.Coins);

        // Đăng ký sự kiện mỗi khi số coin thay đổi
        CoinManager.CoinsUpdated += UpdateCoinUI;
    }

    private void OnDestroy()
    {
        CoinManager.CoinsUpdated -= UpdateCoinUI;
    }

    private void UpdateCoinUI(int newCoinAmount)
    {
        coinText.text = newCoinAmount.ToString();
    }
}


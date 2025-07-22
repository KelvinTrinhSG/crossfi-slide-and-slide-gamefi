using UnityEngine;
using TMPro;

namespace MyGame.Web3.Controllers
{
    public class GetBalanceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text balanceText;

        public void ShowBalance(string balance)
        {
            balanceText.text = balance;
        }

        public void ShowError(string message)
        {
            balanceText.text = $"❌ {message}";
        }
    }
}

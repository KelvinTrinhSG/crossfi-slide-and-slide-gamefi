// Scripts/Models/GetBalanceResponse.cs
namespace MyGame.Web3.API
{
    [System.Serializable]
    public class GetBalanceResponse
    {
        public bool success;
        public string wallet_address;
        public int chainId;
        public string balance; // sẽ là chuỗi số thập phân (string)
    }
}

// Scripts/Config/Config.cs
namespace MyGame.Web3.API
{
    public static class Config
    {
        // 🌐 Backend Server
        public static readonly string BackendBaseUrl = "http://localhost:3000";

        // 🧩 API Endpoints
        public static readonly string SignupEndpoint = "/api/users";
        public static readonly string LoginEndpoint = "/api/users/login";
        public static readonly string CreateWalletEndpoint = "/api/users/create";
        public static readonly string ImportWalletEndpoint = "/api/users/import-wallet";
        public static readonly string GetBalanceEndpoint = "/api/users/get-balance";

        // 🔗 Blockchain settings
        public static readonly int DefaultChainId = 4157;

        // 👤 Default user info (có thể dùng để test nhanh)
        public static readonly string DefaultUsername = "player123";
        public static readonly string DefaultPassword = "123456";
    }
}

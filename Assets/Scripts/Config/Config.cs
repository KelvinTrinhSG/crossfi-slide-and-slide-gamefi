﻿// Scripts/Config/Config.cs
namespace MyGame.Web3.API
{
    public static class Config
    {
        // 🌐 Backend Server
        public static readonly string BackendBaseUrl = "https://crossfi-user-management.onrender.com";

        // 🧩 API Endpoints
        public static readonly string SignupEndpoint = "/api/users";
        public static readonly string LoginEndpoint = "/api/users/login";
        public static readonly string CreateWalletEndpoint = "/api/users/create";
        public static readonly string ImportWalletEndpoint = "/api/users/import-wallet";
        public static readonly string GetBalanceEndpoint = "/api/users/get-balance";
        public static readonly string SendTokenEndpoint = "/api/users/send-token"; // ✅ Thêm dòng này

        // 🔗 Blockchain settings
        public static readonly int DefaultChainId = 4157;
        public static readonly string DefaultToAddress = "0xA24d7ECD79B25CE6C66f1Db9e06b66Bd11632E00";

        // 👤 Default user info (có thể dùng để test nhanh)
        public static readonly string DefaultUsername = "player123";
        public static readonly string DefaultPassword = "123456";
    }
}

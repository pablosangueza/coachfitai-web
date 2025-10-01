using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachFitAI.Web.Pages.Shared.Web3Components
{
    public class Web3PaymentConfig
{
    public string[] SupportedTokens { get; set; } = Array.Empty<string>();
    public NetworkConfig[] Networks { get; set; } = Array.Empty<NetworkConfig>();
}

public class NetworkConfig
{
    public string Name { get; set; } = "";
    public string RpcUrl { get; set; } = "";
    public string MerchantAddress { get; set; } = "";
    public Dictionary<string, string> TokenContracts { get; set; } = new();
}
}
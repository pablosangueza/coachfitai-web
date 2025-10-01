using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

namespace CoachFitAI.Web.Pages.Shared.Web3Components
{
    
[Event("Transfer")]
public class TransferEventDTO : IEventDTO
{
    [Parameter("address", "from", 1, true)]
    public string From { get; set; } = default!;

    [Parameter("address", "to", 2, true)]
    public string To { get; set; } = default!;

    [Parameter("uint256", "value", 3, false)]
    public BigInteger Value { get; set; }
}

}
using Sandbox;

namespace ClickingGame
{
	public partial class playerInformation : BaseNetworkable
	{
		[Net, Local] public long playerMoneyAmount { get; set; } = 0;
		[Net, Local] public int playerMoneyChangeAmount { get; set; } = 1;

		[Net, Local] public int playerMoneyLevel { get; set; } = 1;
		
	}
}

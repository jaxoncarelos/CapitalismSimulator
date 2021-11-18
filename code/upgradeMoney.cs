using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;

namespace ClickingGame
{
	public class upgradeMoney : WorldPanel
	{
		public Panel backPanel;
		public Label moneyAmount;
		public Button upgradeMoneyPerClick;

		public upgradeMoney()
		{
			StyleSheet.Load( "upgradeMoneyPanel.scss" );
			backPanel = Add.Panel( "backPanel" );
			moneyAmount = backPanel.Add.Label( "", "moneyAmount" );
			upgradeMoneyPerClick = backPanel.Add.Button( "Upgrade", "upgradeMoneyPerClick" );
			upgradeMoneyPerClick.AddEventListener( "onclick", () =>
			{
				var player = (Local.Pawn as ClickingPlayer);

				if ( player.playerMoneyAmount >= player.nextCosts[player.playerMoneyLevel] )
				{
					ConsoleSystem.Run( "jhsjsjsfgh" );

					string steamid = Convert.ToString( Local.Client.PlayerId );
					var data = new ClickingData();
					data.SteamId = steamid;
					data.playerMoneyAmount = player.playerMoneyAmount;
					data.playerMoneyChange = player.playerMoneyChangeAmount;
					data.playerMoneyLevel = player.playerMoneyLevel;
					ClickingGame.WebSocketClient.Send( data );
				}
			} );
		}

		public TimeSince timeSinceSave;
		public override void Tick()
		{
			var player = (Local.Pawn as ClickingPlayer);
			moneyAmount.Text = "$" + Convert.ToString( player.nextCosts[player.playerMoneyLevel] );

			if ( timeSinceSave > 5 )
			{

			}
		}
	}
}

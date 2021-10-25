using System;
using System.Diagnostics.Tracing;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ClickingGame
{
	public class upgradeMoney : WorldPanel
	{
		public Panel backPanel;
		public Label moneyAmount;
		public Button upgradeMoneyPerClick;
		
		
		
		public upgradeMoney()
		{
			StyleSheet.Load("upgradeMoneyPanel.scss"  );
			backPanel = Add.Panel( "backPanel" );
			moneyAmount = backPanel.Add.Label( "", "moneyAmount" );
			upgradeMoneyPerClick = backPanel.Add.Button( "Upgrade", "upgradeMoneyPerClick" );
			upgradeMoneyPerClick.AddEventListener( "onclick", () =>
			{
				
				var player = (Local.Pawn as ClickingPlayer);
				if ( player.playerMoneyAmount >= player.nextCosts[player.playerMoneyLevel] )
				{
					ConsoleSystem.Run("jhsjsjsfgh"  );
				}
				Log.Info(player.playerMoneyLevel  );
			});

		}
		

		public override void Tick()
		{
			var ply = Local.Pawn as ClickingPlayer;
			moneyAmount.Text = "$" + Convert.ToString( ply.nextCosts[ply.playerMoneyLevel]  );
			
		}
	}
}

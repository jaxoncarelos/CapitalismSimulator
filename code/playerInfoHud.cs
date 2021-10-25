using System;
using ClickingGame;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ClickingGame
{
	class playerInfoHud : Panel
	{
		public Panel mainPanel;
		public Label moneyAmount;
		public Label dollarSign;
		public Label moneyPerClick;

		public playerInfoHud()
		{
			StyleSheet.Load( "playerInfoHud.scss" );
			mainPanel = Add.Panel( "mainPanel" );
			dollarSign = mainPanel.Add.Label( "$", "dollarSign" );
			moneyAmount = mainPanel.Add.Label( "", "moneyAmount" );

			moneyPerClick = mainPanel.Add.Label( "", "moneyPerClick" );

			dollarSign.Style.FontColor = "#FFD700";
		}
		public override void Tick(){
			var player = (Local.Pawn as ClickingPlayer);

			moneyAmount.Text = $" {Convert.ToString(player.playerMoneyAmount)}";
			moneyPerClick.Text = $"Current Sweatshop Workers: {player.playerMoneyChangeAmount}";
		}
	}
}

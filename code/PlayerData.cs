using Sandbox;

namespace ClickingGame
{
	public class ClickingData
	{
		public long SteamId { get; set; }
		public long playerMoneyAmount { get; set; }
		public int playerMoneyChange { get; set; }
		public int playerMoneyLevel { get; set; }
	}
	public class PlayerData
	{

		public static void Save( ClickingPlayer player )
		{
			ClickingData data = new ClickingData
			{
				playerMoneyAmount = player.playerMoneyAmount,
				playerMoneyChange = player.playerMoneyChangeAmount,
				playerMoneyLevel = player.playerMoneyLevel
			};
			FileSystem.Data.WriteJson( "player_data.json", data );
		}

		public static ClickingData Load()
		{
			return FileSystem.Data.ReadJson<ClickingData>( "player_data.json" );
		}
	}
}

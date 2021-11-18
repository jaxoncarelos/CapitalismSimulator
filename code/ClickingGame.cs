using Sandbox;
using System.Text.Json;

namespace ClickingGame
{

	/// <summary>
	/// This is your game class. This is an entity that is created serverside when
	/// the game starts, and is replicated to the client. 
	/// 
	/// You can use this to create things like HUDs and declare which player class
	/// to use for spawned players.
	/// </summary>
	public partial class ClickingGame : Sandbox.Game
	{
		public ClickingGame()
		{
			if ( IsServer )
			{
				new ClickingHudEntity();
			}

			if ( IsClient )
			{
			}

		}

		public static WebSocketClient WebSocketClient;



		[ServerCmd( "jhsjsjsfgh" )]
		public static void jhsjsjsfgh()
		{
			var player = (ConsoleSystem.Caller.Pawn as ClickingPlayer);
			if ( player.playerMoneyAmount >= player.nextCosts[player.playerMoneyLevel] )
			{
				player.playerMoneyChangeAmount++;
				player.playerMoneyLevel++;
				player.playerMoneyAmount -= player.nextCosts[player.playerMoneyLevel - 1];


			}
		}


		public override void ClientSpawn()
		{
			var worldPanel = new upgradeMoney();
			var worldPanelLocation = new Vector3( -639.5f, -3050, 53 );
			var rot = new Vector3( 90, 0, 0 );
			worldPanel.Position = worldPanelLocation;
		}



		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new ClickingPlayer();
			client.Pawn = player;

			StartWebSocketRpc( To.Single( client ) );
			player.Respawn();


			var loc = new Vector3( -416.5f, -3030, 68 );
			player.Position = loc;
		}
		[ClientRpc]
		private async void StartWebSocketRpc()
		{
			WebSocketClient = new WebSocketClient();
			bool isConnected = await WebSocketClient.Connect();
			if ( isConnected ) Log.Info( "Connection to WS Server Successful" );

			WebSocketClient.SendMessage( $"Request {Local.Client.PlayerId}" );
		}
		[ServerCmd( "hsadhasjhdgkjs" )]
		public static void hsadhasjhdgkjs( string message )
		{
			var player = ConsoleSystem.Caller.Pawn as ClickingPlayer;
			ClickingData data = JsonSerializer.Deserialize<ClickingData>( message );
			player.playerMoneyAmount = data.playerMoneyAmount;
			player.playerMoneyChangeAmount = data.playerMoneyChange;
			player.playerMoneyLevel = data.playerMoneyLevel;

		}
	}

}

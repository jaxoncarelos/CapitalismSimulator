using Sandbox;
using Sandbox.UI;

namespace ClickingGame
{

	public partial class ClickingPlayer : Player
	{
		[Net] public long playerMoneyAmount { get; set; } = 0;
		[Net] public int playerMoneyChangeAmount { get; set; } = 1;
		public long playerSteamId { get; set; }
		[Net, Predicted] public int playerMoneyLevel { get; set; } = 0;

		[Net, Predicted] public int[] nextCosts { get; set; } = new int[] { 10, 50, 120, 200, 250, 320, 480, 700, 900, 1000, 1200, 1400, 1800, 2550, 3200, 3500, 3800, 4200, 4800, 5200, 5800, 6600, 8000, 10000, 10500, 11000, 11800, 12900, 15000, 16000, 17500, 18000, 20500, 22000, 24000, 28000, 34000, 37000 };

		[Net, Predicted] public Color[] playerColor { get; set; } = new Color[] { Color.FromBytes( 10, 0, 0 ), Color.FromBytes( 15, 0, 0 ), Color.FromBytes( 20, 0, 0 ), Color.FromBytes( 25, 0, 0 ), Color.FromBytes( 30, 0, 0 ), Color.FromBytes( 35, 0, 0 ), Color.FromBytes( 40, 0, 0 ), Color.FromBytes( 45, 0, 0 ), Color.FromBytes( 50, 0, 0 ), Color.FromBytes( 55, 0, 0 ), Color.FromBytes( 60, 0, 0 ), Color.FromBytes( 65, 0, 0 ), Color.FromBytes( 70, 0, 0 ), Color.FromBytes( 75, 0, 0 ) };
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			//
			// Use WalkController for movement (you can make your own PlayerController for 100% control)
			//
			Controller = new WalkController();

			//
			// Use StandardPlayerAnimator  (you can make your own PlayerAnimator for 100% control)
			//
			Animator = new StandardPlayerAnimator();

			//
			// Use ThirdPersonCamera (you can make your own Camera for 100% control)
			//
			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}
		WorldInput WorldInput = new();
		[Event( "buildinput" )]

		public override void BuildInput( InputBuilder input )
		{
			WorldInput.Ray = WorldInput.Ray = Input.Cursor;
			WorldInput.MouseLeftPressed = input.Down( InputButton.Attack1 );

		}
		public override void Simulate( Client cl )
		{

			base.Simulate( cl );

			//
			// If you have active children (like a weapon etc) you should call this to 
			// simulate those too.
			//
			SimulateActiveChild( cl, ActiveChild );

			//
			// If we're running serverside and Attack1 was just pressed, spawn a ragdoll
			//
			if ( IsServer && Input.Pressed( InputButton.Attack1 ) )
			{
				playerMoneyAmount += playerMoneyChangeAmount;
				PlayerData.Save( cl.Pawn as ClickingPlayer );
			}
		}


		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}
	}
}

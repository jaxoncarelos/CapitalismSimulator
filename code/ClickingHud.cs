using Sandbox.UI;
namespace ClickingGame
{
	public partial class ClickingHudEntity : Sandbox.HudEntity<RootPanel>
	{

		public ClickingHudEntity()
		{
			if ( !IsClient )
				return;
			RootPanel.AddChild<playerInfoHud>();
		}
	}

}

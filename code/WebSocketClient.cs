using Sandbox;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClickingGame
{
	/// <summary>
	/// WebSocketExample shows example s&box WebSocket implementation
	/// </summary>
	public class WebSocketClient
	{
		private WebSocket _webSocket;
		private readonly string _connectString = "ws://137.184.92.111:5000/";
		private readonly int _maxMessageSize = 128;

		/// <summary>
		/// LastMessage stores the last message received.
		/// </summary>
		public string LastMessage { get; set; }

		/// <summary>
		/// Constructor for WebSocketExample
		/// </summary>
		public WebSocketClient()
		{
			_webSocket = new WebSocket( _maxMessageSize );
			_webSocket.OnMessageReceived += MessageReceived;

		}

		public async void SendMessage( string message )
		{
			await _webSocket.Send( message );
		}

		/// <summary>
		/// Connect to the remote WebSocket Server.
		/// </summary>
		/// <param name="path">The path appended to the connection string.</param>
		/// <returns>Whether the WebSocket is connected.</returns>
		public async Task<bool> Connect()
		{
			await _webSocket.Connect( _connectString );
			return _webSocket.IsConnected;
		}

		/// <summary>
		/// Method for disposing of the WebSocket.
		/// </summary>
		public void Shutdown()
		{
			_webSocket?.Dispose();
			_webSocket = null;
		}

		/// <summary>
		/// Asynchronous method for Sending a message to the WebSocket Server.
		/// </summary>
		/// <param name="message">The message to send to the WebSocket Server.</param>
		public async void Send( ClickingData data )
		{
			string jsonString = JsonSerializer.Serialize( data );
			await _webSocket.Send( jsonString );
		}


		/// <summary>
		/// Method to handle a received message.
		/// </summary>
		/// <param name="message">The message being received.</param>
		private void MessageReceived( string message )
		{
			LastMessage = message;
		}


	}
}


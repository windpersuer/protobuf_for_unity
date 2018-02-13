using UnityEngine;
using System.IO;
using Google.Protobuf;

public class NewBehaviourScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			_TestProtobuff ();
		}
	}

	private void _TestProtobuff ()
	{
		//1. new a message.
		TheMsg message_1 = new TheMsg ();
		message_1.Name = "steve jobs";
		message_1.Num = 19550224;
		Debug.Log ("message1: " + message_1.ToString());

		//2. write byte buffer to file.
		byte[] byte_buffer;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			message_1.WriteTo (memoryStream);
			byte_buffer = memoryStream.ToArray ();
		}

		//3. read message from byte buffer.
		TheMsg message_2 = TheMsg.Parser.ParseFrom (byte_buffer);
		Debug.Log ("message2: " + message_2.ToString ());
	}
}

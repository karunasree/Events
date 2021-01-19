using System;
using System.Collections;

namespace EventsSample
{

	using System;

	public class Program
	{
		public static void Main()
		{
			//Step 5 - Associate the event with the handler
			var invoke = new Invoke();
			invoke.Text="Say Hello"

			var sayHello = new HelloClass();
			sayHello.HelloEvent += HandleMessaage;
				



			
		}
	}

	// Step 4 - Creating code that should occur when the event happens
	public class Invoke
	{
		public string Text { get; set; }

		public void HandleMessage(object sender, SayHelloEventHandeler e)
		{
			Console.WriteLine("Message {0}", e.ToString());
		}

	}

	// Step 3 - Declaring the code for the event
	public class HelloClass
	{
		public event SayHelloEventHandeler HelloEvent;

		public void Hello()
		{			
			SayHelloEventHandeler greeting = HelloEvent;
			if (HelloEvent != null)
			{
				greeting(this, new SayHelloEventArgs("Say Hello"));
			}

		}
	}

	// Step 2 - Setting up the delegate for the event
	public delegate void SayHelloEventHandeler(object source, SayHelloEventArgs e);


	// Step 1 - Creating a class to pass arguments for the event handlers 	
	public class SayHelloEventArgs : EventArgs
	{
		public String message { get; set; }
		public SayHelloEventArgs(string mess)
		{
			this.message = mess;

		}
	}
}

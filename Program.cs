using System;
using System.Collections;

namespace EventsSample
{
	// Step 1 - Creating a class to pass arguments for the event handlers 	
	public class HelloEventArgs : EventArgs
	{
		public String message { get; set; }
		public HelloEventArgs(String Message)
		{
			this.message = Message;
		}
	}

	// Step 2 - Setting up the delegate for the event
	public delegate void HelloEventHandeler(object source, HelloEventArgs e);


	// Step 3 - Declaring the code for the event
	public class HelloEventClass
	{
		public event HelloEventHandeler HelloEvent;

		public void Greeting()
		{
			HelloEventHandeler greet = HelloEvent;
			if (HelloEvent != null)
			{
				greet(this, new HelloEventArgs("Say Hello"));
			}

		}
	}

	// Step 4 - Creating code that should occur when the event happens
	public class Invoke
	{		

		public void HandleMessage(object sender, HelloEventArgs e)
		{
			Console.WriteLine("Message :{0}", e.message);
		}

	}

	public class Program
	{
		public static void Main()
		{
			//Step 5 - Associate the event with the handler
			var invoke = new Invoke();

			var eventt= new HelloEventClass();
			eventt.HelloEvent += invoke.HandleMessage;


			//Step 6 - Causing the event to occur
			eventt.Greeting();
		}
	}


}

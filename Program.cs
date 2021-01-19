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
			var person = new Person();
			person.name = "Joe Smith";

			var alarm = new AlarmClock();
			alarm.AlarmClockEvent += person.HandleAlarm;

			//Step 6 - Causing the event to occur
			alarm.Alarm();
		}
	}

	// Step 4 - Creating code that should occur when the event happens
	public class Person
	{
		public string name { get; set; }

		public void HandleAlarm(object sender, AlarmClockEventArgs e)
		{
			Console.WriteLine("Get out of bed it's {0}", e.time);
		}

	}

	// Step 3 - Declaring the code for the event
	public class AlarmClock
	{
		public event SayHelloEventHandeler HelloEvent;

		public void Alarm()
		{
			Console.WriteLine("Alarm went off!");
			SayHelloEventHandeler alarm = HelloEvent;
			if (HelloEvent != null)
			{
				alarm(this, new SayHelloEventHandeler("Say Hello"));
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

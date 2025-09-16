using Godot;
using System;
using System.Timers;
using System.IO.Ports;

public partial class ArduinoTalk : Node2D
{
	SerialPort serialPort;
	RichTextLabel text;
	
	bool hasHeardFromArduino = false;
	float timer;
	
	public override void _Ready()
	{
		text = GetNode<RichTextLabel>("RichTextLabel");
		
		serialPort = new SerialPort();
		serialPort.PortName = "COM5";
		serialPort.BaudRate = 9600;
		serialPort.Open();
	}
	
	public override void _Process(double delta)
	{
		if(!serialPort.IsOpen) return;
		
		string serialMessage = serialPort.ReadExisting();
		if(serialMessage == "HelloGodot!")
		{
			text.Text = "Hi Arduino, you pressed the button! :3";
			hasHeardFromArduino = true;
			timer = TimeSpan.TicksPerMillisecond;
		}
		
		if(hasHeardFromArduino && TimeSpan.TicksPerMillisecond - timer < 3000)
		{
			text.Text += "\n Get Bi Blasted >:3C";
			serialPort.Write("1");
			hasHeardFromArduino = false;
		}
	}
}

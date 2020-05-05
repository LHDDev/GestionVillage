using Godot;
using System;

public class Camera : Camera2D
{

	private Vector2 Velocity;
	private bool dragging;
	private Vector2 lastMousePos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(0, 0);
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (Input.IsMouseButtonPressed((int)Godot.ButtonList.Left))
		{
			dragging = true;
		}
		else
		{
			dragging = false;
		}

	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if(@event is InputEventMouseMotion mouseMotion && dragging)
		{
			Position -= mouseMotion.Relative * Zoom;
		}
		if (@event is InputEventMouseButton mouseEvent)
		{
			GD.Print(mouseEvent.AsText());
			if (mouseEvent.ButtonIndex == (int)Godot.ButtonList.WheelUp)
			{
				if (Zoom.x >= 0.3 && Zoom.y >= 0.3)
				{
					Zoom -= new Vector2(0.05f, 0.05f);
				}
			}
			else if (mouseEvent.ButtonIndex == (int)Godot.ButtonList.WheelDown)
			{
				if (Zoom.x <= 2 && Zoom.y <= 2)
				{
					Zoom += new Vector2(0.05f, 0.05f);
				}
			}
		}
	}


}

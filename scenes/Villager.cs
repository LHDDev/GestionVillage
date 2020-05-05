using Godot;
using System;

public class Villager : KinematicBody2D
{


	private STATES state;
	private Timer cooldown;
	private Vector2 dir = Vector2.Zero;
	private Vector2 worldBoundaries;

	[Export]
	private int speed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		worldBoundaries = new Vector2(500, 500);
		cooldown = new Timer();
		AddChild(cooldown);
		cooldown.Connect("timeout", this, "move");

		move();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		this.MoveAndCollide(dir * delta);
	}

	private void move()
	{
		Random rndDirection = new Random();
		bool canMove = false;

		//switch ((DIRECTIONS)rndDirection.Next(5))
		switch((DIRECTIONS)1)
		{
			case DIRECTIONS.NORTH:
				dir.x = 0;
				dir.y = -speed;
				break;
			case DIRECTIONS.EAST:
				dir.x = speed;
				dir.y = 0;
				break;
			case DIRECTIONS.WEST:
				dir.x = -speed;
				dir.y = 0;
				break;
			case DIRECTIONS.SOUTH:
				dir.x = 0;
				dir.y = speed;
				break;
		}
		cooldown.WaitTime = 1;
		cooldown.Start();

		canMove = canIMove(this.Position + this.dir);

		if(!canMove)
		{
			this.dir = Vector2.Zero;
		}
	}

	private bool canIMove(Vector2 newPosition)
	{
		bool result = true;

		if (newPosition.x <= 0 || newPosition.x >= worldBoundaries.x)
			result = false;
		if (newPosition.y <= 0 || newPosition.y >= worldBoundaries.x)
			result = false;
		return result;
	}
}

using Godot;
using System;

public class Villager : KinematicBody2D
{


	private STATES state;
	private Timer cooldown;
	private Vector2 dir = Vector2.Zero;
	private Vector2 worldBoundaries;
	private bool canMove;
	[Export]
	private int speed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		worldBoundaries = new Vector2(250, 250);
		cooldown = new Timer();
		AddChild(cooldown);
		cooldown.Connect("timeout", this, "move");

		move();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if(canMove)
		{
			this.MoveAndCollide(dir * delta);
		}
	}

	private void move()
	{
		Random rndDirection = new Random();
		canMove = false;
		DIRECTIONS wayDir = (DIRECTIONS)rndDirection.Next(5);
		switch (wayDir)
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
		
		canMove = canIMove(this.Position + this.dir, wayDir);

		if(!canMove)
		{
			this.dir = -dir;
		}
	}

	private bool canIMove(Vector2 newPosition, DIRECTIONS direction)
	{
		bool result = true;

		if ((newPosition.x <= 0 && direction == DIRECTIONS.WEST) || (newPosition.x >= worldBoundaries.x && direction == DIRECTIONS.EAST))
			result = false;
		if ((newPosition.y <= 0 && direction == DIRECTIONS.NORTH) || (newPosition.y >= worldBoundaries.y && direction == DIRECTIONS.SOUTH))
			result = false;
		return result;
	}
	//0328547994 EFS amiens don de plasma à rappeler pour dans deux semaines
}


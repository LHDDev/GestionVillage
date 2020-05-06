using Godot;
using System;

public class Villager : KinematicBody2D
{


	private STATES state;
	private Timer cooldown;
	private Vector2 direction = Vector2.Zero;
	private Vector2 chunkBoundaries;
	Random rndDirection;

	[Export]
	private int speed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rndDirection= new Random();
		chunkBoundaries = new Vector2(500, 500);

		cooldown = new Timer();
		AddChild(cooldown);
		cooldown.Connect("timeout", this, nameof(Move));

		Move();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		this.MoveAndCollide(direction * delta);
	}

	private void Move()
	{
		bool canMove = false;

		//switch ((DIRECTIONS)rndDirection.Next(5))
		switch((DIRECTIONS)1)
		{
			case DIRECTIONS.NORTH:
				direction.x = 0;
				direction.y = -speed;
				break;
			case DIRECTIONS.EAST:
				direction.x = speed;
				direction.y = 0;
				break;
			case DIRECTIONS.WEST:
				direction.x = -speed;
				direction.y = 0;
				break;
			case DIRECTIONS.SOUTH:
				direction.x = 0;
				direction.y = speed;
				break;
		}
		cooldown.WaitTime = 1;
		cooldown.Start();

		canMove = CanIMove(this.Position + this.direction);

		if(!canMove)
		{
			this.direction = Vector2.Zero;
		}
	}

	private bool CanIMove(Vector2 newPosition)
	{
		bool result = true;

		if (newPosition.x <= 0 || newPosition.x >= chunkBoundaries.x)
			result = false;
		if (newPosition.y <= 0 || newPosition.y >= chunkBoundaries.x)
			result = false;
		return result;
	}
}

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

		switch ((DIRECTIONS)rndDirection.Next(5))
		{
			case DIRECTIONS.NORTH:
				this.dir.x = 0;
				this.dir.y = -speed;
				break;
			case DIRECTIONS.EAST:
				this.dir.x = speed;
				this.dir.y = 0;
				break;
			case DIRECTIONS.WEST:
				this.dir.x = -speed;
				this.dir.y = 0;
				break;
			case DIRECTIONS.SOUTH:
				this.dir.x = 0;
				this.dir.y = speed;
				break;
		}
		cooldown.WaitTime = 1;
		cooldown.Start();

	}
}

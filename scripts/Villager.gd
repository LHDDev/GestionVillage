extends KinematicBody2D


enum DIRECTION{NORTH,EAST,SOUTH,WEST}
enum STATE{IDLE,WALK}

var state
var cooldown
var dir = Vector2.ZERO
var worldBoundaries

export(int) var speed

signal moveVillager
# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	
	get_tree().get_root().get_node("World").worldBoundaries
	cooldown = Timer.new()
	add_child(cooldown)
	cooldown.connect("timeout",self,"move")
	
	move()
	


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	move_and_collide(dir*delta)
	
func move():
	var rndDirection 
	var canMove = false
	rndDirection = randi()%4
	print(rndDirection)
	match rndDirection :
		DIRECTION.NORTH : 
#			dir = Vector2(0,-speed)
			pass
		DIRECTION.EAST : 
			dir = Vector2(speed,0)
			print(global_position.x + dir.x)
		DIRECTION.WEST : 
			dir = Vector2(-speed,0)
		DIRECTION.SOUTH : 
#			dir = Vector2(0,speed)
			pass
	canMove = false
	if not can_move() :
		dir = Vector2.ZERO
	
	cooldown.set_wait_time(1)
	cooldown.start()
	
func can_move():
	print(get_viewport_rect().size.x)
	var result = true
	if position.x - dir.x <= 10 or position.x + dir.x >= get_viewport_rect().size.x -10 :
		print("NON")
		return false

	if position.y - dir.y <= 10 or position.y + dir.y >= get_viewport_rect().size.y -10 :
		return false
	return true

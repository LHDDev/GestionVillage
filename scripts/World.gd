extends Node2D

const VILLAGER = preload("res://scenes/Villager.tscn")

export(int) var nbVillagers
export(int) var chunkSize

# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	for i in range(nbVillagers):
		var newVillager = VILLAGER.instance()
		var pos = Vector2()
		pos.x = rand_range(100,chunkSize)
		pos.y = rand_range(100,chunkSize)
		while not canSpawn(pos) :
			pos.x = rand_range(100,chunkSize)
			pos.y = rand_range(100,chunkSize)
		newVillager.position = pos
		add_child(newVillager)
		

func _draw():
	var chunk = Vector2(chunkSize,chunkSize)
	var spawn_zone = Rect2(-chunk / 2 ,chunk)
	draw_rect(spawn_zone,Color.red,false)

func canSpawn(pos_spawn):
	# Check si à cette position, il existe pas déjà un élément.
	# Si il existe : retourner False
	# Si c'est ok : retourner True
	for n in get_tree().get_nodes_in_group("villagers"):
		if (n.position.x - 5 <= pos_spawn.x && n.position.y-5 <= pos_spawn.x) && (n.position.x + 5 >= pos_spawn.x && n.position.y+5 <= pos_spawn.y) :
			return false
	return true
	pass

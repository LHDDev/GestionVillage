extends Node2D

const VILLAGER = preload("res://scenes/Villager.tscn")

export(int) var nbVillagers
export(Vector2) var worldBoundaries

# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	for i in range(nbVillagers):
		var newVillager = VILLAGER.instance()
		var pos = Vector2()
		pos.x = rand_range(100,worldBoundaries.x)
		pos.y = rand_range(100,worldBoundaries.y)
		newVillager.position = pos
		add_child(newVillager)

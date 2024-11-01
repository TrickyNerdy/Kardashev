extends Sprite2D

func _ready():
	material = material.duplicate()
	var light_x = randf_range(0.0, 1.0)
	var light_y = randf_range(0.0, 1.0)
	material.set_shader_parameter("light_origin", Vector2(light_x, light_y))
	material.set_shader_parameter("seed", randf_range(1.0, 10.0))
	material.set_shader_parameter("pixels", int(scale.x*100))

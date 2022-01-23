extends Node

func playAnims():
	for x in get_children():
		x.Fire()


func ReverseAnim():
	for x in get_children():
		x.Reload()

func _input(event):
	if event.is_action_pressed("ui_up"):
		for x in get_children():
			x.Fire()
			yield(get_tree().create_timer(0.1), "timeout")
	if event.is_action_pressed("ui_down"):
		for x in get_children():
			x.Reload()
			yield(get_tree().create_timer(0.1), "timeout")

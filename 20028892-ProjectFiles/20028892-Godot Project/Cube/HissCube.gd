tool
extends MeshInstance

onready var tween = $Tween
export var distance = 2
export var direction = Vector3(0,0,0)
export(bool) var Fire = false setget EditorFire
export(bool) var Reset = false setget EditorReset

func EditorFire(new_bool):
	if Engine.editor_hint:
		if new_bool:
			Fire()

func EditorReset(new_bool):
	if Engine.editor_hint:
		if new_bool:
			Reload()

func Fire():
	var endPos = Vector3(translation.x + (direction.x * distance), translation.y + (direction.y * distance), translation.z + (direction.z * distance))
	tween.interpolate_property(self, "translation", translation, endPos, 1, Tween.TRANS_CUBIC, Tween.EASE_IN_OUT)
	tween.start()

func Reload():
	var endPos = Vector3(translation.x - (direction.x * distance), translation.y - (direction.y * distance), translation.z - (direction.z * distance))
	tween.interpolate_property(self, "translation", translation, endPos, 1, Tween.TRANS_CUBIC, Tween.EASE_IN_OUT)
	tween.start()

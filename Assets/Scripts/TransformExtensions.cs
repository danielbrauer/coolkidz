using UnityEngine;

public static class TransformExtensions {

	public static void ForEachChild(this Transform parent, System.Action<Transform> action) {
		action(parent);
		foreach (Transform child in parent) {
			child.ForEachChild(action);
		}
	}
}

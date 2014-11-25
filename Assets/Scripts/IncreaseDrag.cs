using UnityEngine;
using System.Collections;

public class IncreaseDrag : MonoBehaviour {
	
	[SerializeField] float drag = 20f;
	[SerializeField] float angularDrag = 20f;
	
	
	void OnTriggerEnter(Collider other) {
		var rigidbody = other.attachedRigidbody;
		if (rigidbody) {
			rigidbody.drag = drag;
			rigidbody.angularDrag = angularDrag;
			
			var splasher = rigidbody.GetComponent<Splasher>();
			if (splasher) {
				splasher.Go();
			}
		}
	}
}

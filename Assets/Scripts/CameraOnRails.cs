using UnityEngine;
using System.Collections;

public class CameraOnRails : MonoBehaviour {

	[SerializeField] Rigidbody target1;
	[SerializeField] Rigidbody target2;
	[SerializeField] float smoothTime = 1f;
	[SerializeField] float lookAhead = 2f;
	[SerializeField] float maxSpeed = 20f;
	[SerializeField] float minY = 45f;
	float yOffset;
	Vector3 velocity;
	
	protected void Start() {
		yOffset = transform.position.y - (target1.position.y + target2.position.y)*0.5f;
	}
	
	protected void LateUpdate() {
		var leadingTarget = (target1.position.x < target2.position.x) ? target1 : target2;
		var targetPosition = leadingTarget.position;
		
		targetPosition += leadingTarget.velocity*smoothTime*lookAhead;
		targetPosition.z = transform.position.z;
		targetPosition.y += yOffset;
		targetPosition.y = Mathf.Max(targetPosition.y, minY);
		
		transform.position = Vector3.SmoothDamp(
			transform.position,
			targetPosition,
			ref velocity,
			smoothTime,
			maxSpeed
		);
	}
}

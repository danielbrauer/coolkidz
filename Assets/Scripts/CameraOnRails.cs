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
		var targetAverage = (target1.position + target2.position)*0.5f;
		var targetVelocityAverage = (target1.velocity + target2.velocity)*0.5f;
		
		targetAverage += targetVelocityAverage*smoothTime*lookAhead;
		targetAverage.z = transform.position.z;
		targetAverage.y += yOffset;
		targetAverage.y = Mathf.Max(targetAverage.y, minY);
		
		transform.position = Vector3.SmoothDamp(
			transform.position,
			targetAverage,
			ref velocity,
			smoothTime,
			maxSpeed
		);
	}
}

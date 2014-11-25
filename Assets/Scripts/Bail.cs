using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class Bail : MonoBehaviour {
	
	[SerializeField] private string buttonName;
	[SerializeField] private GameObject ragdoll;
	[SerializeField] private float randomVelocity = 10f;
	
	protected void Update() {
		if (!ragdoll.activeSelf && CrossPlatformInputManager.GetButton(buttonName)) {
			
			GetComponent<CarDragRaceControl>().enabled = false;
			
			ragdoll.SetActive(true);
			ragdoll.transform.parent = null;
			
			var velocity = GetComponent<Rigidbody>().velocity;
			
			ragdoll.transform.ForEachChild(
				delegate(Transform x) {
					var rigidbody = x.GetComponent<Rigidbody>();
					if (rigidbody) {
						rigidbody.AddForce(velocity + Random.insideUnitSphere*randomVelocity, ForceMode.VelocityChange);
					}
				}
			);
		}
	}
	
}
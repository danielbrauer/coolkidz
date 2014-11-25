using UnityEngine;
using System.Collections;

public class Splasher : MonoBehaviour {

	[SerializeField] ParticleSystem splash;
	[SerializeField] GameObject finishText;
	
	public void Go() {
		if (splash) {
			Instantiate(splash, transform.position, Quaternion.identity);
		}
		if (finishText) {
			finishText.SetActive(true);
		}
	}
}

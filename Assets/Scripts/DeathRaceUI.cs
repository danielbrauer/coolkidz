using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class DeathRaceUI : MonoBehaviour {
	
	[SerializeField] string grahamBailButton;
	[SerializeField] string tomBailButton;
	[SerializeField] GameObject titleScreen;
	[SerializeField] GameObject startText;
	[SerializeField] GameObject grahamReady;
	[SerializeField] GameObject tomReady;
	[SerializeField] float flashTime = 0.2f;
	[SerializeField] float flashTime2 = 0.2f;
	
	public enum ProgressState {
		Menu,
		Playing,
		Finished
	}
	
	public ProgressState CurrentState {
		get; protected set;
	}
	
	protected void Start() {
		StartCoroutine(MenuRoutine());
	}
	
	protected IEnumerator MenuRoutine() {
		CurrentState = ProgressState.Menu;
		titleScreen.SetActive(true);
		
		var grahamIsReady = false;
		var tomIsReady = false;
		
		var startTime = 0f;
		
		while (true) {
			
			var flash = Mathf.Repeat(Time.time, flashTime*2f) > flashTime;
			var flash2 = Mathf.Repeat(Time.time, flashTime2*2f) > flashTime2;
			
			startText.SetActive(flash);
			
			grahamIsReady = CrossPlatformInputManager.GetButton(grahamBailButton);
			tomIsReady = CrossPlatformInputManager.GetButton(tomBailButton);
			
			grahamReady.SetActive(flash2 && grahamIsReady);
			tomReady.SetActive(flash2 && tomIsReady);
			
			if (grahamIsReady && tomIsReady) {
				Debug.Log("Both Baield!");
				startTime = Time.time;
				break;
			}
			yield return null;
		}
		
		while (Time.time < startTime + 1f) {
			
			var flash2 = Mathf.Repeat(Time.time, flashTime2*2f) > flashTime2;
			
			grahamReady.SetActive(flash2);
			tomReady.SetActive(flash2);
			yield return null;
		}
		
		titleScreen.SetActive(false);
		startText.SetActive(false);
		grahamReady.SetActive(false);
		tomReady.SetActive(false);
		StartCoroutine(PlayingRoutine());
	}
	
	protected IEnumerator PlayingRoutine() {
		CurrentState = ProgressState.Playing;
		
		while (true) {
			yield return null;
		}
		
		StartCoroutine(FinishedRoutine());
	}
	
	protected IEnumerator FinishedRoutine() {
		CurrentState = ProgressState.Finished;
		
		while (true) {
			yield return null;
		}
		
		StartCoroutine(MenuRoutine());
	}
}

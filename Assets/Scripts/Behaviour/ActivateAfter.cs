using UnityEngine;
using System.Collections;

public class ActivateAfter : MonoBehaviour {
	public float timeOfActivation;
	public GameObject obj;

	private float timeBuffer = 0;
	private bool stop = false;

	void FixedUpdate() {
		timeBuffer += Time.fixedDeltaTime;
		if(timeBuffer > timeOfActivation && !stop)
		{
			obj.SetActive(true);
			stop = true;
		}
	}
}

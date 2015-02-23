using UnityEngine;
using System.Collections;

public class ActivateAfter : MonoBehaviour {
	public float timeOfActivation;
	public GameObject obj;

	private float timeBuffer = 0;
	private bool stop = false;

	// Update is called once per frame
	void Update () {
		timeBuffer += Time.deltaTime;
	}

	void FixedUpdate() {
		if(timeBuffer > timeOfActivation && !stop)
		{
			obj.SetActive(true);
			stop = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class AngleMove : MonoBehaviour {
	float i = 180;
	float s = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Updater updaterRef = GetComponent<Updater> ();
		updaterRef.angle = i;
		updaterRef.speed = s;
		updaterRef.Change ();
		i -= 0.1f;

		if(s < 4)
			s += 0.025f;
	}
}

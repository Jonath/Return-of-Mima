using UnityEngine;
using System.Collections;

public class AngleMove : MonoBehaviour {
	float i = 180;
	float s = 2;

	float count = 0;

	void FixedUpdate () {
		Updater updaterRef = GetComponent<Updater> ();
		updaterRef.Angle = i;
		updaterRef.Speed = s;

		if(count > 0.1f)
		{
			count = 0;
			i-=5;
		}

		count += Time.fixedDeltaTime;
	}
}

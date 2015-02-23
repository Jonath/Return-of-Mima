using UnityEngine;
using System.Collections;

public class ChangeAfter : MonoBehaviour {
	public float timeOfActivation;
	public float newSpeed;
	public float newAngle;
	
	private float timeBuffer = 0;

	void FixedUpdate() {
		timeBuffer += Time.fixedDeltaTime;
		if(timeBuffer > timeOfActivation)
		{
			GetComponent<Updater>().Angle = newAngle;
			GetComponent<Updater>().Speed = newSpeed;
			Destroy(this);
		}
	}	

	public static void Create(GameObject objRef, float p_spd, float p_ang, float p_time)
	{
		ChangeAfter change = objRef.AddComponent<ChangeAfter>();
		change.newSpeed = p_spd;
		change.newAngle = p_ang;
		change.timeOfActivation = p_time;
	}
}



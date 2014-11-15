using UnityEngine;
using System;
using System.Collections;

public class Updater : MonoBehaviour {
	public float angle;
	public float speed;

	Vector2 movement;

	void Start()
	{
		Change ();
	}

	public void Change()
	{
		movement = Quaternion.Euler (0, 0, angle) * -Vector2.right * speed;
		rigidbody2D.velocity = movement;
	}
}

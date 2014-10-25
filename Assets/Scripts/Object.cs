using UnityEngine;
using System;
using System.Collections;

public class Object : MonoBehaviour {
	public float angle;
	public float speed;

	Vector2 movement;

	void OnEnable()
	{
		movement = Vector2.zero;
	}
	
	void Update() {
		movement.x = (float) Math.Cos (angle * (Math.PI / 180.0));
		movement.y = (float) Math.Sin (angle * (Math.PI / 180.0));
	}

	void FixedUpdate() {
		rigidbody2D.velocity = movement * speed * (Time.deltaTime * 60.0f);
	}
}

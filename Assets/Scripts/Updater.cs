﻿using UnityEngine;
using System;
using System.Collections;

public class Updater : MonoBehaviour {
    // Variables used in order to update an object
	private float angle = 0;
	private float speed = 0;
    private float acc = 0;
    private float ang_vec = 0;
    private float max_speed = 5;

	private float count = 0;
	private Vector2 movement;
	
	public float Angle {
		get { return angle; }
		set { angle = value % 360; }
	}

	public float Speed {
		get { return speed; }
		set { speed = Mathf.Min(value, max_speed); }
	}

    public float Acceleration {
        get { return acc; }
        set { acc = value; }
    }

    public float Angular_Velocity
    {
        get { return ang_vec; }
        set { ang_vec = value; }
    }

    public float Max_Speed
    {
        get { return max_speed; }
        set { max_speed = Mathf.Max(0, value); }
    }

    public void Update() {
        speed = Mathf.Min(speed + acc, max_speed);
        angle = (angle + ang_vec) % 360;

        float radAngle = angle * Mathf.Deg2Rad;
        movement = new Vector2(speed * Mathf.Cos(radAngle), speed * Mathf.Sin(radAngle));
    }

	public void FixedUpdate() {
        rigidbody2D.velocity = movement * Time.deltaTime * 60;

        if(gameObject.tag == "Bullet" || gameObject.tag == "BouncingBullet")
            transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
	}
}

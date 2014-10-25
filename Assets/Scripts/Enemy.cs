using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	public List<Movement> movements;	// List of Movements to update

	private int index;					// Index to get the current movement
	private int elapsed;				// Elapsed frames since the begining of the movement

	private float direction;			// The direction the enemy is facing,
										// i.e. 1 for right, -1 for left, 0 for middle

	private bool moving;

	Animator anim;
	Object obj;

	void Start ()
	{
		anim = GetComponent<Animator>();
		direction = 0.0f;
		moving = false;
	}
	
	void Update()
	{
		Debug.Log (direction);
		anim.SetFloat ("direction", direction);
		anim.SetBool ("moving", moving);

		if (!(movements.Count == 0))
		{
			// When current movement time is over, go to the next movement
			if(elapsed > movements[index].time)
			{
				index = (index + 1) % movements.Count;
				elapsed = 0;
			}

			// Get the behavior to set for the Object component
			if(movements[index].type == "wait")
			{
				obj.angle = 0;
				obj.speed = 0;
				elapsed++;
			}
			else
			{
				obj.angle = movements[index].angle;
				obj.speed = movements[index].speed;
				elapsed++;
			}
		}
	}

	public void FixedUpdate()
	{
		float xBefore = transform.position.x;
		//obj.Update();

		if (transform.position.x > xBefore)
		{
			direction = 1;
			moving = true;
		}
		if (transform.position.x < xBefore)
		{
			direction = -1;
			moving = true;
		}
		if (transform.position.x == xBefore)
		{
			direction = 0;
			moving = false;
		}
	}
}
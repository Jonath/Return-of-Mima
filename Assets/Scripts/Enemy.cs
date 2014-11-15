using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	public List<Movement> movements;	// List of Movements to update

	private int index;					// Index to get the current movement
	private float elapsed;				// Elapsed frames since the begining of the movement

	public float direction;				// The direction the enemy is facing,
										// i.e. 1 for right, -1 for left, 0 for middle

	public bool moving;

	Animator anim;
	Updater obj;

	void Start ()
	{
		anim = gameObject.GetComponent<Animator>();
		obj = gameObject.GetComponent<Updater>();

		direction = 0.0f;
		moving = false;

		ChangeMovement();
	}
	
	void Update()
	{
		anim.SetFloat ("direction", direction);
		anim.SetBool ("moving", moving);

		if (!(movements.Count == 0))
		{
			// When current movement time is over, go to the next movement
			if(elapsed > movements[index].time)
			{
				index = (index + 1) % movements.Count;
				ChangeMovement();

				elapsed = 0;
			}

			elapsed += Time.deltaTime;
		}
	}

	private void ChangeMovement()
	{
		obj.angle = movements[index].angle;
		obj.speed = movements[index].speed;
		obj.Change ();
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
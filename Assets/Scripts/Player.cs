using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {
	
	public float   speed;
	public Boundary boundary;

	private Vector2 movement;
	
	Animator anim;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		movement.x = Input.GetAxis ("Horizontal");
		movement.y = Input.GetAxis ("Vertical");
		
		anim.SetFloat ("speed", movement.x);
		
		if (movement.x == 0)
			anim.SetBool ("moving", false);
		else
			anim.SetBool ("moving", true);

		// Shooting
		bool shoot = Input.GetButton ("Fire");
		
		if (shoot)
		{
			Fire fire = GetComponent<Fire>();
			if (fire != null)
			{
				fire.Attack(false);
			}
		}
	}
	
	// Fixed update
	void FixedUpdate ()
	{
		rigidbody2D.velocity = movement * speed;
		rigidbody2D.position = new Vector2 (
			Mathf.Clamp(rigidbody2D.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(rigidbody2D.position.y, boundary.yMin, boundary.yMax)
		);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			Destroy (gameObject);
		}
	}
}

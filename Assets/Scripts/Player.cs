using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {
	public static Player current;

    public int      fullLives = 3;
    public int      fractLives = 0;
    public int      fullBombs = 2;
    public int      fractBombs = 0;

	public float    speed;
    public float    power;

    private float   graze = 0;
    private bool    dead = false;
    private bool    shoot = false;

	public Boundary boundary;
    public GameObject optionPrefab;

	private Vector2 movement;
    private List<GameObject> activeOptions;

    public float Graze {
        get { return graze; }
        set { graze = value; }
    }

    public bool Dead {
        get { return dead; }
        set { dead = value; }
    }

    public bool Shoot {
        get { return shoot; }
        set { shoot = value; }
    }

	Animator anim;

	void Awake ()
	{
		current = this;
	}
	
	void Start ()
	{
		anim = GetComponent<Animator>();

        // Adding the main shot !
        Fire fire = gameObject.GetComponent<Fire>();

        if(fire != null)
            fire.ShotDelegate = Patterns.MainReimuShot;
	}

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
		shoot = Input.GetButton ("Fire");
		
		if (shoot)
		{
			Fire fire = GetComponent<Fire>();

			if (fire != null) {
				fire.Attack();
                // Attack with each option in the list
			}
		}

        if (fractBombs / 5 > 0)
        {
            fractBombs -= 5;
            fullBombs++;
        }

        if (fractLives / 5 > 0)
        {
            fractLives -= 5;
            fullLives++;
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

    // Add an option
    void AddOption(Vector3 pos, float angle, float angleDep)
    {
        if (optionPrefab != null)
        {
            GameObject option = Instantiate(optionPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;

            Option optionCpt = option.GetComponent<Option>();
            optionCpt.angle = angle;
            optionCpt.angleDep = angleDep;

            option.transform.Translate(pos);
            option.transform.parent = gameObject.transform;
        }
    }

    // Remove an option
    void RemoveOption(GameObject option)
    {
        Destroy(option);
    }
}

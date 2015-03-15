using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
    public delegate void Delegate(GameObject obj, Transform prefab);

	private Transform shotPrefab;
	private int shootingRate = 5;

	private float shootCooldown;
    private Delegate shotDelegate;

    public Transform ShotPrefab
    {
        set { shotPrefab = value; }
    }

    public int ShootingRate
    {
        set { shootingRate = value; }
    }

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}

    public Delegate ShotDelegate
    {
        set
        {
            shotDelegate = value;
        }
    }

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0)
		{
			shootCooldown --;
		}
	}

	public void Attack()
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			if(shotDelegate != null) {
                shotDelegate(gameObject, shotPrefab);
            }
		}
	}
}

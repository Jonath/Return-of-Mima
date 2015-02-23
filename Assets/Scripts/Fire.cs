using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
    public delegate void Delegate(GameObject obj, Transform prefab);

	public Transform shotPrefab;
	public float shootingRate = 0.02f;

	private float shootCooldown;
    private Delegate shotDelegate;

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
			shootCooldown -= Time.deltaTime;
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

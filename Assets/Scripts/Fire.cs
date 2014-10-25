using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public float offset;
	public Transform shotPrefab;
	public float shootingRate = 0.05f;
	private float shootCooldown;

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
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

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Create new shots
			var shotTransform1 = Instantiate(shotPrefab) as Transform;
			var shotTransform2 = Instantiate(shotPrefab) as Transform;
			
			// Assign position
			shotTransform1.position = transform.position + new Vector3(offset, 0, 0);
			shotTransform2.position = transform.position - new Vector3(offset, 0, 0);
			
			// The is enemy property
			Shot shot1 = shotTransform1.gameObject.GetComponent<Shot>();
			if (shot1 != null)
			{
				shot1.isEnemyShot = isEnemy;
			}

			Shot shot2 = shotTransform1.gameObject.GetComponent<Shot>();
			if (shot2 != null)
			{
				shot2.isEnemyShot = isEnemy;
			}
		}
	}
}

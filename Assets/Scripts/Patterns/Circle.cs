using UnityEngine;
using System.Collections;

public class Circle : Pattern {

	public GameObject bulletPrefab;
	public float fireRate;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", 0.5f, fireRate);
	}
	
	// Update is called once per frame
	void Fire ()
	{
		for (int i = 0; i < 360; i += 15) {
			GameObject bullet = ObjectPool.current.GetPooledObject();
			//GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
			bullet.SetActive(true);

			Object compBullet = bullet.GetComponent<Object> ();
				
			compBullet.angle = i;
			compBullet.speed = 2;
			numBullets++;
		}
	}
}

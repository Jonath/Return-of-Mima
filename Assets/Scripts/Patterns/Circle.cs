using UnityEngine;
using System.Collections;

public class Circle : Pattern {
	float count = 0;
	
	void Start () {

	}

	void Update() {
		float i = 0;
		if(count >= 0.5 && canFire)
		{
			while(i < 360)
			{
				BulletPool.current.EnableBullet(transform.position, i, 1f, 4);
				numBullets++;
				i += 30f;
			}
			count = 0;
		}

		count += Time.deltaTime;
	}
}
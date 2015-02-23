using UnityEngine;
using System.Collections;

public class Homing : Pattern {
	public Transform objRef;
	float angle = 0;
	float elapsed;

	void FixedUpdate() {
/*		if(count > 0.4f && canFire && objRef)
		{
			int i = 5;

			//if(angle == 0)
			angle = Mathf.Atan2(transform.position.y - objRef.position.y, transform.position.x - objRef.position.x) * Mathf.Rad2Deg;

			elapsed++;

			if(elapsed % 5 == 0)
			{
				BulletPool.current.EnableBullet(transform.position, angle, 3f, 4);
				
				numBullets++;
				
				if(numBullets % 5 == 0)
				{
					count = 0;
					angle = 0;
					elapsed = 0;
				}
			}
		}
		
		base.FixedUpdate ();*/
	}
}

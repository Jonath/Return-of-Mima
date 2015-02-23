using UnityEngine;
using System.Collections;
using System.Timers; 

public class Circle : Pattern {
	void FixedUpdate() {
		float i = 0;
/*		if(count > 0.4f && canFire)
		{
			while(i < 360)
			{
				GameObject bullet = BulletPool.current.EnableBullet(transform.position, i, 1f, 0, 4f, 4);
                bullet.GetComponent<Updater>().Angular_Velocity = 0.2f;

               // StartCoroutine(Utilities.WaitAndChange(bullet, 1f, i, 2f));

				numBullets++;
				i += 15f;
			}
			i = 0;
			count = 0;
		}

		base.FixedUpdate ();*/
	}
}
using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {
	void OnTriggerExit2D(Collider2D other)
	{
		GameObject objRef = other.gameObject;
		if (objRef.tag == "Bullet") {
			// Resetting the object for further use - Pool implemented !
			BulletPool.current.DisableBullet(objRef);
		} else if(objRef.tag == "Shot") {
            // Destroy the shot - TODO : use a pool ?
			Destroy(objRef);
		} else if(objRef.tag == "Enemy") {
            // Destroy the enemy - TODO : use a pool ?
			Destroy(objRef);
        } else if (objRef.tag == "Item") {
            // Destroy the item - TODO : use a pool ?
            Destroy(objRef);
        } else if (objRef.tag == "BouncingBullet") {
            objRef.tag = "Bullet";
            Updater upd = objRef.GetComponent<Updater>();
            upd.Angle += 180;
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject objRef = other.gameObject;
		if (objRef.tag == "Enemy") {
			objRef.GetComponent<Pattern>().canFire = true;
		}
	}
}

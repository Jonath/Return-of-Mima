using UnityEngine;
using System.Collections;

public class BulletCancel : MonoBehaviour {
	void OnTriggerExit2D(Collider2D other)
	{
		GameObject objRef = other.gameObject;
		if (objRef.tag == "Bullet")
		{
			// Resetting the object for further use
			BulletPool.current.DisableBullet(objRef);
		}
		if(objRef.tag == "Shot")
		{
			Destroy(objRef);
		}
	}
}

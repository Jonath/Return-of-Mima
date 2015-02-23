using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int hp = 1;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
            Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Shot shot = otherCollider.gameObject.GetComponent<Shot>();
		if (shot != null)
		{
			Damage(shot.damage);
			Destroy(shot.gameObject);
		}
	}
}

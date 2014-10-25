using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Shot") 
			other.gameObject.SetActive(false);
		if(other != null)
			other.gameObject.GetComponent<Pattern>().canFire = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<Pattern>().canFire = true;
		}
	}	
}

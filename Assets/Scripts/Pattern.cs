using UnityEngine;
using System.Collections;

public class Pattern : MonoBehaviour {
	public bool canFire = false;    // Should the pattern be fired
	public int numBullets = 0;      // Necessary ?

    public GameObject itemPrefab;

    private bool isQuitting = false;

    public void OnDestroy()
    {
        StopAllCoroutines();

        if (!isQuitting)
        {
            // Instantiate an Item.
            if (itemPrefab != null)
            {
                GameObject item = Instantiate(itemPrefab, transform.position, transform.rotation) as GameObject;

                Updater upd = item.GetComponent<Updater>();
                upd.Speed = 1;
                upd.Angle = 90;
            }
        }
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

}

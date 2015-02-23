using UnityEngine;
using System.Collections;

public class Option : MonoBehaviour {
    public float angle = -90;
    public float angleDep = 0;
    public int rot;

    void Awake() {
        gameObject.GetComponent<Fire>().ShotDelegate = Patterns.HomingShot;
    }

	void FixedUpdate () {
        transform.Rotate(new Vector3(0, 0, rot));
	}
}

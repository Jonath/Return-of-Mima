using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {
    public static Difficulty current;

    public Sprite[] difficulties;
    public int difficulty;

    void Awake() {
        current = this;
    }

	void Update () {
        SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
        render.sprite = difficulties[difficulty];
	}
}

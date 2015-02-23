using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hitbox : MonoBehaviour {
    private SpriteRenderer deathCircle;

    void Awake() {
        deathCircle = transform.GetChild(0).GetComponent<SpriteRenderer>();
        deathCircle.enabled = false;
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(0, 0, 1));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = Player.current;
        if (other.gameObject.tag == "Bullet" && !player.Dead)
        {
            player.fullLives--;
            player.Dead = true;
            StartCoroutine(DeathCircle());
            // Destroy(gameObject.transform.parent.gameObject);
        }
    }

    IEnumerator DeathCircle()
    {
        deathCircle.enabled = true;

        float count = 0;
        float scale = 1;

        while(count < 90)
        {
            scale -= 1 / 90f;
            deathCircle.transform.localScale = new Vector3(scale, scale, 1);

            count++;
            yield return new WaitForFixedUpdate();
        }

        Player.current.Dead = false;
    }
}

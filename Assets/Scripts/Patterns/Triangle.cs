using UnityEngine;
using System.Collections;
using System.Timers;

public class Triangle : Pattern
{
    void Start()
    {
        StartCoroutine(TrianglePattern(10));
    }

    IEnumerator TrianglePattern(float interval)
    {
        int n = 1;
        int it = 0;

        if (Player.current != null)
        {
            float ang = Utilities.GetAngleTo(gameObject, Player.current.gameObject);
            Vector3 pos = transform.position;

            while (n < 15)
            {
                for (int a = 0; a < interval; a++) { yield return new WaitForFixedUpdate(); }

                for (int i = -n / 2; i < n / 2 + 1; i++) {
                    GameObject bullet = BulletPool.current.EnableBullet(pos, ang + i * 3, 2f, 4);
                }

                AudioManager.current.Play("shot1", 0.2f, 1);
                n += 2;
                it++;
            }
        }
    }
}
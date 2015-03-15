using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patterns : MonoBehaviour {
    public static Patterns current;

    void Awake () {
        current = this;
    }

    public static IEnumerator Triangle(GameObject obj, GameObject prefab, int spriteID, int size, int delay)
    {
        int n = 1;
        int it = 0;

        if (Player.current != null)
        {
            float ang = Utilities.GetAngleTo(obj, Player.current.gameObject);
            Vector3 pos = obj.transform.position;

            while (n < size)
            {
                for (int a = 0; a < delay; a++) { yield return new WaitForFixedUpdate(); }

                for (int i = -n / 2; i < n / 2 + 1; i++)
                {
                    GameObject bullet = BulletPool.current.EnableBullet(prefab, pos, ang + i * 3, 2f);
                }

                AudioManager.current.Play("shot1", 0.2f, 1);
                n += 2;
                it++;
            }
        }
    }

    public static IEnumerator Circle(GameObject obj, GameObject prefab, float speed, int number, int delay)
    {
        float i = 0;

        for (int a = 0; a < delay; a++) { yield return new WaitForFixedUpdate(); }

        while (i < 360)
        {
            GameObject bullet = BulletPool.current.EnableBullet(prefab, obj.transform.position, i, speed, 0, 4f);
            current.StartCoroutine(Homing(bullet, 50));
            i += 360f / number;
        }

        AudioManager.current.Play("shot1", 0.2f, 1);
    }

    public static IEnumerator Homing(GameObject obj, int delay)
    {
        for (int a = 0; a < delay; a++) { yield return new WaitForFixedUpdate(); }

        obj.GetComponent<Updater>().Angle = Utilities.GetAngleTo(obj, Player.current.gameObject);
        obj.GetComponent<Updater>().Speed = 5;
    }
}
using UnityEngine;
using System.Collections;

public class Patterns : MonoBehaviour {
    public static Patterns current;

    void Awake ()
    {
        current = this;
    }

    public static IEnumerator Triangle(GameObject obj, int delay)
    {
        int n = 1;
        int it = 0;

        if (Player.current != null)
        {
            float ang = Utilities.GetAngleTo(obj, Player.current.gameObject);
            Vector3 pos = obj.transform.position;

            while (n < 15)
            {
                for (int a = 0; a < delay; a++) { yield return new WaitForFixedUpdate(); }

                for (int i = -n / 2; i < n / 2 + 1; i++)
                {
                    GameObject bullet = BulletPool.current.EnableBullet(pos, ang + i * 3, 2f, 4);
                }

                AudioManager.current.Play("shot1", 0.2f, 1);
                n += 2;
                it++;
            }
        }
    }

    public static IEnumerator Circle(GameObject obj, int number, int delay)
    {
        float i = 0;

        for (int a = 0; a < delay; a++) { yield return new WaitForFixedUpdate(); }

        while (i < 360)
        {
            GameObject bullet = BulletPool.current.EnableBullet(obj.transform.position, i, 1f, 0, 4f, 4);
            i += 360f / number;
        }

        AudioManager.current.Play("shot1", 0.2f, 1);
    }

    public static IEnumerator Homing(Updater upd, float angleDep, bool dir)
    {
        GameObject obj = upd.gameObject;
        float inAngle = upd.Angle;
        bool fired = false;

        while (obj != null)
        {
            GameObject closestEnemy = null;

            if (angleDep != 0)
                closestEnemy = Utilities.FindClosestEnemy(obj, dir);
            else
                closestEnemy = Utilities.FindClosestEnemy(obj);

            if (closestEnemy != null && !fired) {
                upd.Angle = Utilities.GetAngleTo(obj, closestEnemy) + angleDep;
            } else {
                upd.Angle = inAngle + angleDep;
                fired = true;
            }

            obj.transform.localEulerAngles = new Vector3(0, 0, upd.Angle + 90);

            if (angleDep > 0)
                angleDep --;
            else
                angleDep ++;

            yield return new WaitForFixedUpdate();
        }
    }

    public static void HomingShot(GameObject obj, Transform shotPrefab)
    {
        Transform shotTransform = Instantiate(shotPrefab) as Transform;

        float angle = obj.GetComponent<Option>().angle;
        float angleDep = obj.GetComponent<Option>().angleDep;

        shotTransform.position = obj.transform.position;
        shotTransform.Rotate(new Vector3(0, 0, angle + 90));

        Updater upd = shotTransform.gameObject.AddComponent<Updater>();

        upd.Angle = angle;
        upd.Max_Speed = 8;
        upd.Speed = 4;

        bool dir;
        if (Player.current.gameObject.transform.position.x < obj.transform.position.x) {
            dir = false;
        } else {
            dir = true;
        }
        current.StartCoroutine(Homing(upd, angleDep, dir));
    }

    public static void MainReimuShot(GameObject obj, Transform shotPrefab)
    {
        // Create new shots
        var shotTransform1 = Instantiate(shotPrefab) as Transform;
        var shotTransform2 = Instantiate(shotPrefab) as Transform;

        // Assign position
        shotTransform1.position = obj.transform.position + new Vector3(0.07f, 0, 0);
        shotTransform2.position = obj.transform.position - new Vector3(0.07f, 0, 0);

        // This is enemy property
        Updater shot1 = shotTransform1.gameObject.AddComponent<Updater>();
        shot1.Angle = -90;
        shot1.Max_Speed = 8;
        shot1.Speed = 8;

        Updater shot2 = shotTransform2.gameObject.AddComponent<Updater>();
        shot2.Angle = -90;
        shot2.Max_Speed = 8;
        shot2.Speed = 8;
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReimuPatterns : MonoBehaviour {
    public static ReimuPatterns current;

    void Awake() {
        current = this;
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
        shot1.Angle = 90;
        shot1.Max_Speed = 8;
        shot1.Speed = 8;

        Updater shot2 = shotTransform2.gameObject.AddComponent<Updater>();
        shot2.Angle = 90;
        shot2.Max_Speed = 8;
        shot2.Speed = 8;
    }

    public static void NeedleShot(GameObject obj, Transform shotPrefab)
    {
        Transform shotTransform = Instantiate(shotPrefab) as Transform;

        float angle = obj.GetComponent<Option>().angle;
        float angleDep = obj.GetComponent<Option>().angleDep;

        shotTransform.position = obj.transform.position + new Vector3(0, 0.07f, 0);
        shotTransform.Rotate(new Vector3(0, 0, angle + 90));

        Updater upd = shotTransform.gameObject.AddComponent<Updater>();

        upd.Angle = angle;
        upd.Max_Speed = 8;
        upd.Speed = 8;
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
        if (Player.current.gameObject.transform.position.x < obj.transform.position.x)
        {
            dir = false;
        }
        else
        {
            dir = true;
        }
        current.StartCoroutine(Homing(upd, angleDep, dir));
    }


    public static IEnumerator Homing(Updater upd, float angleDep, bool dir)
    {
        GameObject obj = upd.gameObject;
        float inAngle = upd.Angle;
        bool fired = false;
        bool locked = false;
        int ct = 0;

        while (obj != null)
        {
            List<GameObject> closestEnemies = Utilities.FindClosestEnemies(obj);

            if (closestEnemies.Count != 0 && !fired)
            {
                GameObject enemy = closestEnemies[ct % closestEnemies.Count];
                upd.Angle = Utilities.GetAngleTo(obj, enemy) + angleDep;

                if (angleDep == 0)
                {
                    if (enemy.transform.position.x > enemy.transform.position.x)
                    {
                        angleDep = 10;
                    }
                    else if (enemy.transform.position.x < enemy.transform.position.x)
                    {
                        angleDep = -10;
                    }
                }

                locked = true;
            }
            else if (!locked)
            {
                upd.Angle = inAngle + angleDep;
                fired = true;
            }

            obj.transform.localEulerAngles = new Vector3(0, 0, upd.Angle - 90);

            if (angleDep > 0)
            {
                angleDep--;
            }
            else
            {
                angleDep++;
            }

            ct++;
            yield return new WaitForFixedUpdate();
        }
    }
}
using UnityEngine;
using System.Collections;

public static class Utilities
{
    delegate void ChangeDelegate();

    public static IEnumerator WaitAndChange(GameObject bullet, int interval, float? ang, float? spd)
    {
        for (int a = 0; a < interval; a++) { yield return new WaitForFixedUpdate(); }
        Updater updRef = bullet.GetComponent<Updater>();

        if (updRef != null)
        {
            if(ang.HasValue)
                updRef.Angle = ang.Value;

            if(spd.HasValue)
                updRef.Speed = spd.Value;
        }
    }

    public static IEnumerator WaitAndChange2(GameObject bullet, int interval, float? ang, float? spd,
                                            float? acc, float? ang_vec, float? max_spd)
    {
        for (int a = 0; a < interval; a++) { yield return new WaitForFixedUpdate(); }
        Updater updRef = bullet.GetComponent<Updater>();

        if (updRef != null)
        {
            if (ang.HasValue)
                updRef.Angle = ang.Value;

            if (spd.HasValue)
                updRef.Speed = spd.Value;

            if (acc.HasValue)
                updRef.Acceleration = acc.Value;

            if (ang_vec.HasValue)
                updRef.Angular_Velocity = ang_vec.Value;

            if (max_spd.HasValue)
                updRef.Max_Speed = max_spd.Value;
        }
    }

    public static float GetAngleTo(GameObject obj1, GameObject obj2)
    {
        Vector3 pos1 = obj1.transform.position;
        Vector3 pos2 = obj2.transform.position;
        return Mathf.Atan2(pos1.y - pos2.y, pos1.x - pos2.x) * Mathf.Rad2Deg;
    }

    public static float GetAngleTo(float x1, float x2, float y1, float y2)
    {
        return Mathf.Atan2(y1 - y2, x1 - x2) * Mathf.Rad2Deg;
    }

    public static float GetDistanceTo(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v1.x - v2.x, 2) + Mathf.Pow(v1.y - v2.y, 2));
    }

    public static float GetDistanceTo(float x1, float x2, float y1, float y2)
    {
        return Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
    }

    public static GameObject FindClosestEnemy(GameObject obj)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDist = float.MaxValue;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            Pattern pattern = enemy.GetComponent<Pattern>();
            if (pattern != null && pattern.canFire == true)
            {
                float dist = GetDistanceTo(obj.transform.position, enemy.transform.position);

                if (dist < minDist)
                {
                    minDist = dist;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }

    public static GameObject FindClosestEnemy(GameObject obj, bool dir)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDist = float.MaxValue;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            Pattern pattern = enemy.GetComponent<Pattern>();
            if (dir && obj.transform.position.x > enemy.transform.position.x || !dir && obj.transform.position.x < enemy.transform.position.x)
            {
                if (pattern != null && pattern.canFire == true)
                {
                    float dist = GetDistanceTo(obj.transform.position, enemy.transform.position);

                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestEnemy = enemy;
                    }
                }
            }
        }

        return closestEnemy;
    }

    public static IEnumerator Wait(int frames)
    {
        for (int a = 0; a < frames; a++) { yield return new WaitForFixedUpdate(); }
    }

    public static IEnumerator MoveBy(GameObject obj, float x, float y, float spd)
    {
        Vector3 start = obj.transform.position;
        Vector3 target = new Vector3(start.x + x, start.y + y, 0);

        float delta = GetDistanceTo(start, target); ;
        float bestDelta = delta;

        Updater upd = obj.GetComponent<Updater>();
        upd.Angle = GetAngleTo(start.x, target.x, start.y, target.y);

        if (spd == 0)
            spd = 1;

        upd.Speed = spd;

        while (delta <= bestDelta) // While we reduce the distance !
        {
            start = obj.transform.position;
            bestDelta = delta; // BestDelta = previous delta
            delta = Utilities.GetDistanceTo(start, target); // Current delta
            yield return new WaitForFixedUpdate();
        }

        // Lerping out the rest of the move /!\ PATCH
        obj.transform.position = Vector3.Lerp(obj.transform.position, target, 2);

        upd.Angle = 0;
        upd.Speed = 0;
        //Debug.Log(obj.transform.position);
    }

    public static IEnumerator MoveAngle(GameObject obj, float angle, float chg, float speed, float time)
    {
        Updater upd = obj.GetComponent<Updater>();
        upd.Angle = angle;
        upd.Speed = speed;

        float cpt = 0;

        while (cpt < time)
        {
            cpt++;
            upd.Angle -= chg;
            yield return new WaitForFixedUpdate();
        }
    }

    public static IEnumerator Disappear(GameObject obj, float delta)
    {
        SpriteRenderer render = obj.GetComponent<SpriteRenderer>();
        Color remove = new Color(0, 0, 0, 1.0f / delta);

        if (render != null)
        {
            while (render.color.a != 0.0f)
            {
                render.color -= remove;
                yield return new WaitForFixedUpdate();
            }
        }
    }

    public static IEnumerator Appear(GameObject obj, float delta)
    {
        SpriteRenderer render = obj.GetComponent<SpriteRenderer>();
        Color add = new Color(0, 0, 0, 1.0f / delta);

        if (render != null)
        {
            while (render.color.a != 0.0f)
            {
                render.color += add;
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
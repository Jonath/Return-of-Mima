using UnityEngine;
using System.Collections;

public class Laser : Pattern
{
    GameObject LaserA = null;

    // Effect of a segment
    void LaserGfxFrameA(float f, float x, float y, float ang,
                              float sx, float sy, float rd, float gn, float bl, float al)
    {
	    if(LaserA == null){return;}

	    f = f * 16;
        LaserA.transform.position = new Vector3(x, y, 0);
        LaserA.transform.rotation = Quaternion.Euler(0, 0, ang); // not sure 
        LaserA.transform.localScale = new Vector3(sx, sy, 1);
        LaserA.GetComponent<SpriteRenderer>().color = new Color(rd, gn, bl);
        // TODO
	    /*ObjRender_SetAlpha(myLasA, al);
	    //ObjSpriteList2D_SetSourceRect(myLasA, 1+f, 1, 16+f, 16);
	    ObjSpriteList2D_SetSourceRect(myLasA, 257+f, 545, 272+f, 560);
	    //ObjSpriteList2D_SetDestRect(myLasA, -8*sx,-8*sy, 8*sx,8*sy);
	    ObjSpriteList2D_SetDestCenter(myLasA);
	    ObjSpriteList2D_AddVertex(myLasA);*/
    }

    // Big fat method of doom to call a CurvyLaser !
    void CurvyLaser(float x, float y, float spd, float ang,
                      float acc, float ang_vec, float max_spd,
                      int segments, float seg_rate, int id, int delay)
    {
        GameObject parent = BulletPool.current.EnableBullet(new Vector3(x, y, 0), ang, 0, 0, max_spd, id);
        StartCoroutine(Utilities.WaitAndChange(parent, delay, null, spd));
        StartCoroutine(TLaser(parent, x, y, spd, ang, acc, max_spd, segments, seg_rate, id, delay));
    }

    IEnumerator TLaser(GameObject parent, float x, float y, float spd, float ang,
                      float acc, float max_spd, int segments, float seg_rate, int id, int delay)
    {
        for (int a = 0; a < delay; a++) { yield return new WaitForFixedUpdate(); }
        float time = segments * seg_rate;
        GameObject tip = BulletPool.current.EnableBullet(new Vector3(x, y, 0), ang, 0, 0, max_spd, id);
        // TODO : set add rendering
        StartCoroutine(TMoveTrail(tip, parent, 0, id, 2, 255, time+seg_rate));

        float x2 = tip.transform.position.x;
        float y2 = tip.transform.position.y;
        float ang2 = tip.GetComponent<Updater>().Angle + 90;

        GameObject seg = tip;
        float c = 0;

        while (tip.activeSelf)
        {
            if (!parent.activeSelf)
            {
                // TODO : TSeg call
                break;
            }

            float x3 = tip.transform.position.x;
            float y3 = tip.transform.position.y;
            float ang3 = tip.GetComponent<Updater>().Angle + 90;
            // TODO : ObjMove_SetPosition(parent,x,y) - Maybe not necessary
            if (c % seg_rate == 0)
            {

            }
            // TODO : TSeg call
            x2 = x3;
            y2 = y3;
            ang2 = ang3;

            c++;

            for (int a = 0; a < seg_rate; a++) { yield return new WaitForFixedUpdate(); }
        }

        if (parent.activeSelf) { parent.SetActive(false); }
    }

    IEnumerator TMoveTrail(GameObject tip, GameObject parent, int time, int id,
                          float sca, float col, float laser_time)
    {
        float remove_time = laser_time + 1;
        while (tip.activeSelf && parent.activeSelf) // TODO : check condition
        {
            StartCoroutine(Utilities.WaitAndChange2(tip, time, parent.GetComponent<Updater>().Speed, parent.GetComponent<Updater>().Angle, 0, 0, 10));
            // TODO : LaserGFX 
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(Utilities.WaitAndChange2(tip, 0, 0, null, 0, 0, 10));
        while (remove_time > 0 && tip.activeSelf)
        {
            remove_time--;
            yield return new WaitForFixedUpdate();
        }
        if (tip.activeSelf) { tip.SetActive(false); }
    }

    IEnumerator TSeg(GameObject tip, GameObject seg, int delay,
                    float x, float y, float ang,
                    float x2, float y2, float ang2,
                    int time, float seg_rate, int id)
    {
        for (int a = 0 ; a < delay ; a++) { yield return new WaitForFixedUpdate(); }
        
        bool bbreak = false;
        float sca = 0.25f;
        float sca_d = -0.005f;

        for (int a = 0 ; a < seg_rate ; a++)
        {
            if (!tip.activeSelf) { bbreak = true; break; } // TODO : or "finish" in cond
            float sdist = Mathf.Pow(Mathf.Pow((y2 - y), 2) + Mathf.Pow((x2 - x), 2), 15) / 14; // Wtf C#
            // TODO : LaserGFX (wtf is dat thing srsly ?)
            // TODO : set shot intersection line <=> set hitbox, line of width 2 (fuck !) between x,y and x2,y2
            sca += sca_d;

            yield return new WaitForFixedUpdate();
        }

        for (int a = 0; a < time - delay - 2 - 2 * seg_rate; a++) // WTF ?!
        {
            if (!tip.activeSelf) { bbreak = true; break; } // TODO : or "finish" in cond
            float sdist = Mathf.Pow(Mathf.Pow((y2 - y), 2) + Mathf.Pow((x2 - x), 2), 15) / 12; // Wtf C#
            // TODO : LaserGFX (wtf is dat thing srsly ?)
            // TODO : set shot intersection line <=> set hitbox, line of width 2 (fuck !) between x,y and x2,y2
            sca += sca_d;

            yield return new WaitForFixedUpdate();
        }
    }
}
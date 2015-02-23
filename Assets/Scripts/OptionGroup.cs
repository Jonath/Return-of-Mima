using UnityEngine;
using System.Collections;

public class OptionGroup : MonoBehaviour {
    public float powerLevel;
    private bool active;

	void Update () {
        float power = Player.current.power;

        if (power > powerLevel && power < powerLevel + 1)
            active = true;
        else
            active = false;

        SetChildrenActivation(active);

        if (active && Player.current.Shoot)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<Fire>().Attack();
            }
        }
	}

    void SetChildrenActivation(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}

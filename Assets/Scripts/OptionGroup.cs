using UnityEngine;
using System.Collections;

public class OptionGroup : MonoBehaviour {
    public float powerLevel;
    private bool act;

	void Update () {
        float power = Player.current.power;

        if (power >= powerLevel && power < powerLevel + 1) {
            act = true;
        }
        else {
            act = false;
        }

        SetChildrenActivation(act);

        if (act && Player.current.Shoot)
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

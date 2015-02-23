using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerLives : MonoBehaviour {
    private List<SpriteRenderer> lifeBar;

    public Sprite[] lives;

    void Awake()
    {
        lifeBar = new List<SpriteRenderer>();
        foreach (Transform child in transform)
        {
            lifeBar.Add(child.gameObject.GetComponent<SpriteRenderer>());
        }
    }

    void Update()
    {
        int fullLives = Player.current.fullLives;
        int fractLives = Player.current.fractLives;

        for (int i = 0; i < fullLives; i++)
        {
            if (lifeBar[i] != null)
            {
                lifeBar[i].sprite = lives[5];
            }
        }

        if (fractLives > 0)
            lifeBar[fullLives].sprite = lives[fractLives];

        for (int i = fullLives + 1; i < lifeBar.Count ; i++)
        {
            lifeBar[i].sprite = lives[0];
        }
    }
}

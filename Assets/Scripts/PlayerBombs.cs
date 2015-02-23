using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBombs : MonoBehaviour {
    private List<SpriteRenderer> bombBar;

    public Sprite[] bombs;

    void Awake()
    {
        bombBar = new List<SpriteRenderer>();
        foreach (Transform child in transform)
        {
            bombBar.Add(child.gameObject.GetComponent<SpriteRenderer>());
        }
    }

    void Update()
    {
        int fullBombs = Player.current.fullBombs;
        int fractBombs = Player.current.fractBombs;

        for (int i = 0; i < fullBombs ; i++)
        {
            if (bombBar[i] != null)
            {
                bombBar[i].sprite = bombs[5];
            }
        }

        if (fractBombs > 0)
            bombBar[fullBombs].sprite = bombs[fractBombs];

        for (int i = fullBombs + 1; i < bombBar.Count; i++)
        {
            bombBar[i].sprite = bombs[0];
        }
    }
}

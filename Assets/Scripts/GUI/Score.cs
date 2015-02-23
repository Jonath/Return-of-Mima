using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    public static Score current;
    private int score = 0;

    public int ScoreValue {
        get { return score; }
        set { score = value; }
    }

    void Awake()
    {
        current = this;
    }
	
	// Display the score somewhere
	void Update () {
        gameObject.GetComponent<TextMesh>().text = "Score : " + score.ToString("00000000");
	}
}

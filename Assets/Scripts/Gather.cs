using UnityEngine;
using System.Collections;

public class Gather : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Item")
        {
            // Item handling here
            switch (obj.GetComponent<Item>().itemType) {
                case Item.ItemType.Point:
                    Debug.Log("Point item");

                    if(Score.current != null)
                        Score.current.ScoreValue += 500;
                    break;
                case Item.ItemType.Power:
                    Player.current.power = Mathf.Min(Player.current.power + 0.01f, 4.0f);
                    Debug.Log("Power item");
                    break;
                default:
                    break;
            } 
            Destroy(obj);
        }
    }
}

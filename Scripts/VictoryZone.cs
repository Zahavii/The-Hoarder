using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    // Start is called before the first frame update
    public Item grandTreasure;
    public GameObject victoryScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>().inventory.Has(grandTreasure))
            {
                //It worked!  You got the treasure!
                //Destroy(gameObject);
                Debug.Log("Big win");
                victoryScreen.SetActive(true);
            }
            else
            {
                //Not yet!
                Debug.Log("Big think...");
            }
        }
    }
}

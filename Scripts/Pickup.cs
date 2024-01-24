using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>().inventory.AddItem(Instantiate(item)))
            {
                //It worked!  You got the item!
                Destroy(gameObject);
            }
            else
            {
                //Didn't work!
                Debug.Log("Item not picked up");
            }
        }
    }
}

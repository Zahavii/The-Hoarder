using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    // Start is called before the first frame update
    public Transform exitT;
    public Door neighbor;
    public bool locked;
    public Item key;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 Kick()  //Player is entering us!  Return a position they can go to...
    {
        return exitT.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            user = collision.GetComponent<Player>();
            user.SetInteraction(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            user = collision.GetComponent<Player>();
            user.ResetInteraction();
        }
    }
    public override void activate()
    {
        if(locked)
        {
            if (Player.player.inventory.Has(key))
            {
                Player.player.inventory.Use(Player.player.inventory.Has(key));
                locked = false;
            }
        }
        if (!locked)
        {
            user.ResetInteraction();
            
            user.gameObject.transform.position = neighbor.Kick();
            if (user != null)
            {
                user = null;
            }

        }
    }
}

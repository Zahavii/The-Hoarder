using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeistCondition : Task
{
    // Start is called before the first frame update
    public Item i;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Check()
    {
        if (i != null)
        {
            if (Player.player.inventory.Has(i))
            {

                Debug.Log("Player currently has item id " + i.id + "!");
                done = true;
            }
            else
            {
                //Debug.Log("Player currently hasn't item id " + i.id);

                done = false;
            }

        }
        else
        {
            Debug.Log("No item even set for Heist Condition!");
        }
        
    }
}

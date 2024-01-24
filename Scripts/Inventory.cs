using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public List<InventorySlot> pockets = new List<InventorySlot>();
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        foreach(InventorySlot i in GetComponentsInChildren<InventorySlot>())
        {
            pockets.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Item i)
    {
        bool success = false;
        foreach(InventorySlot p in pockets)
        {
            if(p.storage == null)
            {
                success = true;
                p.storage = i;
                p.RefreshItemUI();
                return true;
            }
        }
        if(!success)
        {
            Debug.Log("Couldn't fit: " + i.name);
        }
        return false;
    }
    public Item Has(Item i)
    {
        foreach (InventorySlot p in pockets)
        {
            if (p.storage != null)
            {
                if (p.storage.id == i.id)
                {
                    Debug.Log("Player has: " + i.name);

                    return p.storage;
                }
            }

        }
        if (i != null)
        {
            //Debug.Log("Doesn't have: " + i.name);
        }
        else
        {
            Debug.Log("No item for has() actually does a thing?! wut.");

        }
        //Debug.Log("this is the worst inventory ending for Has().  its null.");
        return null;
    }
    public InventorySlot GetSlot(Item i)
    {
        foreach (InventorySlot p in pockets)
        {
            if (p.storage != null)
            {
                if (p.storage == i)
                {
                    Debug.Log("Player has: " + i.name + " in inventory pocket " + p.name);
                    return p;
                }
            }

        }
        if (i != null)
        {
            //Debug.Log("Doesn't have: " + i.name);
        }
        else
        {
            Debug.Log("No item for has function!");

        }
        Debug.Log("this is the worst inventory ending for GetSlot().  its null.");
        return null;
    }
    public bool Has(int i) //this override checks to see if you have something in a pocket at all!
    {
        if(pockets[i].storage!= null)
        {
            return true;
        }
        else
        {
            Debug.Log("No item at location "+i+"!");

        }
        return false;
    }

    public void Use(Item i)
    {
        InventorySlot slot = GetSlot(i);
        i.Use(player);
        if (i.durability <= 0)
        {
            Debug.Log("Item empty... destroy  is kill . . . no");
            slot.Empty();
            Player.player.Disarm();
            Destroy(i);
        }
        else
        {
            Debug.Log(i.durability + " durability left on item: " + i.name);
        }
        //clean my pockets...
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : Unit
{
    // Start is called before the first frame update
    public Inventory inventory;
    public static Player player;
    public GameObject crosshair;
    public Vector3 aim; //this is the force I'll launch things at...
    public bool armed;
    public Item inHand;

    

    void Start()
    {
        if (player == null)
        {
            player = this;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        PlayerInput();

    }

    void PlayerInput()
    {
        if (isAble())
        {
            float hx = Input.GetAxisRaw("Horizontal");
            float hy = Input.GetAxisRaw("Vertical");
            Move(hx, hy);


            Vector3 mousePos = Input.mousePosition;
            crosshair.transform.position = DungeonCamera.DC.mainCam.ScreenToWorldPoint(mousePos);
            if (Input.GetMouseButtonDown(1))
            {
                Fire();
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                if (nearbyInteraction != null)
                {
                    nearbyInteraction.activate();
                    ResetInteraction();
                }
            }
        }
        else
        {
            Move(0, 0);
        }
    }

    //Set an item for use.
    public void Arm(Item i)
    {
        //Item i = gameObject.GetComponent<Item>();

        //if i is a this/.... enable crosshair?
        if (isAble())
        {
            if (i.iT == Item.ItemType.Projectile)
            {
                crosshair.SetActive(true);
            }
            else
            {
                crosshair.SetActive(false);
            }
            inHand = i;
        }
    }
    //Use an item that has been armed.
    public void Fire()
    {
        if (isAble())
        {
            if (inHand != null)
            {
                if(inHand.iT != Item.ItemType.None)
                    inventory.Use(inHand);
            }
        }
    }
    //Unarm player.
    public void Disarm()
    {
        inHand = null;
        if (crosshair != null)
        {
            crosshair.SetActive(false);
        }
        //just in case...
        CharacterPortrait.me.Highlight(false);
    }

    
}

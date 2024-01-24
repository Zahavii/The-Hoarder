using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Item storage;
    public Image UIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("slot on-drop");
        if (Player.player != null)
        {
            if (eventData.pointerDrag != null)
            {
                //eventData.Pointer drag is the game object that was dragged onto us . . . . An Icon.
                GameObject g = eventData.pointerDrag;
                g.GetComponent<DragDrop>().hit = true; //tell icon not to reset...
                CharacterPortrait.me.Highlight(false);


                g.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                Item stor = storage;
                storage = g.GetComponent<DragDrop>().myPocket.storage;
                g.GetComponent<DragDrop>().myPocket.storage = stor;
                RefreshItemUI();
                g.GetComponent<DragDrop>().myPocket.RefreshItemUI();

            }
        }

    }
    public void RefreshItemUI()
    {
        if (storage != null)
        {
            UIcon.sprite = storage.Icon;
            UIcon.enabled = true;
            UIcon.color = storage.color;
        }
        else
        {
            UIcon.enabled = false;
            UIcon.sprite = null;
        }
    }

    public void Empty()
    {
        storage = null;
        RefreshItemUI();
    }
}

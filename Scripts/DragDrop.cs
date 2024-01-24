using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Start is called before the first frame update
    [SerializeField] private Canvas canvas;
    public RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public InventorySlot myPocket;
    private PointerEventData _lastPointerData;
    public Vector2 lastPosition;
    public bool hit = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        hit = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("on pointer down...");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Player.player == null)
        {
            CancelDrag();
        }
        else
        {
            Debug.Log("on end  drag ...");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            //Debug.Log(eventData.pointerDrag);
            if (hit == true)//were we dropped in a slot?
            {
                hit = false; //reset
            }
            else
            {
                CancelDrag();
            }
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Player.player == null)
        {
            CancelDrag();
        }
        else
        {
            if (eventData.pointerDrag.GetComponent<DragDrop>().myPocket.storage.iT == Item.ItemType.Consumable)
            {
                CharacterPortrait.me.Highlight(true);
            }
            //lastPointerData = eventData;
            Player.player.Arm(myPocket.storage);
            lastPosition = rectTransform.anchoredPosition;
            Debug.Log("on begin drag");
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("on draahg");
        if (Player.player == null)
        {
            CancelDrag();
        }
        else
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void CancelDrag()
    {
        //party's over.
        rectTransform.anchoredPosition = lastPosition;
        //CharacterPortrait.me.Highlight(false);
        Player.player.Disarm();

    }



}

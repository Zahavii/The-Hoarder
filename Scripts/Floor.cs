using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    //public List<Transform> cameraPositions = new List<Transform>();
    public List<Trap> traps = new List<Trap>();
    public List<Quest> quests = new List<Quest>();
    public SpriteRenderer sr;
    public float fadeOutAlphaValue = 0.3f; //Transparancy from 0 to 1, of room when you leave it!
    // Start is called before the first frame update
    private void Awake()
    {
        if(sr == null)
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, fadeOutAlphaValue);
        }
        foreach(Quest q in GetComponentsInChildren<Quest>())
        {
            if (!quests.Contains(q))
            {
                Debug.Log(q.gameObject.name + " quest added to floor " + name);
                quests.Add(q);
            }
            //q.myFloor = this;
        }
        foreach (Trap t in GetComponentsInChildren<Trap>())
        {
            if (!traps.Contains(t))
            {
                Debug.Log(t.gameObject.name + " enemy auto added to floor " + name);
                traps.Add(t);
            }
            //q.myFloor = this;
        }
        FreezeRoom(true);
    }
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
            FreezeRoom(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FreezeRoom(true);
        }
    }
    public void FreezeRoom(bool p)
    {
        //Debug.Log(p + " i do be fr, eeezing floor " + gameObject.name);
        //Utility.CleanList(traps);
        //Utility.CleanList(quests);


        
        if (p) //FREZZE IT
        {
            //Fade out?
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, fadeOutAlphaValue);
            foreach (Trap t in traps)
            {
                t.Switch(false);
                t.gameObject.SetActive(false);
                //Deactivate trap or activate it!
            }
            foreach(Quest q in quests)
            {
                q.gameObject.SetActive(false);
            }
        }
        else //UNFREEZE
        {
            //Fade in?
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
            foreach (Trap t in traps)
            {
                t.Switch(true);
                t.gameObject.SetActive(true);
                //Deactivate trap or activate it!
            }
            foreach (Quest q in quests)
            {
                q.gameObject.SetActive(true);
            }
        }
    }

}

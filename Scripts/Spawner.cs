using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Hazard
{
    // spawns hazards...
    public List<Hazard> things = new List<Hazard>();
    public List<Transform> aims = new List<Transform>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.player)
        {
            aims[0].position = Player.player.gameObject.transform.position;
        }
    }
    
    // Start is called before the first frame update

    public override void Happen()
    {
        for (int i = 0; i < things.Count; i++)
        {
            
            GameObject g = (things[i].gameObject);
            
            //g.transform.SetParent();  //De parent so the gameobject doesn't rely...
            if (i < aims.Count)
            {
                g.transform.position = gameObject.transform.position; //I mean, that works?
                g.GetComponent<Hazard>().Happen(gameObject.transform, aims[0]);
            }
            else
                Debug.Log("Not enough spawn locations for " + name);
        }
    }
}

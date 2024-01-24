using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : Reward
{
    public List<GameObject> things = new List<GameObject>();
    public List<Transform> locations = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Activate()
    {
        for(int i = 0; i<things.Count; i++)
        {
            GameObject g = Instantiate(things[i]);

            //g.transform.SetParent();  //De parent so the gameobject doesn't rely...
            if (i < locations.Count)
                g.transform.position = locations[i].position; //I mean, that works?
            else
                Debug.Log("Not enough spawn locations for " + name);
        }
    }
}

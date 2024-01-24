using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float cameraSize;
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
            //Debug.Log("Player has entered the room " + name);
            //Shift camera to this dungeon's transform...
            DungeonCamera.DC.MoveCam(transform.position);
            //DungeonCamera.DC.setCamSize(cameraSize);
        }
    }
}

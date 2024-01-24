using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public string info = "useless... press f.";
    public Player user;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void activate()
    {
        Debug.Log("no interaction for this set yet!!!");
    }
}

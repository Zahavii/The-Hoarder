using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Happen(Transform spawn, Transform aim)
    {
        Debug.Log("THING CANT HAPPEN NO THING   " + name);
    }
}

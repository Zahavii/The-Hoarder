using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public bool done;
    // Start is called before the first frame update

    public virtual void Check()
    {
        Debug.Log("There's no overriden Task for " + name + "!  done is false!");
        done = false;
    }
}

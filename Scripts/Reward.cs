using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{

    // Start is called before the first frame update
    public void Give()  //Give them a reward!  . . . If they can hold it?  Which could be anything!
    {
        //UI displaying what to give...
        //Conditions here??? ?
        {
            Debug.Log("You get something from " + name + ".");//  Uses left: " + rewardUses);
            Activate();
        }
        
        
    }

    protected virtual void Activate() //Actually does something
    {
        Debug.Log("No activation set from " + name +"!");
    }
}

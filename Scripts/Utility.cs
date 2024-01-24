using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    // Start is called before the first frame update
    //for (int i = ObjectsInSight - 1; i >=0; i--)
    // {
    //     if (ObjectsInSight[i] != null)
    //     {
    //         //Do stuff
    //     }
    //     else
    //     {
    //         ObjectsInSight[i] = ObjectsInSight[ObjectsInSight.Count - 1];
    //         ObjectsInSight.RemoveAt(ObjectsInSight.Count-1);
    //     }
    // }
    public static void CleanList<T>(List<T> objects)
    {
        Debug.Log("Cleaning... size: " + objects.Count);
        for(int i = objects.Count-1; i>=0;i--)
        {
            //Debug.Log("C?." + objects[i]);
            T tmp = objects[i];
            if (tmp != null)
            {
            }
            else
            {
                objects[i] = objects[objects.Count - 1];
                objects.RemoveAt(objects.Count-1);
                //objects.RemoveAt(i);
                //i--;
                Debug.Log("Clean.");
            }
        }

        objects.TrimExcess();
    }

}

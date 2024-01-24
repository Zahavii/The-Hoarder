using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Child this to a "Floor" in order for it to be recognized by one!
public class Quest : MonoBehaviour
{
    public List<Reward> rewards = new List<Reward>();
    public List<Task> tasks = new List<Task>();
    public bool allDone; //Are all tasks done?
    public float cooldown = 0.25f;
    public float waitTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime >= cooldown)
        {
            bool done = true;

            foreach (Task t in tasks)
            {
                t.Check();  //Tell Task to calculate whether it is done.
                if (!t.done)
                {
                    done = false;
                }
            }
            allDone = done;

            if (allDone)
            {
                //for(int i = 0; i< tasks.Count; i+=0)
                //{
                    
                //}
                //tasks.Clear();
                foreach (Reward r in rewards)
                {
                    r.Give();
                    //Destroy(r.gameObject, 0.2f);  //Can't have it anymore!
                    //Destroy(r);
                }
                //rewards.Clear();
                //If we belong to a floor...
                if(GetComponentInParent<Floor>() != null)
                {
                    GetComponentInParent<Floor>().quests.Remove(this);
                }
                Destroy(gameObject, 0.15f);
            }

            waitTime -= cooldown;
        }
        else
        {
            waitTime += Time.deltaTime;
        }
        //Check to see if my tasks are finished!
    }
}

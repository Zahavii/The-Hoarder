using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public List<Hazard> dangers = new List<Hazard>();
    public bool armed;
    public float cooldown = 0.0f;
    public float waitTime = 0.3f;
    public float duration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        armed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown != 0)
        {

            if (waitTime > cooldown)
            {
                Switch(!armed);
                if (armed)
                {
                    waitTime -= duration;
                }
                else
                {
                    waitTime -= cooldown;
                }

            }
            else
            {
                waitTime += Time.deltaTime;
            }
        }
    }
    //Deactivates all traps.
    public void Switch(bool p)
    {
        armed = p;
        foreach(Hazard d in dangers)
        {
            d.gameObject.SetActive(p);
            if(p)
            {
                d.Happen();
            }
            //d.//Deactivate trap or activate it!
        }
        //gameObject.SetActive(p);
    }


}

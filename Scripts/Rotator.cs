using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool turns;
    public float objective;
    public float speed;
    public float cooldown;
    public float waitTime;
    public List<float> wayPoints = new List<float>();
    public int marker;
    public bool counterClockwise;
    public bool smoothMoves;
    // Start is called before the first frame update
    void Awake()
    {
        if(rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        else 
        {
            Debug.Log(name + " already has a rigidbody!");
        }
        if (wayPoints.Count == 0)
        {
            Debug.LogWarning("NO WAYPOINT SET");
        }
        else
        {
            objective = wayPoints[marker];
            //waitTime = cooldown;
            //cooldown = coolDowns[marker];
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.angularVelocity = 0;
        if (waitTime >= cooldown)
        {
            if (smoothMoves) //Lerp!!!
            {
                float cool = Mathf.Lerp(Mathf.Abs(transform.rotation.eulerAngles.z), Mathf.Abs(wayPoints[marker]), Time.deltaTime*3f);
                cool -= transform.rotation.eulerAngles.z;
                rb.angularVelocity = cool * speed;// * Mathf.Abs(speed);
                if (!counterClockwise)
                {
                    rb.angularVelocity = -rb.angularVelocity;
                }
            }
            else //Regular movement...
            {
                rb.angularVelocity = speed;
                //Debug.Log(transform.rotation.eulerAngles.z);
            }
            //Ok did i get there yet?
            if (counterClockwise && transform.rotation.eulerAngles.z >= wayPoints[marker]-0.1f)
            {
                Progress();
            }
            else if (!counterClockwise && transform.rotation.eulerAngles.z <= wayPoints[marker] +0.1f)
            {
                Progress();
            }
        }
        else
        {
            waitTime += Time.deltaTime;
        }
    }
    void Progress()
    {
        //Debug.Log("rotated it!");
        waitTime -= cooldown;
        marker = (marker + 1) % wayPoints.Count;

        if(transform.rotation.eulerAngles.z >= wayPoints[marker])
        {
            counterClockwise = false;
            speed = -Mathf.Abs(speed); //If we're rotating clockwise, Negative!
        }
        else
        {
            counterClockwise = true;
            speed = Mathf.Abs(speed);  //If we're rotating counter clockwise, positive!
            //speed = -speed;
        }
    }
}

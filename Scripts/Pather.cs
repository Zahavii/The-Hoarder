using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pather : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> wayPoints = new List<Transform>();
    public List<float> coolDowns = new List<float>();
    public Transform objective;
    Vector3 target;//This is what we want to move towards!
    public int marker; //Which one are we currently on?
    public bool smoothMoves; //optional!
    public float speed;
    public float lerpSpeed = 0.01f; //optional!
    public float cooldown;
    public float waitTime;
    public Rigidbody2D rb;
    void Start()
    {
        if(wayPoints.Count == 0)
        {
            Debug.LogWarning("NO WAYPOINT SET");
        }
        else
        {
            objective = wayPoints[marker];
            //waitTime = cooldown;
            //cooldown = coolDowns[marker];
        }
        if (rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.Log(name + " already has a rigidbody!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = wayPoints[marker].position;  //I wanna go here!
        rb.velocity = Vector2.zero;
        if (waitTime >= cooldown)
        {
            
            if(smoothMoves)
            {
                transform.position = // >:)
                    Vector3.Lerp(transform.position, target, Time.deltaTime * lerpSpeed);
            }
            else
            {
                //Static movement handeled by Rigidbody!
                //transform.position = // >:)
                    //Vector3.MoveTowards(transform.position, target, speed);
                rb.velocity = (Vector3.MoveTowards(transform.position, target, 100) - transform.position).normalized *speed;
                while(rb.velocity.magnitude > (transform.position - target).magnitude + speed/2)
                {
                    rb.velocity *= 0.8f;
                }
            }
            if ((transform.position - target).magnitude <= 0.1f)
            {
                waitTime -= cooldown;
                marker = (marker + 1) % wayPoints.Count;
                //cooldown = coolDowns[marker];
            }

        }
        else
        {
            waitTime += Time.deltaTime;
        }
        
    }
}

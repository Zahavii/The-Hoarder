using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Hazard
{
    // Start is called before the first frame update
    public Vector3 launch;
    public float startMultiplier=4;
    public Rigidbody2D rb;
    //public List<Infliction> inflictions = new List<Infliction>();
    public float damage;
    public float projectileSpeed;
    private void Awake()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = Vector3.forward;
        rb.velocity = launch * projectileSpeed;

    }
    public override void Happen(Transform spawn, Transform aim)
    {
        
        //GameObject g = Instantiate(gameObject);
        //g.transform.position = spawn.position;
        //aim?
        Vector3 dir = (aim.localPosition).normalized;
        //g.transform.position += dir * 4;
        //g.transform.LookAt(aim);
        
        //Debug.Log("thing happen!@@  " + sir);
        launch = dir;

        GameObject g = Instantiate(gameObject);
        g.transform.position = spawn.position;
        g.transform.position += dir * startMultiplier;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("BAP!");
        Vitals vital = collision.gameObject.GetComponent<Vitals>();
        if (vital)
        {

            Unit u = collision.gameObject.GetComponent<Unit>();
            //u.TakeDamage(dam);
            if (u)
            {
                if (u.hurt())  //did we actually hurt him or is he currently invincible
                {
                    foreach (Infliction i in inflictions)
                    {
                        i.Proc(u);
                    }
                }
            }
            else
            //foreach (Infliction i in inflictions)
            {
                vital.Damage(damage);
                //play sfx
                Destroy(gameObject);
                    //i.Proc(u);
            }
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            
        }
    }

 

}

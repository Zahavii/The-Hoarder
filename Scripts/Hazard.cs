using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //public float dam;
    public List<Infliction> inflictions = new List<Infliction>();
    public Vitals vitals;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<Vitals>())
        {
            vitals = GetComponent<Vitals>();
            vitals.alv = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDead();
    }
    public void CheckDead()
    {
        if (vitals != null)
        {
            if (!vitals.alv)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        if (GetComponentInParent<Floor>() != null)
        {
            GetComponentInParent<Floor>().traps.Remove(GetComponentInParent<Trap>());
        }
        Destroy(gameObject, 0.15f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("BAP!");
        
        if(collision.tag == "Player" || collision.tag == "Enemy")
        {
            Unit u = collision.gameObject.GetComponent<Unit>();
            if (u.hurt())  //did we actually hurt him  or is he currently invincible
            {
                Debug.Log(u.gameObject.name + " got pwned by: >?");
                foreach (Infliction i in inflictions)
                {
                    i.Proc(u);
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("Bumnp.");
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Unit u = collision.gameObject.GetComponent<Unit>();
            //u.TakeDamage(dam);
            if (u.hurt())  //did we actually hurt him or is he currently invincible
            {
                Debug.Log(u.gameObject.name + " got pwned by: >?");
                foreach (Infliction i in inflictions)
                {
                    i.Proc(u);
                }
            }
        }

    }

    public virtual void Happen(Transform spawn, Transform aim)
    {
        //Debug.Log("base haz aim?  cring");
    }
    public virtual void Happen()
    {
        //Debug.Log("basSSSSe haz?  cring");
    }

}

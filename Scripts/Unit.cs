using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// The Unit class contains many base functions of the player and enemies in game, but does not contain their AI or INPUT, nor properties neither share.
///
/// </summary>
public class Unit : MonoBehaviour
{
    //STATS - - -
    public float spd = 20.0f;
    public float maxSpd = 40.0f;
    public float iFrames = 0.0f;
    public List<Infliction> curses = new List<Infliction>();
    public Vitals vitals;

    //UI
    public Slider hpBar;
    public GameObject infoPanel;
    public TextMeshProUGUI infoText;
    public Interactable nearbyInteraction;

    //PHYSICS
    public Rigidbody2D rb;
    // Start is called before the first frame update

    public void Awake()
    {
        if(vitals == null)
        {
            vitals = GetComponent<Vitals>();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        checkDead();
        //UpdateUI();
        if(iFrames > 0.0f)
            iFrames -= Time.deltaTime;

        foreach(Infliction i in curses)
        {
            i.tick();
        }
        for(int i = 0; i< curses.Count; i++)
        {
            if(curses[i].tock())
            {
                i--;
            }

        }
    }

    //Management - - - Input, timers, updates, management of other game objects. . .
    void UpdateUI()
    {
        //hpBar.maxValue = vitals.mhp;
        //hpBar.value = vitals.hp;
    }

    //Base Functions - - - Simple functions that allow basic game mechanics like movement.
    protected void Move(float ix, float iy)
    {
        rb.velocity = new Vector2(ix * spd, iy * spd);

        //Set walking animations??
    }
    public void SetInteraction(Interactable inter)
    {
        nearbyInteraction = inter;
        DisplayInteraction(inter);
    }
    public void DisplayInteraction(Interactable inter)
    {
        infoPanel.SetActive(true);
        infoText.text = inter.info;
    }
    public void ResetInteraction()
    {
        if (nearbyInteraction != null)
        {
            
            infoPanel.SetActive(false);
            nearbyInteraction = null;
        }
    }
    public void TakeDamage(float d)
    {
        vitals.Damage(d);

        //Hurt animation plays
        //Sound plays
    }
    public void HealDamage(float d)
    {
        vitals.Heal(d);


        //Heal text??
    }

    public bool hurt()
    {
        if (iFrames <= 0.0f)
        {
            iFrames = 1.0f;
            return true;
        }
        return false;
    }
    public void Bump(Vector2 force)
    {
        //Add impulsive force???  Lock player from doing stuff?  Stun?
    }
    public bool isAlive()
    {
        return vitals.alv;
    }
    ///Is the player locked from doing things?
    public bool isAble()
    {
        if(isAlive())
        {
            return true;
            //add more conditions that will stop from doing things.
        }
        return false;
    }
    public void checkDead()
    {
        if(!vitals.alv)
        {
            Die();
        }
    }
    public void Die()
    {
        
        {
            Destroy(gameObject, vitals.deathTimer);
        }
    }
   

}

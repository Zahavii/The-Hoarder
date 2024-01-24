using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vitals : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp, mhp = 1;
    public float armor = 0.0f;
    public Slider hpBar;
    public Slider armorBar;
    public float deathTimer = 0.3f;
    public bool alv = true;
    //public List<GameObject> hitList;
    void Start()
    {
        alv = true;
    }

    // Update is called once per frame
    void Update()
    {
        VibeCheck();
        if (hpBar)
        {
            hpBar.maxValue = mhp;
            hpBar.value = hp;
        }
        if (armorBar)
        {
            armorBar.maxValue = mhp;
            armorBar.value = armor;
        }
    }
    public void Heal(float d)
    {
        hp += d;
        hp = Mathf.Clamp(hp, 0.0f, mhp);
    }
    public void Damage(float d)
    {
        d -= armor;
        if (d <= 0)
        {
            d = 0;
            
        }
        if (d > 0)  //Break the armor!
            armor = 0;

        hp -= d;
    }
    public void VibeCheck()
    {
        //Play SFX
        //Animations??
        if (hp > 0)
        {
            return;
        }
        if (hp <= 0)
        {
            alv = false;
            if (gameObject.GetComponent<Player>())
            {
                gameObject.GetComponent<Player>().Disarm();
            }
            //if (hitList.Count >= 1)
            //{
            //    foreach (GameObject g in hitList)
            //    {
            //        Destroy(g, deathTimer);
            //    }
            //}

        }
        
    }
}

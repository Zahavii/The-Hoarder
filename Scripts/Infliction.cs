using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Infliction
{
    // Start is called before the first frame update
    public float power; //This represents trap effectivness, however it is!
    public Infi type = Infi.None;
    public float duration;
    public float waitTime;
    public Unit target;
    
    public Infliction()
    {

    }
    public Infliction(Infliction i)
    {
        power = i.power;
        type = i.type;
        duration = i.duration;
        waitTime = i.waitTime;
        target = i.target;
    }
    //As every infliction is doing
    public void tick()
    {
        //Updates this object via another.

        waitTime += Time.deltaTime;
        if(waitTime >= duration)
        {
            Cure(target);
            

        }
    }

    //After every infliction has done stuff

    public bool tock()
    {
        if (waitTime >= duration)
        {
            target.curses.Remove(this);
            return true;
        }
        return false;
    }

    public enum Infi
    {
        Damage,
        Heal,
        Slow,
        Knockback,
        Armor,
        None
    };
    public virtual void Proc(Unit u)
    {
        target = u;
        if(duration > 0.0f) //If this is temporary...
        {
            Infliction i = new Infliction(this);
            target.curses.Add(i);
        }
        if (type == Infi.None)
        {
            Debug.Log("Idk this infliction don't do something...");
        }
        else if (type == Infi.Damage)
        {
            Debug.Log("Damage infliction??? against " + target.gameObject.name);
            target.TakeDamage(power);
        }
        else if (type == Infi.Heal)
        {
            Debug.Log("Heal infliction??? against " + target.gameObject.name);
            target.HealDamage(power);
        }
        else if (type == Infi.Slow)
        {
            Debug.Log("Slow infliction??? against " + target.gameObject.name);
            target.spd -= power;
            if (target.spd < 0)
            {
                target.spd = 0;
            }
        }
        else if(type == Infi.Armor)
        {
            target.vitals.armor += power;
        }
        else if (type == Infi.Knockback)
        {
            Debug.Log("Slow infliction??? against " + target.gameObject.name);
            //Rework momentum...

        }
        else
        {
            Debug.Log("How did you even manage to mess your infliction up so bad there's no Infi type???");
        }

    }

    public virtual void Cure(Unit u)
    {
        if (type == Infi.None)
        {
            Debug.Log("Idk this infliction don't cure something...");
        }
        else if (type == Infi.Damage)
        {
            Debug.Log("Damage infliction??? reversing to heal for: " + target.gameObject.name);
            target.HealDamage(power);
        }
        else if (type == Infi.Heal)
        {
            Debug.Log("Heal infliction??? reversing to damage for:  " + target.gameObject.name);
            target.TakeDamage(power);
        }
        else if (type == Infi.Slow)
        {
            Debug.Log("Slow infliction??? reversing to speed for:  " + target.gameObject.name);
            target.spd += power;
            if (target.spd < target.maxSpd)
            {
                target.spd = target.maxSpd;
            }
        }
        else if (type == Infi.Knockback)
        {
            Debug.Log("Slow infliction??? against " + target.gameObject.name);
            //Rework momentum...

        }
        else if (type == Infi.Armor)
        {
            target.vitals.armor -= power;
        }
        else
        {
            Debug.Log("How did you even manage to mess your infliction up so bad there's no Infi type???");
        }



    }
}

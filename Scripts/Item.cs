using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{

    public Sprite Icon;
    public int durability;
    public bool RARE;
    public int id;
    public ItemType iT;
    public List<Hazard> things = new List<Hazard>();
    public float power;
    public List<Infliction> inflictions;
    public Color color = new Color(255,255,255);
    public bool permanent = false;
    public enum ItemType
    {
        Projectile,
        Infliction,
        Equipment,
        Consumable,
        None
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(Player p)
    {
        Debug.Log("Item used:  " + name);
        if(!permanent)
            durability--;

        SideEffects(p);

        foreach(Hazard t in things)
        {
            t.Happen(p.gameObject.transform, p.crosshair.transform);
        }

    }

    public void SideEffects(Unit u)
    {
        foreach(Infliction i in inflictions)
        {
            i.Proc(u);
        }

    }

    
}

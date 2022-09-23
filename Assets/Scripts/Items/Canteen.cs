using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canteen : Item
{
    bool refilled = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override bool Use()
    {
        gameObject.transform.parent = Camera.main.transform;
        //gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(0, -0.08f, 0.66f);
        gameObject.transform.localEulerAngles = new Vector3(0, -90, 0);
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, 10, targetMask, QueryTriggerInteraction.Collide);
        refilled = false;
        if (rangeChecks.Length != 0)
        {
            for (int i = 0; i < rangeChecks.Length; i++)
            {
                if(rangeChecks[i].tag == "WaterSource")
                {
                    
                    refilled = true;
                }
            }
        }
            if (!base.Use() && refilled == false)
        {
            return false;
        }
        GM.player.WaterSlider.value += 200;
        if(refilled)
        {
            uses = maxUses;
        }
        return true;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}

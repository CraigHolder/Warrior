using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class Item : PersistentMonoBehaviour
{
    public int ID = 0;
    public int value = 0;

    public bool weapon = false;
    public bool gun = false;
    public bool twoHanded = false;
    public bool consumable = false;

    public float charge = 0;
    [SerializeField]
    protected float chargeTimer = 0;

    public float useDelay = 0;
    protected float delayTimer = 0;

    public bool rechargeable = false;
    public float rechargeTime = 1f;
    public float rechargeSpeed = 1;
    float recharge;
    public int maxUses = 1;
    public int uses;

    public float lifeTime = 0.5f;
    public float life;

    public string itemName = "Item";
    public string description = "This does something \n";
    public bool equiped = false;
    public int slot = -3;

    public GameObject prefab;
    public float noiseRange;
    public float timer = 0;

    public int audioIndex = -1;
    public float volume = 1f;

    public LayerMask targetMask;

    protected GameManager GM;

    // Start is called before the first frame update
    public Item()
    {
        life = lifeTime;
        delayTimer = useDelay;
        recharge = rechargeTime;
        uses = maxUses;
        chargeTimer = charge;
    }

    protected virtual void Start()
    {
        if (gun)
        {
            gameObject.SetActive(true);
        }

        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
        
        if(recharge <= 0 && uses < maxUses && rechargeable)
        {
            uses++;
            recharge = rechargeTime;
        }
        else
        {
            recharge -= Time.deltaTime;
        }
        
        if (life <= 0)
        {
            gameObject.SetActive(false);
            life = lifeTime;

        }
        else
        {
            life -= Time.deltaTime;
        }

        delayTimer -= Time.deltaTime;
        if (equiped)
        {
            Passive();
        }
        Special();
    }

    public virtual bool Use()
    {
        if (uses <= 0 || delayTimer > 0)
        {
            //if(recharge)
            
            return false;
        }
        delayTimer = useDelay;
        uses--;
        Debug.Log(itemName + " used");
        life = lifeTime;
        return true;
    }
    public virtual void AltUse()
    {
        Debug.Log(itemName + " alt-used");
        life = lifeTime;
    }
    public virtual void Passive()
    {
        Debug.Log(itemName + " passive");
    }
    public virtual void Special()
    {
        Debug.Log(itemName + " special");
    }

    public virtual void Hold()
    {
        Debug.Log(itemName + " holding");
    }

    public virtual void Hold(Transform t)
    {
        Debug.Log(itemName + " holding");
    }
    public virtual void ResetCharge()
    {
        Debug.Log(itemName + " ResetCharge");
        chargeTimer = charge;
    }
    public virtual void UpdateCharge()
    {
        Debug.Log(itemName + " UpdateCharge");
        chargeTimer -= Time.deltaTime;
    }
}

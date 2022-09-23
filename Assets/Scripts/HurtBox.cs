using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public Enemy parent;
    public Player playerParent;
    public Organ organ;
    public List<GameObject> hitOBJS;

    public enum Organ
    {
        Head,
        Neck,
        Heart,
        Stomach,
        Chest,
        LegR,
        UpLegR,
        LegL,
        UpLegL,
        ArmR,
        UpArmR,
        ArmL,
        UpArmL,
        Hand
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && !hitOBJS.Contains(other.gameObject))
        {
            if (other.gameObject.GetComponent<Bullet>())
            {
                Bullet b = other.gameObject.GetComponent<Bullet>();
                if (b.noDamage)
                {
                    return;
                }

                if (parent)
                {
                    if (parent.currState != Enemy.State.Dead && parent.currState != Enemy.State.Asleep)
                    {
                        parent.Suspicion = parent.Reaction;
                        parent.Path(parent.transform.position + (transform.up * -2));
                        Debug.Log("turn");
                    }
                }


                this.Pierce(b.strength);
                hitOBJS.Add(other.gameObject);
                b.strength--;
                if (b.strength > 0 && !b.stick)
                {
                    GameObject a = Instantiate<GameObject>(Resources.Load<GameObject>("9mm Shrapnel"), transform.position, Quaternion.identity);
                    a.GetComponent<Rigidbody>().velocity = b.gameObject.GetComponent<Rigidbody>().velocity;
                    this.hitOBJS.Add(a);

                }
                else if (b.stick)
                {
                    b.transform.parent = transform;
                    b.GetComponent<Rigidbody>().isKinematic = true;
                    b.hit = true;
                }
                else
                {
                    Destroy(b.gameObject);
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && !hitOBJS.Contains(other.gameObject))
        {
            if (other.gameObject.GetComponent<Bullet>())
            {
                Bullet b = other.gameObject.GetComponent<Bullet>();
                if (b.noDamage)
                {
                    return;
                }

                if (parent)
                {
                    if (parent.currState != Enemy.State.Dead && parent.currState != Enemy.State.Asleep)
                    {
                        parent.Suspicion = parent.Reaction;
                        parent.Path(parent.transform.position + (transform.up * -2));
                        Debug.Log("turn");
                    }
                }

                this.Pierce(b.strength);
                hitOBJS.Add(other.gameObject);
                b.strength--;
                if (b.strength > 0 && !b.stick)
                {
                    GameObject a = Instantiate<GameObject>(Resources.Load<GameObject>("9mm Shrapnel"), transform.position, Quaternion.identity);
                    a.GetComponent<Rigidbody>().velocity = b.gameObject.GetComponent<Rigidbody>().velocity;
                    this.hitOBJS.Add(a);

                }
                else if (b.stick)
                {
                    b.GetComponent<Rigidbody>().isKinematic = true;
                    b.transform.localPosition -= b.transform.up * 0.8f;
                    b.transform.parent = transform;
                    b.hit = true;
                }
                else
                {
                    Destroy(b.gameObject);
                }
            }
        }
    }

    public void Slash(int strength)
    {
        if (parent)
        {
            switch (organ)
            {
                case Organ.Head:
                    if (parent.HeadArmor <= strength)
                    {
                        parent.currState = Enemy.State.Dead;
                        Debug.Log(parent.name + " dead HeadHit");
                    }
                    parent.Pain += strength * 80;
                    break;
                case Organ.Chest:
                    if (parent.ChestArmor <= strength)
                    {
                        parent.currState = Enemy.State.Dead;
                        Debug.Log(parent.name + " dead ChestHit");
                    }
                    parent.Pain += strength * 60;
                    break;
                case Organ.Stomach:
                    if (parent.ChestArmor <= strength)
                    {
                        parent.currState = Enemy.State.Dead;
                        Debug.Log(parent.name + " dead StomachHit");
                    }
                    parent.Pain += strength * 60;
                    break;
                case Organ.Neck:

                    parent.currState = Enemy.State.Dead;
                    Debug.Log(parent.name + " dead NeckHit");

                    break;
                case Organ.LegL:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " Hurt LeftLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.LegR:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " hurt RightLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.UpLegL:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " hurt UpLeftLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }

                    break;
                case Organ.UpLegR:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " hurt UpRightLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.ArmL:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        Debug.Log(parent.name + " hurt LeftArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.ArmR:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.disarmed = true;
                        Debug.Log(parent.name + " hurt RightArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.UpArmL:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        Debug.Log(parent.name + " hurt UpLeftArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.UpArmR:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.disarmed = true;
                        Debug.Log(parent.name + " hurt UpRightArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
            }
        }
        else
        {
            switch (organ)
            {
                case Organ.Head:
                    if (playerParent.HeadArmor <= strength)
                    {
                        playerParent.currState = Player.State.Dead;
                        Debug.Log(playerParent.name + " dead HeadHit");
                    }
                    playerParent.Pain += strength * 80;
                    break;
                case Organ.Chest:
                    if (playerParent.ChestArmor <= strength)
                    {
                        playerParent.currState = Player.State.Dead;
                        Debug.Log(playerParent.name + " dead ChestHit");
                    }
                    playerParent.Pain += strength * 60;
                    break;
                case Organ.Stomach:
                    if (playerParent.ChestArmor <= strength)
                    {
                        playerParent.currState = Player.State.Dead;
                        Debug.Log(playerParent.name + " dead StomachHit");
                    }
                    playerParent.Pain += strength * 60;
                    break;
                case Organ.Neck:

                    playerParent.currState = Player.State.Dead;
                    Debug.Log(playerParent.name + " dead NeckHit");

                    break;
                case Organ.LegL:
                    if (playerParent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " Hurt LeftLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.LegR:
                    if (playerParent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " hurt RightLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpLegL:
                    if (playerParent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " hurt UpLeftLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpLegR:
                    if (parent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " hurt UpRightLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.ArmL:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        Debug.Log(playerParent.name + " hurt LeftArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.ArmR:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.disarmed = true;
                        Debug.Log(playerParent.name + " hurt RightArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpArmL:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        Debug.Log(playerParent.name + " hurt UpLeftArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpArmR:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.disarmed = true;
                        Debug.Log(playerParent.name + " hurt UpRightArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
            }
        }
    }
    public void Pierce(int strength)
    {
        if (parent)
        {
            switch (organ)
            {
                case Organ.Head:
                    if (parent.HeadArmor <= strength)
                    {
                        parent.currState = Enemy.State.Dead;
                        Debug.Log(parent.name + " dead HeadHit");
                    }
                    parent.Pain += strength * 80;
                    break;
                case Organ.Chest:
                    if (parent.ChestArmor <= strength)
                    {
                        parent.currState = Enemy.State.Dead;
                        Debug.Log(parent.name + " dead ChestHit");
                    }
                    parent.Pain += strength * 60;
                    break;
                case Organ.Stomach:
                    if (parent.ChestArmor <= strength)
                    {
                        parent.currState = Enemy.State.Dead;
                        Debug.Log(parent.name + " dead StomachHit");
                    }
                    parent.Pain += strength * 60;
                    break;
                case Organ.Neck:

                    parent.currState = Enemy.State.Dead;
                    Debug.Log(parent.name + " dead NeckHit");

                    break;
                case Organ.LegL:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " Hurt LeftLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.LegR:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " hurt RightLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.UpLegL:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " hurt UpLeftLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    
                    break;
                case Organ.UpLegR:
                    if (parent.LegArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.speed /= 2;
                        Debug.Log(parent.name + " hurt UpRightLegHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.ArmL:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        Debug.Log(parent.name + " hurt LeftArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.ArmR:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.disarmed = true;
                        Debug.Log(parent.name + " hurt RightArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.UpArmL:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        Debug.Log(parent.name + " hurt UpLeftArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
                case Organ.UpArmR:
                    if (parent.ArmArmor <= strength)
                    {
                        parent.Pain += strength * 50;
                        parent.disarmed = true;
                        Debug.Log(parent.name + " hurt UpRightArmHit");
                    }
                    else
                    {
                        parent.Pain += strength * 50;
                    }
                    break;
            }
        }
        else
        {
            switch (organ)
            {
                case Organ.Head:
                    if (playerParent.HeadArmor <= strength)
                    {
                        playerParent.currState = Player.State.Dead;
                        Debug.Log(playerParent.name + " dead HeadHit");
                    }
                    playerParent.Pain += strength * 80;
                    break;
                case Organ.Chest:
                    if (playerParent.ChestArmor <= strength)
                    {
                        playerParent.currState = Player.State.Dead;
                        Debug.Log(playerParent.name + " dead ChestHit");
                    }
                    playerParent.Pain += strength * 60;
                    break;
                case Organ.Stomach:
                    if (playerParent.ChestArmor <= strength)
                    {
                        playerParent.currState = Player.State.Dead;
                        Debug.Log(playerParent.name + " dead StomachHit");
                    }
                    playerParent.Pain += strength * 60;
                    break;
                case Organ.Neck:

                    playerParent.currState = Player.State.Dead;
                    Debug.Log(playerParent.name + " dead NeckHit");

                    break;
                case Organ.LegL:
                    if (playerParent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " Hurt LeftLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.LegR:
                    if (playerParent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " hurt RightLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpLegL:
                    if (playerParent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " hurt UpLeftLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpLegR:
                    if (parent.LegArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.currSpeed /= 2;
                        Debug.Log(playerParent.name + " hurt UpRightLegHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.ArmL:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        Debug.Log(playerParent.name + " hurt LeftArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.ArmR:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.disarmed = true;
                        Debug.Log(playerParent.name + " hurt RightArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpArmL:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        Debug.Log(playerParent.name + " hurt UpLeftArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
                case Organ.UpArmR:
                    if (playerParent.ArmArmor <= strength)
                    {
                        playerParent.Pain += strength * 50;
                        playerParent.disarmed = true;
                        Debug.Log(playerParent.name + " hurt UpRightArmHit");
                    }
                    playerParent.Pain += strength * 50;
                    break;
            }
        }

    }
}

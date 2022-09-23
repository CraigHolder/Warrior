using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 0.5f;
    public float life;
    public int strength = 1;
    public bool noDamage = false;
    public Vector3 prevVelocity;
    public float forceCutoff = 0.25f;
    public bool hit = false;
    public bool stick = false;
    public Vector3 lastPos;
    public LayerMask Mask;

    void Start()
    {
        life = lifeTime;
        lastPos = transform.position;
        //strength = 2;
    }

    private void Update()
    {
        //Extra tunneling collision check
        tunnelCheck();
        lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        

        
        life -= Time.deltaTime;
        if(stick && hit)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if(life > forceCutoff && hit != true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = prevVelocity;
        }
        else if (life <= 0)
        {
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 5)
        {
            noDamage = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 0)
        {
            tunnelCheck();
            hit = true;
        }
    }

    public void tunnelCheck()
    {
        if(hit)
        {
            return;
        }
        Vector3 directionToTarget = (lastPos - transform.position).normalized;

        float distanceToTarget = Vector3.Distance(transform.position, new Vector3(lastPos.x, lastPos.y, lastPos.z));
        RaycastHit rayHit;
        Debug.DrawRay(transform.position, directionToTarget * (distanceToTarget), Color.green, 0.1f);
        if (Physics.Raycast(transform.position, directionToTarget, out rayHit, distanceToTarget, Mask, QueryTriggerInteraction.Collide))
        {
            Debug.Log("Tunnel Caught");
            HurtBox h = rayHit.collider.gameObject.GetComponent<HurtBox>();
            if (noDamage)
            {
                return;
            }

            

            h.Pierce(strength);
            h.hitOBJS.Add(gameObject);
            strength--;
            if (h.parent)
            {
                if (h.parent.currState != Enemy.State.Dead && h.parent.currState != Enemy.State.Asleep)
                {
                    h.parent.Suspicion = h.parent.Reaction;
                    h.parent.Path(h.parent.transform.position + (transform.up * -2));
                    Debug.Log("turn");
                }
                //Vector3 directionToDamage = (lastPos - h.parent.transform.position).normalized;
                
            }

            if (strength > 0 && !stick)
            {
                GameObject a = Instantiate<GameObject>(Resources.Load<GameObject>("9mm Shrapnel"), transform.position, Quaternion.identity);
                a.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
                h.hitOBJS.Add(a);

            }
            else if (stick)
            {
                transform.parent = h.transform;
                GetComponent<Rigidbody>().isKinematic = true;
                hit = true;
            }
            else
            {
                Destroy(gameObject);
            }

            
        }
    }

}

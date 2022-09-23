using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Item
{
    public Transform bulletRot;
    Vector3 pos;
    bool holding = false;
    public Bow() : base()
    {
        
    }
    protected override void Start()
    {
        base.Start();
        pos = bulletRot.localPosition;
    }
    // Start is called before the first frame update
    public override void Update()
    {
        base.Update();
    }

    public override bool Use()
    {
        if (!base.Use())
        {
            return false;
        }
        Hold();
        if(chargeTimer <= 0)
        {
            bulletRot.gameObject.SetActive(false);
            GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Arrow"), new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z) + (transform.right * 0.8f), bulletRot.rotation);
            //Physics.IgnoreCollision(go.GetComponent<Collider>(), GetComponent<Collider>());
            go.GetComponent<Rigidbody>().velocity = this.transform.right * 40;
            go.GetComponent<Bullet>().prevVelocity = this.transform.right * 40;
        }
        else
        {
            uses++;
        }

        return true;
    }

    public override void Hold()
    {
        base.Hold();
        gameObject.transform.parent = Camera.main.transform;
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(0.06f, -0.08f, 0.66f);
        gameObject.transform.localEulerAngles = new Vector3(-25, -90, 0);
        if(!holding)
        {
            holding = true;
            StartCoroutine(Draw());
        }
        
    }
    public override void Hold(Transform t)
    {
        base.Hold();
        gameObject.transform.parent = t;
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(0.27f, 1.36f, 0.54f);
        if (t.GetComponent<Enemy>().looking)
        {
            gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Target").transform);
            gameObject.transform.Rotate(0, -90, 0);
        }
    }

    public override void ResetCharge()
    {
        base.ResetCharge();
        StopAllCoroutines();
        bulletRot.position = pos;
        bulletRot.gameObject.SetActive(false);
        holding = false;
        
    }

    private IEnumerator Draw()
    {
        //gameObject.transform.localPosition = new Vector3(0.64f, -0.2f, 1);
        //gameObject.transform.localEulerAngles = new Vector3(-56, 145, 81);
        bulletRot.localPosition = pos;
        bulletRot.gameObject.SetActive(true);
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        //Hold();
        while (true)
        {
            yield return wait;
            life = 1;
            //transform.Rotate(0, -100 * Time.deltaTime, -200 * Time.deltaTime);
            //bulletRot.Translate(-bulletRot.right * 0.01f);
            bulletRot.position += -bulletRot.up * 10f * Time.deltaTime;
            if (chargeTimer <= 0)
            {
                break;
            }
            //if (timer >= 10)
            //{
            //    StopCoroutine(Draw());
            //    life = 0;
            //}
            
        }
        

    }

}

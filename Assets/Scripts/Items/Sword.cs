using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    public float swingTime = 5f;
    public Vector3 ROTs = Vector3.zero;
    public Vector3 MOVs = Vector3.zero;
    public Vector3 POS = Vector3.zero;
    public Vector3 ROT = Vector3.zero;
    bool swinging = false;
    // Start is called before the first frame update
    public Sword() : base()
    {
        //prefab = Resources.Load<GameObject>("Sword");
        weapon = true;
        rechargeable = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if(swinging)
        {
            transform.Rotate(ROTs.x * Time.deltaTime, ROTs.y * Time.deltaTime, ROTs.z * Time.deltaTime);
            transform.Translate(MOVs.x * Time.deltaTime, MOVs.y * Time.deltaTime, MOVs.z * Time.deltaTime);
            if(life <= (lifeTime * 0.05f))
            {
                swinging = false;
            }
        }
    }

    //public override void ResetCharge()
    //{
    //    base.ResetCharge();
    //    gameObject.transform.localPosition = new Vector3(0.64f, -0.2f, 1);
    //    gameObject.transform.localEulerAngles = new Vector3(-56, 145, 81);
    //   // bulletRot.gameObject.SetActive(false);
    //    //holding = false;
    //    StopCoroutine(Swing());
    //}

    public override bool Use()
    {
        base.Use();
        gameObject.transform.parent = Camera.main.transform;
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(0,0.05f,1);
        gameObject.transform.localEulerAngles = new Vector3(40, 90, 80);
        //if(!swinging)
        //{
        //    StartCoroutine(Swing());
        //}
        gameObject.transform.localPosition = POS;//new Vector3(0.64f, -0.2f, 1);
        gameObject.transform.localEulerAngles = ROT;//new Vector3(-56, 145, 81);
        swinging = true;

        return true;
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HurtBox")
        {
            if (other.gameObject.GetComponent<HurtBox>())
            {
                other.gameObject.GetComponent<HurtBox>().Slash(2);
            }
        }
        
    }

    private IEnumerator Swing()
    {
        
        swinging = true;
        timer = 0;
        gameObject.SetActive(true);
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        
        while (true)
        {
            yield return wait;
            
            life = 1;
            transform.Rotate(ROTs.x * Time.deltaTime, ROTs.y* Time.deltaTime, ROTs.z * Time.deltaTime);
            transform.Translate(MOVs.x * Time.deltaTime, MOVs.y * Time.deltaTime, MOVs.z * Time.deltaTime);
            if (timer >= swingTime)
            {
                timer = 0;
                //StopCoroutine(Swing());
                swinging = false;
                life = 0;
                break;
            }
        }
        
    }
}

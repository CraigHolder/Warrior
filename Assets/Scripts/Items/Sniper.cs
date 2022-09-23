using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Item
{
    public Transform bulletRot;

    public Sniper() : base()
    {
    }
    protected override void Start()
    {
        base.Start();
    }
    // Start is called before the first frame update
    public override void Update()
    {
        base.Update();
    }

    public override bool Use()
    {
        if(!base.Use())
        {
            return false;
        }
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("300Round"), new Vector3(transform.position.x + +0.0f, transform.position.y + 0.056f, transform.position.z) + (transform.right * 0.88f), bulletRot.rotation);
        //Physics.IgnoreCollision(go.GetComponent<Collider>(), GetComponent<Collider>());
        foreach (Enemy e in GM.enemies)
        {
            if (Vector3.Distance(e.transform.position, transform.position) <= noiseRange)
            {
                e.Hear(transform.position);
                Debug.Log("Sound Heard");
            }
        }
        go.GetComponent<Rigidbody>().velocity = this.transform.right * 80;
        go.GetComponent<Bullet>().prevVelocity = this.transform.right * 80;
        return true;

    }

    public override void Hold()
    {
        base.Hold();
        gameObject.transform.parent = Camera.main.transform;
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(0, -0.1f, 0.35f);
        gameObject.transform.localEulerAngles = new Vector3(0, -90, 0);
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
}

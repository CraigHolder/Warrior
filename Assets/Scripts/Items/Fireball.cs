using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Item
{
    public Transform bulletRot;

    public Fireball() : base()
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
        if (!base.Use())
        {
            return false;
        }
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("FBall"), new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z) + (transform.right * 0.6f), bulletRot.rotation);
        //Physics.IgnoreCollision(go.GetComponent<Collider>(), GetComponent<Collider>());
        foreach (Enemy e in GM.enemies)
        {
            if (Vector3.Distance(e.transform.position, transform.position) <= noiseRange)
            {
                e.Hear(transform.position);
                Debug.Log("Sound Heard");
            }
        }
        go.GetComponent<Rigidbody>().velocity = this.transform.right * 60;
        go.GetComponent<Bullet>().prevVelocity = this.transform.right * 60;
        return true;
    }

    public override void Hold()
    {
        base.Hold();
        gameObject.transform.parent = Camera.main.transform;
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(0, -0.08f, 0.66f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{

    void Start()
    {
        life = lifeTime;
        lastPos = transform.position;
        //strength = 2;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            tunnelCheck();
            hit = true;
            transform.localPosition -= transform.up;
        }
    }
}

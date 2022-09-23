using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool loadSave;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = transform.position;
        player.rotation.y = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

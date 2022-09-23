using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class Container : PersistentMonoBehaviour
{
    GameObject player;
    public List<Item> Items;
    public int index = 0;
    public Info info;
    public bool drop = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        info.text = "[E]\n["+Items[index].itemName+"]";
        for (int i = 0; i < Items.Count; i++)
        {
            if(!drop)
            {
                Item k = Instantiate<GameObject>(Resources.Load<GameObject>(Items[i].itemName)).GetComponent<Item>();
                Items[i] = k;
                Items[i].gameObject.SetActive(true);
                Items[i].transform.SetParent(transform);
                Items[i].transform.position = new Vector3(0, 0, 0);
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    
    //}

    
    public void IncreaseIndex()
    {
        index++;
        if (index >= Items.Count)
        {
            index = 0;
        }
        if(Items.Count > 0)
        {
            info.text = "[E]\n[" + Items[index].itemName + "]";
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

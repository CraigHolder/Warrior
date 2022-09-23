using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Transform player;
    [SerializeField]
    Transform neck;
    public static bool look;
    Quaternion defaultT;
    Animator animator;

    GameObject shopMenu;
    //GameObject popUp;
    Transform InventoryContent;
    delegate void myDelegate(Item item);
    myDelegate click;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shopMenu = GameObject.FindGameObjectWithTag("ShopMenu");
        //popUp = GameObject.FindGameObjectWithTag("PopUp");
        animator = GetComponent<Animator>();
        defaultT = neck.rotation;
        //InventoryContent = GameObject.FindGameObjectWithTag("InventoryContent").transform;
        //click = player.GetComponent<Player>().InventoryClick;
        shopMenu.SetActive(false);
        //popUp.SetActive(false);
        //coroutine = Wait(0.05f);
        //StartCoroutine(coroutine);
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("Coroutine ended: " + Time.time + " seconds");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(look)
        {
            neck.LookAt(player);
        }
        if (look && player && animator)
        {
            //animator.SetLookAtPosition(player.position);
            //animator.SetLookAtWeight(1, 0.0f, 1.0f, 0.0f, 0.5f);
            neck.LookAt(player.position);
            //neck.rotation *= Quaternion.LookRotation(neck.position - player.position);
            neck.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward);
            neck.Rotate(new Vector3(0,0, -75));

            //animator.SetLookAtWeight(1);

        }
        if(look)
        {
            if(Input.GetKeyDown(KeyCode.E) && !shopMenu.activeSelf)
            {
                shopMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
               // popUp.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.E) && shopMenu.activeSelf)
            {
                shopMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
               // popUp.SetActive(true);

                player.GetComponent<Player>().movingItem = false;
                player.GetComponent<Player>().selected = null;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            look = true;
//player.GetComponent<Player>().infoText.text = "[E]\nSHOP";
          //  popUp.SetActive(true);
          //  popUp.GetComponent<TMPro.TMP_Text>().text = "Press E: Shop";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            look = true;
            //player.GetComponent<Player>().infoText.text = "[E]\nSHOP";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            look = false;
            neck.rotation =  defaultT;
            shopMenu.SetActive(false);
            //player.GetComponent<Player>().infoText.text = "";
            //  popUp.SetActive(false);
            //popUp.GetComponent<TMPro.TMP_Text>().text = "Press E:";
            if(player.GetComponent<Player>().selected != null)
            {
                GameManager.Gold += player.GetComponent<Player>().selected.value;

                player.GetComponent<Player>().movingItem = false;
                player.GetComponent<Player>().selected = null;
            }
            
        }
    }

    public void Buy(int ID)
    {
        
        switch (ID)
        {
            case 1:
                AddItem("Sword");

                break;
            case 2:
                AddItem("9mmGun");

                break;
            case 3:
                AddItem("Bow");

                break;
            case 4:
                AddItem("Sniper");

                break;
            default:
                break;
        }
    }
    public void AddItem(string name)
    {
        Player Comp = player.gameObject.GetComponent<Player>();

        Item item = Instantiate<GameObject>(Resources.Load<GameObject>(name)).GetComponent<Item>();
        item.gameObject.SetActive(false);
        //Comp.Inventory.Add(item);
        item.transform.SetParent(player);
        item.transform.position = new Vector3(0, 0, 0);
        player.GetComponent<Player>().movingItem = true;
        player.GetComponent<Player>().selected = item;
        GameManager.Gold -= item.value;
        // GameObject gO;
        // gO = Instantiate(Resources.Load<GameObject>("InventoryItem"));
        // gO.transform.SetParent(InventoryContent);
        // gO.transform.localScale = new Vector3(1, 1, 1);
        // Button button = gO.GetComponent<Button>();
        // //next, any of these will work:
        // button.onClick.RemoveAllListeners();
        // button.onClick.AddListener(delegate { click(item); });
        //gO.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = "Value: " + item.value.ToString() ;
        //gO.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = item.itemName;
        //gO.transform.GetChild(2).GetComponent<TMPro.TMP_Text>().text = item.description;
    }
}

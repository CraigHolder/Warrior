using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZSerializer;

public class Player : PersistentMonoBehaviour
{
    public enum State
    {
        Dead,
        Asleep,
        SeverePain,
        Healthy
    }
    // Start is called before the first frame update
    public int Dex = 20;
    float playerVelocity = 0;
    public float speed = 10f;
    public float currSpeed = 10f;
    [SerializeField]
    private float jumpHeight = 2.0f;
    [SerializeField]
    private float gravity = -9.81f;

    bool jumping = false;
    public Slider painSlider;
    public Slider WaterSlider;

    public bool thirdPerson = false;
    public Camera cam;

    GameManager GM;

    CharacterController CC;
    Vector3 movement;
    Vector3 momentum;
    public LayerMask layerMask;

    public float lookSpeed = 3;
    public Vector2 rotation = Vector2.zero;

    //Inventory
    public int selectedHotbar = 0;
   // delegate void myDelegate(Item item);
   // myDelegate click;
    //GameObject InventoryUI;
    //Transform InventoryContent;
    public TMPro.TMP_Text infoText;
    public Item selected;
    public bool movingItem = false;
    public bool sellingItem = false;
    //bool usingItem = false;

    public Item[] Hotbar;
    public List<GameObject> hotBarOBJs = new List<GameObject>();
    public List<GameObject> hotBarBackOBJs = new List<GameObject>();
    //public List<Item> Inventory = new List<Item>();
    public TMPro.TMP_Text ammoText;
    public TMPro.TMP_Text movingText;

    [Header("Health")]
    public State currState = State.Healthy;
    public float PainThreshhold = 100;
    public float Pain = 0;
    private float prevPain = 0;
    public int HeadArmor = 0;
    public int LegArmor = 0;
    public int ChestArmor = 0;
    public int ArmArmor = 0;
    public bool disarmed = false;
    //Audio
    AudioSource Audio;
    [SerializeField]
    AudioSource walkAudio;
    bool holdSound = false;


    void Start()
    {
        CC = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        //InventoryUI = GameObject.FindGameObjectWithTag("Inventory");
        //InventoryContent = GameObject.FindGameObjectWithTag("InventoryContent").transform;
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //click = InventoryClick;
        Hotbar = new Item[8];
        //for (int i = 0; i < 4; i++)
        //{
        //Hotbar.Add(new Item());
        //}
        ammoText.text = "0/0";
        Audio = GetComponent<AudioSource>();
        painSlider.maxValue = PainThreshhold;
        //StartCoroutine(Wait(0.01f));
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("Coroutine ended: " + Time.time + " seconds");
        //InventoryUI.SetActive(false);
    }

    public void AddItem(Item item)
    {
        //Player Comp = player.gameObject.GetComponent<Player>();
        if(selected != null)
        {
            DropItem();
        }
        //Item item = Instantiate<GameObject>(Resources.Load<GameObject>(name)).GetComponent<Item>();
        item.gameObject.SetActive(false);
        item.transform.SetParent(cam.transform);
        item.transform.position = new Vector3(0, 0, 0);
        movingItem = true;
        selected = item;
    }
    public void DropItem()
    {
        //Player Comp = player.gameObject.GetComponent<Player>();

        Container c = Instantiate<GameObject>(Resources.Load<GameObject>("LootBag")).GetComponent<Container>();
        c.drop = true;
        c.Items.Add(selected);
        selected.gameObject.SetActive(false);
        selected.transform.SetParent(c.transform);
        selected.transform.position = new Vector3(0, 0, 0);
        c.info.text = "[E]\n[" + c.Items[0].itemName + "]";
        c.transform.position = cam.transform.position + cam.transform.forward;//*1.5f;
        
        //Destroy(selected);
        movingItem = false;
        selected = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (currState)
        {
            case State.Dead:
                WaterSlider.value = 0;
                painSlider.value = 0;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
                StopWalk();
                return;
            case State.Asleep:
                WaterSlider.value = 0;
                painSlider.value = 0;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
                StopWalk();
                return;
            case State.SeverePain:
                currSpeed = 1;
                if (Pain < PainThreshhold * 0.66f && WaterSlider.value > WaterSlider.maxValue / 5)
                {
                    currState = State.Healthy;
                }
                break;
            case State.Healthy:
                currSpeed = speed;
                break;

        }




        if(WaterSlider.value < WaterSlider.maxValue/5 || Pain > PainThreshhold * 0.66f)
        {
            currState = State.SeverePain;
            if(WaterSlider.value <= 0)
            {
                Pain += Time.deltaTime;
            }
        }
        
        WaterSlider.value -= Time.deltaTime;
        painSlider.value = PainThreshhold - Pain;



        RaycastHit hit;
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 1000F, Color.red);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
        {
            Transform objectHit = hit.transform;
            if (objectHit.GetComponent<Info>())
            {
                Info Comp = objectHit.GetComponent<Info>();
                infoText.text = Comp.text;
                if (Comp.container && Comp.parent.Items.Count > 0 && hit.distance < 5)
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        AddItem(Comp.parent.Items[Comp.parent.index]);
                        Comp.parent.Items.RemoveAt(Comp.parent.index);
                        Comp.parent.IncreaseIndex();
                        PlayAudio(101);
                    }
                    else if (Input.GetKeyDown(KeyCode.Tab))
                    {
                        Comp.parent.IncreaseIndex();
                    }
                }
                
            }
            else
            {
                infoText.text = "";
            }
        }
        else
        {
            infoText.text = "";
        }
        Controls();
    }

    private void FixedUpdate()
    {
        if (movingItem)
        {
            movingText.text = "Select Slot\n["+selected.itemName+"]";
            for (int i = 0; i < Hotbar.Length; i++)
            {
                if(Hotbar[i] == null)
                {
                    hotBarOBJs[i].transform.GetChild(2).gameObject.SetActive(true);
                }
                else
                {
                    hotBarOBJs[i].transform.GetChild(2).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            movingText.text = "";
        }
        if (Hotbar[selectedHotbar])
        {
                ammoText.text = Hotbar[selectedHotbar].uses + "/" + Hotbar[selectedHotbar].maxUses;
        }
        else
        {
            ammoText.text = "";
        }

        
    }

    void Controls()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Confined;
            GM.state = GameManager.GameState.Paused;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;


            //Camera and Rotation
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -60f, 48f);
            transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
            Camera.main.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        }

        //Hotbar Scrolling
        if (Input.mouseScrollDelta.y > 0)
        {
            hotBarBackOBJs[selectedHotbar].SetActive(false);
            selectedHotbar++;
            if (selectedHotbar >= hotBarBackOBJs.Count)
            {
                selectedHotbar = 0;
            }
            hotBarBackOBJs[selectedHotbar].SetActive(true);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            hotBarBackOBJs[selectedHotbar].SetActive(false);
            selectedHotbar--;
            if (selectedHotbar < 0)
            {
                selectedHotbar = hotBarBackOBJs.Count - 1;
            }
            hotBarBackOBJs[selectedHotbar].SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        //else if (Input.GetKeyDown(KeyCode.Tab) /*&& InventoryUI.activeSelf*/)
        //{
        //    CloseInventory();
        //}
        if(Input.GetKeyDown(KeyCode.V))
        {
            ThirdPersonToggle();
        }
        if (Input.GetKeyDown(KeyCode.Tilde) || Input.GetKeyDown(KeyCode.BackQuote))
        {
            GM.ToggleControls();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(movingItem && Shop.look != true)
            {
                DropItem();
            }
            else if(Hotbar[selectedHotbar])
            {
                selected = Hotbar[selectedHotbar];
                DropItem();
                hotBarOBJs[selectedHotbar].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = "Empty";
                Hotbar[selectedHotbar] = null;
            }
        }


        //normal
        //Locomotion
        movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }
        
        if (movement != Vector3.zero && movingItem && infoText.text == "" && Shop.look != true)
        {
            DropItem();
        }


        //Half
        //hotbar
        //USE AND ALT USE
        /*
         
         
         */

        //if (!InventoryUI.activeSelf)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //if(movingItem)
                //{
                //    PlaceHotbar(selectedHotbar);
                //}
                //else 
                if (Hotbar[selectedHotbar] && !Shop.look)
                {
                    GM.state = GameManager.GameState.Third;
                    if (Hotbar[selectedHotbar].gun == true)
                    {
                        Hotbar[selectedHotbar].Hold();
                        if(!holdSound)
                        {
                            holdSound = true;
                            if(Hotbar[selectedHotbar].audioIndex == 13)
                            {
                                Audio.volume = Hotbar[selectedHotbar].volume;
                                PlayAudio(Hotbar[selectedHotbar].audioIndex);
                            }
                            
                        }
                    }
                    Hotbar[selectedHotbar].UpdateCharge();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (Hotbar[selectedHotbar] && !Shop.look)
                {
                    if(Hotbar[selectedHotbar].Use())
                    {
                        if(Hotbar[selectedHotbar].audioIndex != 13)
                        {
                            Audio.volume = Hotbar[selectedHotbar].volume;
                            PlayAudio(Hotbar[selectedHotbar].audioIndex);
                        }
                    }
                    holdSound = false;
                    Hotbar[selectedHotbar].ResetCharge();
                }
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                GM.state = GameManager.GameState.Third;
                if (Hotbar[selectedHotbar])
                {
                    if (Hotbar[selectedHotbar].gun == true)
                    {
                        Hotbar[selectedHotbar].Hold();
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                if (Hotbar[selectedHotbar])
                {
                    Hotbar[selectedHotbar].AltUse();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (movingItem)
            {
                PlaceHotbar(0);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 0;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }

        }
        //if (Input.GetKeyUp(KeyCode.Alpha1))
        //{

        //    if (movingItem)
        //    {
        //        Hotbar[0] = selected;
        //        hotBarOBJs[0].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = selected.itemName;
        //        Hotbar[0].slot = 0;
        //        movingItem = false;
        //        selected = null;
        //    }
        //    else if (Hotbar[0])
        //    {
        //        if (Input.GetKey(KeyCode.LeftShift))
        //        {
        //            Hotbar[0].AltUse();
        //        }
        //        else
        //        {
        //            CloseInventory();
        //            Hotbar[0].Use();
        //        }
        //    }
        //}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (movingItem)
            {
                PlaceHotbar(1);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 1;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (movingItem)
            {
                PlaceHotbar(2);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 2;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            if (movingItem)
            {
                PlaceHotbar(3);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 3;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            if (movingItem)
            {
                PlaceHotbar(4);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 4;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            if (movingItem)
            {
                PlaceHotbar(5);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 5;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            if (movingItem)
            {
                PlaceHotbar(6);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 6;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            if (movingItem)
            {
                PlaceHotbar(7);
            }
            else
            {
                hotBarBackOBJs[selectedHotbar].SetActive(false);
                selectedHotbar = 7;
                hotBarBackOBJs[selectedHotbar].SetActive(true);
            }
        }

        if (!Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse0) /*&& !InventoryUI.activeSelf*/)
        {
            GM.state = GameManager.GameState.Normal;
        }




        CC.Move(new Vector3(0, playerVelocity * Time.deltaTime, 0));
        //jumping
        if (CC.isGrounded && playerVelocity < 0)
        {
            playerVelocity = -0.1f;
            //jumping = false;
            if (Input.GetKey(KeyCode.Space)) //&& CC.isGrounded) //&& jumping == false)
            {
                // jumping = true;
                switch(GM.state)
                {
                    case GameManager.GameState.Normal:
                        playerVelocity += Mathf.Sqrt((jumpHeight * (1)) * -3.0f * gravity);
                        break;

                    case GameManager.GameState.Half:
                        playerVelocity += Mathf.Sqrt((jumpHeight * (2)) * -3.0f * gravity);
                        break;
                    case GameManager.GameState.Third:
                        playerVelocity += Mathf.Sqrt((jumpHeight * (3)) * -3.0f * gravity);
                        break;
                }
                
            }

            if(movement != Vector3.zero)
            {
                WalkSound("sand");
            }
            
        }
       
        
        playerVelocity += gravity;
        //CC.Move(new Vector3(0, playerVelocity * Time.deltaTime, 0));
        CC.Move(movement * Time.deltaTime * currSpeed);

    }

    //public void InventoryClick(Item item)
    //{
    //    Debug.Log("clicked");
    //    selected = item;
    //    movingItem = true;
    //    if (item.slot != -3)
    //    {
    //        switch (item.slot)
    //        {
    //            case 0:
    //                Hotbar[0] = null;
    //                break;
    //            case 1:
    //                Hotbar[1] = null;
    //                break;
    //            case 2:
    //                Hotbar[2] = null;
    //                break;
    //            case 3:
    //                Hotbar[3] = null;
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}
    public void ThirdPersonToggle()
    {
        if(thirdPerson)
        {
            thirdPerson = false;
            cam.transform.localPosition = new Vector3(0.35f, 2.2f, -0.55f);
        }else
        {
            thirdPerson = true;
            cam.transform.localPosition = new Vector3(0, 2, 0);
        }
        

    }
    //public void CloseInventory()
    //{
    //    InventoryUI.SetActive(false);
    //    movingItem = false;
    //    GM.state = GameManager.GameState.Normal;
    //}

    public void PlaceHotbar(int i)
    {
        if(Hotbar[i] == null)
        {
            Hotbar[i] = selected;
            hotBarOBJs[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = Hotbar[i].itemName;
            //Hotbar[0].slot = 0;
            Hotbar[i].slot = i;
            movingItem = false;
            selected = null;
        }
        else
        {
            Item temp = selected;
            selected = Hotbar[i];
            DropItem();

            Hotbar[i] = temp;
            hotBarOBJs[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = Hotbar[i].itemName;
            //Hotbar[0].slot = 0;
            Hotbar[i].slot = i;
            movingItem = false;
            selected = null;
        }
        for (int k = 0; k < Hotbar.Length; k++)
        {
            
                hotBarOBJs[k].transform.GetChild(2).gameObject.SetActive(false);
            
        }

    }
    
    public void PlayAudio(int index)
    {
        if(index > 0 && index < AudioUtility.sounds.Count - 1)
        {
            if (Audio.clip == AudioUtility.sounds[index])
            {
                if (Audio.isPlaying)
                {
                    return;
                }
            }
            Audio.clip = AudioUtility.sounds[index];
            Audio.Play();
        }
        
    }

    void WalkSound(string ground)
    {
        if (walkAudio.isPlaying)
        {
            return;
        }
        AudioClip temp = null;
        switch (ground)
        {
            case "sand":
                temp = AudioUtility.sounds[Random.Range(77, 85)];
                break;
            case "stone":
                temp = AudioUtility.sounds[Random.Range(87, 95)];
                break;
            case "wood":
                temp = AudioUtility.sounds[Random.Range(97, 99)];
                break;
            case "water":
                temp = AudioUtility.sounds[Random.Range(95, 97)];
                break;
            default:
                temp = AudioUtility.sounds[Random.Range(77, 85)];
                break;
        }
        walkAudio.clip = temp;
        walkAudio.Play();
    }
    void StopWalk()
    {
        walkAudio.Stop();
    }

    public void LoadItems()
    {
        Item[] gos = cam.transform.GetComponentsInChildren<Item>(true);
        foreach(Item i in gos)
        {
            Hotbar[i.slot] = null;
            selected = i;
            PlaceHotbar(i.slot);
        }
        //for (int i = 0; i < cam.transform.childCount; i++)
        //{
        //    Hotbar[cam.transform.GetChild(i).GetComponent<Item>().slot] = null;
        //    selected = cam.transform.GetChild(i).GetComponent<Item>();
        //    PlaceHotbar( cam.transform.GetChild(i).GetComponent<Item>().slot);
        //} 
    }
}

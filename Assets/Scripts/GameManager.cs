using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class GameManager : PersistentMonoBehaviour
{
    public enum GameState
    {
        Paused,
        Half,
        Third,
        Normal
    }
    public GameState state;
    public GameState prevState;
    public TMPro.TMP_Text WinText;
    public Player player;
    public static int Gold = 100;
    [SerializeField]
    private TMPro.TMP_Text goldText;
    int numEnemies=0;
    public List<Enemy> enemies;
    public List<Enemy> knockedEnemies;
    public List<Enemy> surrenderedEnemies;
    float gameTime = 0;
    public int kills = 0;
    public int unconscious = 0;
    public int surrendered = 0;
    public int saveNum = 1;

    public TMPro.TMP_Text controlText;
    public GameObject solar;
    //[NonZSerialized]
   // bool freshLoad = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       GameObject[] a = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject o in a)
        {
            enemies.Add(o.GetComponent<Enemy>());
        }
        numEnemies = enemies.Count;
        Time.timeScale = 1;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (state != prevState)
        {
            prevState = state;
            switch (state)
            {
                case GameState.Normal:
                    Time.timeScale = 1;

                    break;
                case GameState.Third:
                    Time.timeScale = 0.33f;

                    break;
                case GameState.Half:
                    Time.timeScale = 0.5f;

                    break;
                case GameState.Paused:
                    Time.timeScale = 0;
                    break;
            }
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].currState == Enemy.State.Dead || enemies[i].currState == Enemy.State.Asleep || enemies[i].currState == Enemy.State.Surrendering)
            {
                if (enemies[i].currState == Enemy.State.Dead)
                {
                    kills++;
                    enemies.Remove(enemies[i]);
                }
                else if (enemies[i].currState == Enemy.State.Asleep)
                {
                    unconscious++;
                    knockedEnemies.Add(enemies[i]);
                    enemies.Remove(enemies[i]);
                }
                else
                {
                    surrendered++;
                    surrenderedEnemies.Add(enemies[i]);
                    enemies.Remove(enemies[i]);
                }
            }
        }
        for (int i = 0; i < knockedEnemies.Count; i++)
        {
            if (knockedEnemies[i].currState == Enemy.State.Dead)
            {
                kills++;
                unconscious--;
                knockedEnemies.Remove(knockedEnemies[i]);
            }
        }
        for (int i = 0; i < surrenderedEnemies.Count; i++)
        {
            if (surrenderedEnemies[i].currState == Enemy.State.Dead)
            {
                kills++;
                surrendered--;
                surrenderedEnemies.Remove(surrenderedEnemies[i]);
            }
            else if (surrenderedEnemies[i].currState == Enemy.State.Asleep)
            {
                unconscious++;
                surrendered--;
                knockedEnemies.Add(surrenderedEnemies[i]);
                surrenderedEnemies.Remove(surrenderedEnemies[i]);
            }
        }

        if (kills + unconscious + surrendered == numEnemies)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "Victory\nTime: " + gameTime + "\nKills: " + kills + "\nUnconscious: " + unconscious + "\nSurrendered: " + surrendered + "\n\n\nPress R to Restart";
            state = GameState.Paused;
        }
        else if(player.currState == Player.State.Dead)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].StopWalk();
            }
            for (int i = 0; i < surrenderedEnemies.Count; i++)
            {
                surrenderedEnemies[i].StopWalk();
            }
                WinText.gameObject.SetActive(true);
            WinText.text = "Dead\nTime: " + gameTime + "\nKills: " + kills + "\nUnconscious: " + unconscious + "\nSurrendered: " + surrendered + "\n\n\nPress R to Restart";
            state = GameState.Paused;
        }
        else
        {
            gameTime += Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.F5))
        {
            //for (int i = 0; i < enemies.Count; i++)
            //{
            //    enemies[i].agent.Stop();
            //}
            
                ZSerialize.SaveScene();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            Debug.Log("Loading...");
            _ = ZSerialize.LoadScene();
            player.LoadItems();

            for (int i = 0; i < enemies.Count; i++)
            {
                //if (enemies[i].rangedWeapon != null)
                //{
                //    Destroy(enemies[i].rangedWeapon.gameObject);
                //}
                //if (enemies[i].meleeWeapon != null)
                //{
                //    Destroy(enemies[i].meleeWeapon.gameObject);
                //}
                //enemies[i].rangedWeapon = null;
                //enemies[i].meleeWeapon = null;
                //enemies[i].Start();
                enemies[i].rangedWeapon = enemies[i].transform.FindChild("RangedWeapon").GetComponent<Item>();
                //enemies[i].currState = (Enemy.State)enemies[i].saveState;
                if (enemies[i].currState != Enemy.State.Asleep && enemies[i].currState != Enemy.State.Dead)
                {
                    int k = 0;
                    foreach (Rigidbody r in GetComponentsInChildren<Rigidbody>())
                    {
                        r.isKinematic = true;
                        r.transform.position = enemies[i].bodyPos[k].position;
                        r.transform.rotation = enemies[i].bodyPos[k].rotation;
                        r.transform.localScale = enemies[i].bodyPos[k].localScale;
                        k++;
                    }
                }

                //enemies[i].currAttitude = (Enemy.Attitude)enemies[i].saveAtt;
            }

                Debug.Log("Load Done");
        }
       

    }

    public void ToggleControls()
    {
        if(controlText.gameObject.activeSelf == true)
        {
            controlText.gameObject.SetActive(false);
        }else
        {
            controlText.gameObject.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        goldText.text ="Gold:" + Gold;
    }
}

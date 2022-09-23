using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ZSerializer;

public class Enemy : PersistentMonoBehaviour
{
    public enum State
    {
        Dead,
        Asleep,
        Idle,
        OnGuard,
        Following,
        Attacking,
        Running,
        Surrendering
    }

    public enum Attitude
    {
        Ally,
        Passive,
        Neutral,
        Suspicous,
        Hostile,
        Cowardly,
        None
    }
    [NonZSerialized]
    public Item rangedWeapon;
    [NonZSerialized]
    public Item meleeWeapon;

    public Transform pathTarget;
    [NonZSerialized]public NavMeshAgent agent;
    public float speed = 3.5f;
    public float attackRange = 5;
    public float Reaction = 1;
    public float Curious = 1;
    public float Suspicion = 0;
    public State currState = State.Idle;
    //[SerializeField]
    //public int saveState = -1;
    public Attitude currAttitude = Attitude.Hostile;
    //[SerializeField]
    //public int saveAtt = -1;
    public GameObject FOVOBJ;
    public List<Rigidbody> physicsBody;
    public Info info;
    public float shotDelay = 0;

    [Header("Sight")]
    public float radius;
    [Range(0, 360)]
    public float angle;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool looking = false; //Can they see the player
    public Transform eyes;
    public bool blind = false; //can they see
    [Header("Hearing")]
    public float distance = 1;
    public bool heard = false;
    public bool deaf = false;
    [Header("Body")]
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

    public List<Transform> bodyPos;

    // Start is called before the first frame update
    public void Start()
    {
        bodyPos = new List<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        //StartCoroutine(FOVRoutine());
        pathTarget = GameObject.FindGameObjectWithTag("Player").transform;
        physicsBody.Add(GetComponentInChildren<Rigidbody>());
        foreach (Rigidbody r in GetComponentsInChildren<Rigidbody>())
        {
            r.isKinematic = true;
            if(r.gameObject.GetComponent<MeshRenderer>())
            {
                r.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        AddItems("9mmGun", true);
        rangedWeapon.gameObject.name = "RangedWeapon";
        Audio = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        
        

        switch (currState)
        {
            case State.Dead:
                deaf = true;
                blind = true;
                FOVOBJ.SetActive(false);
                agent.isStopped = true;
                foreach (Rigidbody r in GetComponentsInChildren<Rigidbody>())
                {
                    Transform temp = r.transform;
                    bodyPos.Add(temp);
                    if (!r.name.Contains("Hurt") && !r.name.Contains("Info") && r.tag != "Bullet")
                    {
                        r.isKinematic = false;
                    }
                }
                info.text = "They are dead";
                StopWalk();
                //if()
                break;
            case State.Asleep:
                blind = true;
                FOVOBJ.SetActive(false);
                agent.isStopped = true;
                foreach (Rigidbody r in GetComponentsInChildren<Rigidbody>())
                {
                    if (!r.name.Contains("Hurt") && !r.name.Contains("Info") && r.tag != "Bullet")
                    {
                        r.isKinematic = false;
                    }
                }
                info.text = "They are unconscious";
                StopWalk();
                break;
            case State.Idle:

                break;
            case State.OnGuard:

                break;
            case State.Following:

                break;
            case State.Attacking:
                FOVOBJ.SetActive(false);

                rangedWeapon.Hold(transform);

                shotDelay += Time.deltaTime;
                if (shotDelay >= rangedWeapon.rechargeSpeed && looking)
                {
                    rangedWeapon.Use();
                    Audio.volume = rangedWeapon.volume;
                    PlayAudio(rangedWeapon.audioIndex);
                    shotDelay = 0;
                }
                Path();
                break;
            case State.Running:
                RunAway();
                break;
            case State.Surrendering:
                info.text = "They are surrendering";
                StopMoving();
                break;
        }
        if (currState == State.Dead || currState == State.Asleep || currState == State.Surrendering)
        {
            if(currState == State.Asleep && prevPain != Pain)
            {
                prevPain = Pain;
            }
            return;
        }
        //disarm check
        if (disarmed && currState != State.Surrendering)
        {
            currAttitude = Attitude.Cowardly;

        }

        
        
        

        if (looking)
        {
            Suspicion += Time.deltaTime * Curious;
            if(Suspicion >= Reaction)
            {
                switch (currAttitude)
                {
                    case Attitude.Ally:
                        currState = State.Following;
                        break;
                    case Attitude.Passive:
                        currState = State.Idle;
                        break;
                    case Attitude.Neutral:
                        currState = State.Idle;
                        break;
                    case Attitude.Suspicous:
                        currState = State.OnGuard;
                        break;
                    case Attitude.Hostile:
                        currState = State.Attacking;
                        break;
                    case Attitude.Cowardly:
                        currState = State.Running;
                        if (speed <= 1)
                        {
                            currState = State.Surrendering;
                        }
                        break;
                }
            }
        }
        switch (currAttitude)
        {
            case Attitude.Ally:
                info.text = "They are Friendly"; 
                break;
            case Attitude.Passive:
                info.text = "They are Idle";
                break;
            case Attitude.Neutral:
                info.text = "They are Idle";
                break;
            case Attitude.Suspicous:
                info.text = "They are OnGuard";
                break;
            case Attitude.Hostile:
                info.text = "They are Hostile";
                break;
            case Attitude.Cowardly:
                info.text = "They are Running";
                currState = State.Running;
                if (speed <= 1)
                {
                    currState = State.Surrendering;
                }
                break;
        }
        //pain calculations
        if (Pain > 0 && Pain != prevPain)
        {
            if (Pain > PainThreshhold / 3)
            {
                speed *= 0.8f;
            }
            if (Pain > PainThreshhold * 0.80)
            {
                deaf = true;
                Curious = 0;
            }
            if (Pain >= PainThreshhold)
            {
                currState = State.Asleep;
            }
        }
        prevPain = Pain;

    }

    private void FixedUpdate()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            //+ Random.Range(1, 2)
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (new Vector3(target.position.x, target.position.y+1, target.position.z) - eyes.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(eyes.position, new Vector3(target.position.x, target.position.y+1 , target.position.z));
                Debug.DrawRay(eyes.position, directionToTarget * (distanceToTarget), Color.green, 0.1f);
                if (!Physics.Raycast(eyes.position, directionToTarget, distanceToTarget, obstructionMask))
                    looking = true;
                else
                    looking = false;
            }
            else
                looking = false;
        }
        else if (looking)
            looking = false;
    }

    void Path()
    {
        agent.SetDestination(pathTarget.position);
        agent.speed = speed;
        WalkSound("sand");
    }
    public void Path(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.speed = speed;
        WalkSound("sand");
    }
    void RunAway()
    {
        if(Vector3.Distance(pathTarget.position, transform.position) <= 200)
        {
            var FromPlayer = pathTarget.position - transform.position;
            agent.SetDestination(transform.position + (-FromPlayer.normalized * 5));
        }
        WalkSound("sand");
    }
    void StopMoving()
    {
        agent.SetDestination(transform.position);
        agent.speed = speed;
        StopWalk();
    }

    public void Hear(Vector3 v)
    {
        if(!deaf)
        {
                  agent.SetDestination(v);
            agent.speed = speed;
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(eyes.position, new Vector3 (target.position.x, target.position.y + Random.Range(2,6), target.position.z));
                Debug.DrawRay(eyes.position, directionToTarget * (distanceToTarget * 50), Color.green, 0.1f);
                if (Physics.Raycast(eyes.position, directionToTarget, distanceToTarget * 50, obstructionMask))
                    looking = true;
                else
                    looking = false;
            }
            else
                looking = false;
        }
        else if (looking)
            looking = false;
    }


    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return wait;
            if(!blind)
            {
                FieldOfViewCheck();
            }
        }
    }

    public void AddItems(string name, bool ranged)
    {
        Item item = Instantiate<GameObject>(Resources.Load<GameObject>(name)).GetComponent<Item>();
        item.gameObject.SetActive(false);
        if(ranged)
        {
            this.rangedWeapon = item;
        }
        else
        {
            this.meleeWeapon = item;
        }
       
        item.transform.SetParent(transform);
        item.transform.position = new Vector3(0, 0, 0);
    }

    public void PlayAudio(int index)
    {
        Audio.clip = AudioUtility.sounds[index];
        Audio.Play();
    }
    void WalkSound(string ground)
    {
        if(walkAudio.isPlaying)
        {
            return;
        }
        AudioClip temp = null;
        switch(ground)
        {
            case "sand":
                temp = AudioUtility.sounds[Random.Range(77,85)];
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
    public void StopWalk()
    {
        walkAudio.Stop();
    }
}

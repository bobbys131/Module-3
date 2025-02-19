using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject PlayerBodyTrigger;
    private NavMeshAgent navMeshAgent;
    public Transform player;
    public float alarmDecayRate;
    public float alarmGainRate;
    private float AlarmState;
    public GameObject PP1;
    public GameObject PP2;
    public GameObject PP3;
    public GameObject PP4;
    private int patrolStatus;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("enemySight Started");
        patrolStatus = 1;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AlarmState <= 0f)
        {
            AlarmState = 0f;
        } else if (AlarmState >= 100f)
        {
            AlarmState = 100f;
        }
        AlarmState -= alarmDecayRate;
        if (AlarmState >= 80)
        {
            navMeshAgent.SetDestination(player.position);
        }
        if (AlarmState < 40)
        {
            if (patrolStatus == 1)
            {
                navMeshAgent.SetDestination(PP1.transform.position);
                if (Vector3.Distance(PP1.transform.position, transform.position) < 1)
                {
                    patrolStatus++;
                }
            }
            else if (patrolStatus == 2)
            {
                navMeshAgent.SetDestination(PP2.transform.position);
                if (Vector3.Distance(PP2.transform.position, transform.position) < 1)
                {
                    patrolStatus++;
                }
            }
            else if (patrolStatus == 3)
            {
                navMeshAgent.SetDestination(PP3.transform.position);
                if (Vector3.Distance(PP3.transform.position, transform.position) < 1)
                {
                    patrolStatus++;
                }
            }
            else if (patrolStatus == 4)
            {
                navMeshAgent.SetDestination(PP4.transform.position);
                if (Vector3.Distance(PP4.transform.position, transform.position) < 1)
                {
                    patrolStatus = 1;
                }
            }
        }
        Debug.Log("alarmstate:");
        Debug.Log(AlarmState);
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject == PlayerBodyTrigger.gameObject)
        {
            if (Physics.Linecast(Enemy.transform.position, PlayerBodyTrigger.transform.position, ~(1 << 2)))
            {
                Debug.Log("blocked");
            }
            else
            {
                Debug.Log("not blocked");
                if (AlarmState > 10)
                {
                    transform.LookAt(PlayerBodyTrigger.transform);
                }
                if (AlarmState > 20)
                {
                    navMeshAgent.SetDestination(player.position);
                }
                AlarmState += alarmGainRate;
            }
        }
        //Debug.Log("Collision detected with " + collision.gameObject.name);
    }
}

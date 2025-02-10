using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject PlayerBodyTrigger;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("enemySight Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject == PlayerBodyTrigger.gameObject)
        {
            if (Physics.Linecast(Enemy.transform.position, PlayerBodyTrigger.transform.position, ~(1<<2)))
            {
                Debug.Log("blocked");
            } 
            else
            {
                Debug.Log("not blocked");
                transform.LookAt(PlayerBodyTrigger.transform);
            }
        }
        //Debug.Log("Collision detected with " + collision.gameObject.name);
    }
}

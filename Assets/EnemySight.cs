using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyVisionCone;
    public GameObject PlayerBodyTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == PlayerBodyTrigger)
        {
            if (Physics.Linecast(Enemy.transform.position, PlayerBodyTrigger.transform.position))
            {
                Debug.Log("blocked");
            }
        }
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }
}

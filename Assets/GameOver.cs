using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject SpawnPoint;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Killbox"))
        {
            transform.position = SpawnPoint.transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject EnemyKillBox;
    public string sceneName;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == EnemyKillBox.gameObject)
        {
            transform.position = SpawnPoint.transform.position;
        }
    }
}

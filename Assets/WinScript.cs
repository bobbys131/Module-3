using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;

    public GameObject winTextObject;

    //LIV 
    private void Start()
    {
        winTextObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Player.gameObject)
        {
            Enemy1.SetActive(false);
            Enemy2.SetActive(false);
            Enemy3.SetActive(false);
            //Enemy4.SetActive(false);
            //Enemy5.SetActive(false);

            //LIV
            winTextObject.SetActive(true);
        }
    }
}

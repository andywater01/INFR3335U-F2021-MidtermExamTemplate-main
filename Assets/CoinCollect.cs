using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CoinCollect : MonoBehaviour
{
    
    private void Awake()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
    }


    public int coinCount = 0;

 


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 1);
        }
    }
}

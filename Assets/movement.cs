using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    
    public GameObject player;
    public Rigidbody rb;
    public Animator anim;
    public AudioSource CoinPickUp;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            anim.SetInteger("AnimatorState", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * 2 * Time.deltaTime);
            anim.SetInteger("AnimatorState", 2);
        }
        else
        {
            anim.SetInteger("AnimatorState", 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * 2 * Time.deltaTime);
            //anim.SetInteger("AnimatorState", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * 2 * Time.deltaTime);
            //anim.SetInteger("AnimatorState", 1);
        }


        player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, player.transform.rotation.eulerAngles.z);

        

        if (PlayerPrefs.GetInt("CoinCount") >= 10)
        {
            SceneManager.LoadScene("End");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Coin")
        {
            CoinPickUp.Play();
        }
    }
}

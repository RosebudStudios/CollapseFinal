using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_contact_destroy : MonoBehaviour
{
    public bool self;

    public AudioClip soundeffect;
    public AudioSource audioSource;

    GameObject obj;
 

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("GameController");
      //  audioSource = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (self == true)
        {
            if (other.tag == "Obstacle")
            {
                obj.GetComponent<scr_game_controller>().gamestate = 3;
                Destroy(gameObject);

            }

        }

        if (self == false)
        {
            if (other.tag == "Obstacle")
            {
                Destroy(other.gameObject);

                if (obj.GetComponent<scr_game_controller>().gamestate == 1)
                {
                    audioSource.Play();
                }
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_controller : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.Rotate(0, 0, speed);
        }

        if ((Input.GetKey(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.Rotate(0, 0, -speed);
        }
    }
}

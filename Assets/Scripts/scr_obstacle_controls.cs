using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_obstacle_controls : MonoBehaviour
{
    public float scalespeed;

    private float rotatespeed;
    private float spawnrotation;
    private bool rotatedirection;

    void Start()
    {
        spawnrotation = Random.Range(0, 180);
        rotatedirection = (Random.Range(0, 2) == 0);
        rotatespeed = Random.Range(0.5f, 1.5f);

        transform.localEulerAngles = new Vector3(0, 0, spawnrotation);
    }


    void Update()
    {
        transform.localScale -= new Vector3(scalespeed, scalespeed, 0);

        if (rotatedirection == true)
        {
            transform.Rotate(0, 0, rotatespeed);
        }

        if (rotatedirection == false)
        {
            transform.Rotate(0, 0, -rotatespeed);
        }
    }
}

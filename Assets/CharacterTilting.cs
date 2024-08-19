using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTilting : MonoBehaviour
{
    public GameObject character;




    float rY;

    // Use this for initialization
    public float speed = 0.1f;
    public float RotAngleZ1 = .5f;
    public float RotAngleZ2 = -.5f;


    // Update is called once per frame
    void Update()
    {
        if (character.transform.rotation.y == 0)
        {
            float rZ = Mathf.SmoothStep(RotAngleZ2, RotAngleZ1, Mathf.PingPong(Time.time * speed, 1));
            transform.rotation = Quaternion.Euler(0, 0, rZ);
        }
        else
        {
            float rZ = Mathf.SmoothStep(RotAngleZ2, RotAngleZ1, Mathf.PingPong(Time.time * speed, 1));
            transform.rotation = Quaternion.Euler(0, 180, rZ);
        }

    }
   
}

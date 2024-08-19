using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Spawner : MonoBehaviour
{
    private int rand;
    public Sprite[] spritePic;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, spritePic.Length);
        GetComponent<SpriteRenderer>().sprite = spritePic[rand];

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

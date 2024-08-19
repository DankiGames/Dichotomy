
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
public class CharacterMovement : MonoBehaviour
{

    public float speed = 1;
    public TextMeshProUGUI characterDlog;
    public GameObject recallTextObject;
    

    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(-4, -1, 0);
    private Vector3 leavingPosition = new Vector3(-11, -5, 0);
    private bool leaving = false;
    private bool keyInput = false;
    private string[] lines = new string[6];


    void Start()
    {
        transform.position = new Vector3(-11, -5, 0);

        rb = GetComponent<Rigidbody>();

        characterDlog.text = "";

        
        for(int index = 0;index <6; index++)
        {
            lines[index] = Application.streamingAssetsPath + "/Recall_Chat/" + "Dialoge" + ".txt";
        }
 
    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.position != endPosition)&& leaving == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
        if (transform.position == endPosition)
        {
            characterDlog.text = "Can I use your toilet?";
            //switch(flag)
            //{
            //    case 1:
            //        //characterDlog.text = "Can I use your toilet?";
            //        characterDlog.text = lines[0];
            //        break;
            //    case 4:
            //        characterDlog.text = lines[3];
            //        break;
            //}
            //flag++;    


        }
    }
    //private void FixedUpdate()
    //{

    //}
    private void LateUpdate()
    {
        if ((Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.N)))
        {
            keyInput = true;
        }
        if (transform.position == endPosition)
        {
            leaving = true;
        }

        if ((keyInput == true) &&(leaving == true))
        {
            if (transform.position != leavingPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, leavingPosition, speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Y))
            {
                characterDlog.text = "Thanks!";
                //switch (flag)
                //{
                //    case 2:
                //        //characterDlog.text = "Can I use your toilet?";
                //        characterDlog.text = lines[1];
                //        break;
                //    case 5:
                //        characterDlog.text = lines[4];
                //        break;
                //}
                //flag++;
            }
            else if (Input.GetKey(KeyCode.N))
            {
                characterDlog.text = "Fuck you!";
                //switch (flag)
                //{
                //    case 3:
                //        //characterDlog.text = "Can I use your toilet?";
                //        characterDlog.text = lines[2];
                //        break;
                //    case 6:
                //        characterDlog.text = lines[5];
                //        break;
                //}
                //flag++;
            }
        }

        if(transform.position == leavingPosition)
        {
            characterDlog.text = "";
        }

    }


}

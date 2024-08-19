using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class NextScene : MonoBehaviour
{
    int counter = 0;
    int otherCounter = 0;
    public TextMeshProUGUI loading;


    void Update()
    {

        counter++;

         if (counter == 350)
         {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
    }

}

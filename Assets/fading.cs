using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fading : MonoBehaviour
{
    public SpriteRenderer title;
    private IEnumerator FadeIn(SpriteRenderer dayCycle)
    {
        float alphaVal = title.color.a;
        Color tmp = title.color;

        while (dayCycle.color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            dayCycle.color = tmp;

            yield return new WaitForSeconds(0.05f); // update interval
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float alphaVal = title.color.a;
        Color tmp = title.color;

        if (title.color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            title.color = tmp;

            //yield return new WaitForSeconds(0.05f); // update interval
        }
    }
}

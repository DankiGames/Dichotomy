using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesScript : MonoBehaviour
{
    enum bubbleState
    {
        generate,
        call,

    };

    int number = 1;
    public SpriteRenderer bubblesOne;
    public SpriteRenderer bubblesTwo;


    private bubbleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = bubbleState.generate;
    }
    private IEnumerator FadeIn(SpriteRenderer dayCycle)
    {
        float alphaVal = dayCycle.color.a;
        Color tmp = dayCycle.color;

        while (dayCycle.color.a < 1)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            dayCycle.color = tmp;

            yield return new WaitForSeconds(0.05f); // update interval
        }
    }
    private IEnumerator FadeOut(SpriteRenderer dayCycle)
    {
        float alphaVal = dayCycle.color.a;
        Color tmp = dayCycle.color;

        while (dayCycle.color.a > 0)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;
            dayCycle.color = tmp;

            yield return new WaitForSeconds(0.05f); // update interval
        }
    }
    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case bubbleState.generate:

                if(number > 2)
                {
                    number = 1;
                }
                

                state = bubbleState.call;

                break;

            case bubbleState.call:

                if (number == 1)
                {
                    
                    StartCoroutine(FadeOut(bubblesOne));
                    StartCoroutine(FadeIn(bubblesTwo));


                    
                    //if (bubblesTwo.color.a == 1)
                    //{
                    //    number++;
                    //    state = bubbleState.generate;
                    //}



                }
                else if (number == 2)
                {

                    StartCoroutine(FadeOut(bubblesTwo));
                    StartCoroutine(FadeIn(bubblesOne));

                    
                    //if (bubblesOne.color.a == 1)
                    //{
                    //    number++;
                    //    state = bubbleState.generate;
                    //}

                }

                number++;
                state = bubbleState.generate;

                break;
        }
        

        
        
    }
}

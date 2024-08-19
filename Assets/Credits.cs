using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    enum creditsState
    {
      GameArch,
      Art,
      music,
      emotionalSupport,
      DanckiGamesLogo
    };

    private creditsState currentState;

    public TextMeshProUGUI LText;
    public TextMeshProUGUI cText;
    public GameObject StudioAnimation;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentState = creditsState.GameArch;
        LText.text = "";
        cText.text = "";
        StudioAnimation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case creditsState.GameArch:
                LText.text = "Game Architecture";
                cText.text = "Ashlyn Lancki @dancki_lancki";
                counter++;

                if(counter == 180)
                {
                    counter = 0;
                    LText.text = "";
                    cText.text = "";
                    currentState = creditsState.Art;
                }
                break;
            case creditsState.Art:
                LText.text = "Game Art and           " +
                    " Story Development";
                cText.text = "Ashlyn Lancki @dancki_lancki       " +
                             "Charlotte Lancki";
                counter++;

                if (counter == 180)
                {
                    counter = 0;
                    LText.text = "";
                    cText.text = "";
                    currentState = creditsState.music;
                }
                break;
            case creditsState.music:
                LText.text = "Music Composition          " +
                    " and Arrangement";
                cText.text = "Mary Quigley @maryquigley04         " +
                             "Foster Beach @deeprooted_1           " +
                             "Ashlyn Lancki @dancki_lancki";
                counter++;

                if (counter == 190)
                {
                    counter = 0;
                    LText.text = "";
                    cText.text = "";
                    currentState = creditsState.emotionalSupport;
                }
                break;
            case creditsState.emotionalSupport:
                LText.text = "Technical Consultant";
                cText.text = "Benjamin Lancki";
                counter++;

                if (counter == 180)
                {
                    counter = 0;
                    LText.text = "";
                    cText.text = "";
                    currentState = creditsState.DanckiGamesLogo;
                }
                break;
            case creditsState.DanckiGamesLogo:

                
                StudioAnimation.SetActive(true);

                break;

        }
    }
}

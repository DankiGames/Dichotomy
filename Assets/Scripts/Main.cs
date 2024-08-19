using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Main : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [System.Serializable]
    public class CharacterInfo
    {
        public string name;
        public string skin;
        public string[] prompt;
        public string[] promptTwo;
        public string[] yes;
        public string[] no;
        public int place;
        public bool[] secondPrompt;
        public int[] goodPoint;
        public int[] badPoint;
        public int[] coins;
        public bool[] coinGiveOrTake;
        public bool[] yesOrNo;
        public bool[] point;
        public bool oneLiner;
        public bool done;
        public int lineNumber;
        public bool ready;
        public bool GoodChoice;
        public bool repetitive;
        public bool start;
        public bool saidYes;
        public bool specialCharacter;
        public bool[] takeEssance;
        public int[] essanceAmount;
    }

    [System.Serializable]
    public class Characters
    {
        public CharacterInfo[] characters; 
    }
   


    enum characterState 
    {
        start,
        randomizer,
        restockPoints,
        walkIn,
        promptOne,
        wait,
        promptOneCharacter2,
        promptTwo,
        answer,
        answerPrompt,
        addPoints,
        clickButton,
        flip,
        walkOut,
        stats,
        fadeAway,
        finish
    };

    

    public float speed = 2;
    public float speedCoins = 5f;
    public float speedEssance = 2;
    public float speedGoodBad = .3f;

    //Start game
    private bool startGame = true;

    
    //Text
    private GameObject characterDlog;
    private GameObject characterName;
    private GameObject statsText;
    private GameObject canvaseBox;
    private GameObject bad;
    private GameObject good;
    private GameObject goldCoins;
    private GameObject days;
    private GameObject essanceAmount;
    public GameObject instructions;
    public GameObject statsMenu;

    public Image panel;
    public Image moon;
    bool moonTrue = true;
    public Image fine;
    public Image doingGood;
    public Image great;
    public Image wonderful;
    public Image doingBad;
    public Image terrible;
    public Image horrible;
    public Image greyThing;
    public SpriteRenderer day;
    public SpriteRenderer night;
    public SpriteRenderer sunSet;
    public Button yes;
    public Button no;
    public Button click;
    public Button clickStats;
    public Button noEssence;
    public Button noCoins;

    private TextMeshProUGUI mText;
    private TextMeshProUGUI stats;
    private TextMeshProUGUI name;
    private TextMeshProUGUI badPoints;
    private TextMeshProUGUI goodPoints;
    private TextMeshProUGUI coinsText;
    private TextMeshProUGUI calander;
    private TextMeshProUGUI essance;

    public TextMeshProUGUI gText;
    public TextMeshProUGUI bText;
    public TextMeshProUGUI cText;
    public TextMeshProUGUI eText;
    public int fadeTime;

    int tempTally;

    int tempGoodTally;
    int tempBadTally;
    int tempCoinTally;
    int tempEssanceTally;

    int tempGTally;
    int tempGCounter;

    int tempBTally;
    int tempBCounter;
   
    int tempCTally;
    int tempCCounter;

    int tempETally;
    int tempECounter;

    bool villageBool = false;


    int currentGoodNumber;
    int currentBadNumber;
    int currentCoinsNumber;
    int currentEssanceNumber;

    bool check1 = false;
    bool check2 = false;
    bool check3 = false;
    bool check4 = false;
    bool buddy = false;

    bool bramAnswer = true;
    bool bramAdventure = false;

    int stupidCounter = 0;

    public int animationTime = 2;

    bool answerA = false;

    //SPECIAL CASE CHARACTERS
    int placementPrince = 0;
    int placementPrincess = 0;
    bool secondCharacter = false;
    bool noToHarmony = false;

    private string[] lines = new string[7];

    public Characters characterList;

    int goodTally = 0;
    int badTally = 0;
    int difference = 0;
    int coinTally = 0;
    int daysTally = 1;
    int essanceTally = 20;
    int numberOfCharacters = 0;
    int[] arrayOfCharacters = new int[7];
    int charMax = 40;
    int charMin = 3;
    float rY = 0;


    //Day cycle

    int dayCycleCounter = 1;

    const float minGood = -0.731257f;
    const float minBad = -0.5f;
    const float minCoin = 0.43f;
    const float minEssance = -1.71f;
    const float maxGood = 1.55f;
    const float maxBad = 2.00f;
    const float maxCoin = 3.15f;
    const float maxEssance = 0.3f;


    const int maxPoints = 200;
    const int maxCoins = 1000;
    const int maxEssancePoints = 20;
    const int maxDays = 31;

    private GameObject goodBar;
    private GameObject badBar;
    private GameObject coinsBar;
    private GameObject essanceBar;
    private Vector3 goodPosition = new Vector3(1.88f, minGood, 0);
    private Vector3 badPosition = new Vector3(7.89419f, minBad, 0);
    private Vector3 coinsPosition = new Vector3(4.8f, minCoin, 0);
    private Vector3 essancePosition = new Vector3(6.70f, minEssance, 0);
    
    private Vector3 goodPositionMAX = new Vector3(1.88f, maxGood, 0);
    private Vector3 badPositionMAX = new Vector3(7.89419f, maxBad, 0);
    private Vector3 coinsPositionMAX = new Vector3(4f, minCoin, 0);
    private Vector3 essancePositionMAX = new Vector3(6.70f, maxEssance, 0);

    //Character
    private GameObject character;
    private GameObject character2;
    int secondCharacterNumber;
    private characterState currentState;
    int rangeNumber;
    int currentPrompt;
    Sprite characterSkin;
    Sprite characterSkin2;

    //Movement 
    private Vector3 endPosition = new Vector3(-4, -2.5f, 0);
    private Vector3 leavingPosition = new Vector3(-14, -2.5f, 0);
    private Vector3 endPosition2 = new Vector3(-7, -2.5f, 0);
    private Vector3 leavingPosition2 = new Vector3(-17, -2.5f, 0);


    //Game over
    bool gameOver;
    int ending = 0;
    bool continuePumpPri = false;

    //Prompts
    int sillyIndex = 0;
    bool answerType = true;
    bool answerReady = true;
    bool flip = true;
    public float RotAngleY = 180;
    public float speedFlip = 5f;



    public SpriteRenderer bubbles;
    public SpriteRenderer village;
    public SpriteRenderer smoke1;
    public SpriteRenderer smoke2;
    public SpriteRenderer smoke3;
    public SpriteRenderer fairyDoor;
    public SpriteRenderer player1;
    public SpriteRenderer player2;
    public SpriteRenderer player3;

    private int currentNumber;

    bool buttonPressed;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        panel.gameObject.SetActive(false);

        gText.text = "";
        bText.text = "";
        cText.text = "";
        eText.text = "";

        tempETally = 20;

        TextAsset jsonFile;
        jsonFile = Resources.Load("Dialogue") as TextAsset;
        characterList = JsonUtility.FromJson<Characters>(jsonFile.text);
        

        currentState = characterState.start;
        gameOver = false;

        //Good vs. Bad points
        bad = GameObject.Find("BadPoints");
        good = GameObject.Find("GoodPoints");
        goldCoins = GameObject.Find("coins");
        statsText = GameObject.Find("Stats");
        days = GameObject.Find("days");
        essanceAmount = GameObject.Find("Essance");


        badPoints = bad.GetComponent<TextMeshProUGUI>();
        goodPoints = good.GetComponent<TextMeshProUGUI>();
        coinsText = goldCoins.GetComponent<TextMeshProUGUI>();
        stats = statsText.GetComponent<TextMeshProUGUI>();
        calander = days.GetComponent<TextMeshProUGUI>();
        essance = essanceAmount.GetComponent<TextMeshProUGUI>();

        badPoints.text = "0";
        goodPoints.text = "0";
        coinsText.text = "0";
        essance.text = "20";
        
        
        //Initialize the char array
        for(int I = 0; I<7; I++)
        {
            arrayOfCharacters[I] = -1;
        }

        fine.gameObject.SetActive(false);
        doingGood.gameObject.SetActive(false);
        great.gameObject.SetActive(false);
        wonderful.gameObject.SetActive(false);
        doingBad.gameObject.SetActive(false);
        terrible.gameObject.SetActive(false);
        horrible.gameObject.SetActive(false);
        greyThing.gameObject.SetActive(false);
        moon.gameObject.SetActive(false);


        goodBar = GameObject.Find("GoodBar");
        badBar = GameObject.Find("BadBar");
        coinsBar = GameObject.Find("CoinsBar");
        essanceBar = GameObject.Find("EssanceBar");


        goodBar.transform.position = goodPosition;
        badBar.transform.position = badPosition;
        coinsBar.transform.position = coinsPosition;
        essanceBar.transform.position = essancePositionMAX;

        fairyDoor.color = Color.clear;
        village.color = Color.clear;
        smoke1.color = Color.clear;
        smoke2.color = Color.clear;
        smoke3.color = Color.clear;
        moon.color = Color.white;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
    private void FadeTextOut(TextMeshProUGUI text)
    {
        if(fadeTime > 0)
        {
            fadeTime--;
            text.color = new Color(text.color.r, text.color.g, text.color.b, (float)fadeTime/60.0f);
        }
    }
    private void ChangeColor()
    {
        difference = goodTally - badTally;

        if (difference < 0)
        {
            difference = badTally - goodTally;
        }

        if (difference >= 0 && difference < 100)
        {
            bubbles.color = Color.white;
        }
        else if (goodTally >= 100)
        {
            bubbles.color = Color.green;
        }
        else if (badTally >= 100)
        {
            bubbles.color = Color.red;
        }

    }
    private void DisplayLine(string line)
    {
        
        char letter;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    mText.text = line;
        //    sillyIndex = line.Length-1;
        //}

        letter = line[sillyIndex];

        mText.text += letter;
        sillyIndex++;

       
  
    }
    private void GameOver()
    {
        bool neut = false;

        if(difference >= 0 && difference <= 25)
        {
            neut = true;
            characterList.characters[rangeNumber].place = 0;
            ending = 1;
        }
        else if ((neut == false) && (goodTally > badTally))
        {
            characterList.characters[rangeNumber].place = 1;
            ending = 2;
        }
        else if ((neut == false) && (badTally > goodTally))
        {
            characterList.characters[rangeNumber].place = 2;
            ending = 3;
        }
    }

    private void Wendle()
    {
        if(currentPrompt == 0)
        {
            characterList.characters[rangeNumber].done = true;
        }
      
    }
    private void Bram()
    {
        bool neut = false;
        int tempDif = goodTally - badTally;
        
        if(tempDif < 0)
        {
            tempDif = badTally - goodTally;
        }

        if(bramAdventure != true)
        {
            if ((currentPrompt == 0 || currentPrompt == 1))
            {
                characterList.characters[rangeNumber].place = 1;
            }
        }
        else // if no
        {
            if (tempDif >= 0 && tempDif <= 25)
            {
                characterList.characters[rangeNumber].place = 2;
                characterList.characters[rangeNumber].done = true;
            }
            else if ((neut == false) && (goodTally > badTally))
            {
                characterList.characters[rangeNumber].place = 3;
                characterList.characters[rangeNumber].done = true;
            }
            else if ((neut == false) && (badTally > goodTally))
            {
                characterList.characters[rangeNumber].place = 4;
                characterList.characters[rangeNumber].done = true;
            }
        }
    }

    private void Brook()
    {
        int r;

        if (answerA == true)
        {
            r = Random.Range(1, 3);

            if(r == 1)
            {
                characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] = true;
                answerType = true;
            }
            else if ( r == 2)
            {
                characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] = false;
                answerType = false;
            }
        }
    }
    private void PunyBrain ()
    {
        if(characterList.characters[rangeNumber].saidYes == false && currentPrompt == 1)
        {
            characterList.characters[rangeNumber].done = true;
        }

        if(characterList.characters[rangeNumber].saidYes == true && currentPrompt == 2)
        {
            moon.color = Color.clear;
            moonTrue = false;
            characterList.characters[rangeNumber].done = true;
        }
        
        if(characterList.characters[rangeNumber].saidYes == false && currentPrompt == 3)
        {
            characterList.characters[rangeNumber].place = 3;
        }
        else if (characterList.characters[rangeNumber].saidYes == true && currentPrompt == 3)
        {
            moon.color = Color.clear;
            moonTrue = false;
            characterList.characters[rangeNumber].done = true;
        }
    }
    private void Harmony ()
    {
        if (currentPrompt == 0 && noToHarmony == false)
        {
            characterList.characters[rangeNumber].place = 2; 
        }
        else if ((currentPrompt == 0 || currentPrompt == 1) && noToHarmony == true)
        {
            characterList.characters[rangeNumber].place = 1;
        }

        characterList.characters[rangeNumber].start = false;

    }
    private void RepeatCharacter()
    {
        if ((characterList.characters[rangeNumber].place) > characterList.characters[rangeNumber].lineNumber)
        {
            int nextPrompt = Random.Range(1, characterList.characters[rangeNumber].lineNumber);

            characterList.characters[rangeNumber].place = nextPrompt;
        }
    }
    private void OneLiner()
    {

       characterList.characters[rangeNumber].place = 1;
        
    }
    private void PrinceAndPrincess ()
    {
        if(placementPrincess != 3)
        {

            if(rangeNumber == 1)
            {
                currentPrompt = placementPrincess;
                characterList.characters[rangeNumber].ready = false;
                characterList.characters[2].ready = true;
                placementPrincess++;
            }
            else
            {
                if((characterList.characters[1].GoodChoice == true)&& (characterList.characters[1].place == 1))
                {
                    placementPrince = 1; 
                }
                else if ((characterList.characters[1].GoodChoice == false) && (characterList.characters[1].place == 1))
                {
                    placementPrince = 2;
                }
                currentPrompt = placementPrince;
                characterList.characters[rangeNumber].ready = false;
                characterList.characters[1].ready = true;

                characterList.characters[rangeNumber].done = true;
                characterList.characters[1].done = true;

                if (placementPrince == 1 || placementPrince == 2)
                {
                    placementPrince = 3;
                }
            }
        }
        else
        {
            secondCharacter = true;

            // characterSkin = Resources.Load<Sprite>(characterList.characters[6].skin);
            characterSkin2 = Resources.Load<Sprite>(characterList.characters[1].skin);
            character2 = GameObject.Find("Character2");
            character2.AddComponent<SpriteRenderer>();
            character2.GetComponent<SpriteRenderer>().sprite = characterSkin2;

            character2.transform.position = leavingPosition2;
            character2.transform.localRotation = Quaternion.Euler(0, 0, 0);

            secondCharacterNumber = 1;
            currentPrompt = placementPrince;
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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


    public void PointSystem (bool answerA)
    {
        coins(answerA);
        Essance(answerA);
        tempGoodTally = goodTally;
        tempBadTally = badTally;
        int tempAddingNumber = 0;
        int tempSubNumber = 0;

        //yes
        if (answerA == true)
        {
            //Yes answer 
            if(characterList.characters[rangeNumber].point[currentPrompt] == true) //Yes means good
            {
                //good add points


                goodTally += characterList.characters[rangeNumber].goodPoint[currentPrompt];
                if (goodTally >= 200 && rangeNumber != 40) //MAKE CONST
                {
                    if(tempGoodTally != 200)
                    {
                        if(goodTally + characterList.characters[rangeNumber].goodPoint[currentPrompt] > 200)
                        {
                            tempAddingNumber = (200 - tempGoodTally);
                            gText.text = "+" + (tempAddingNumber).ToString();

                            if (goodTally >= 200)
                            {
                                goodTally = 200;
                            }
                        }
                    }
                    else
                    {
                        goodTally = 200;
                        gText.text = "";
                    }

                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        gText.text = "+" + characterList.characters[rangeNumber].goodPoint[currentPrompt].ToString();
                    }
                    
                }
        

                //Bad take away
                badTally -= characterList.characters[rangeNumber].badPoint[currentPrompt];
                if(badTally <= 0 && rangeNumber != 40)
                {
                    if(tempBadTally != 0)
                    {
                        if(badTally - characterList.characters[rangeNumber].badPoint[currentPrompt] < 0)
                        {
                            tempSubNumber = characterList.characters[rangeNumber].badPoint[currentPrompt] - tempBadTally;
                            bText.text = "-" + (characterList.characters[rangeNumber].badPoint[currentPrompt] - tempSubNumber).ToString();
                        }
                    }
                    else
                    {
                        badTally = 0;
                        bText.text = "";
                    }

                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        bText.text = "-" + characterList.characters[rangeNumber].badPoint[currentPrompt].ToString();
                    }
                   
                }


            }
            else
            {
                //good take away
                goodTally -= characterList.characters[rangeNumber].goodPoint[currentPrompt];
                if (goodTally <= 0 && rangeNumber != 40) //MAKE CONST
                {
                    if (tempGoodTally != 0)
                    {
                        if (goodTally - characterList.characters[rangeNumber].goodPoint[currentPrompt] < 0)
                        {
                            tempSubNumber = characterList.characters[rangeNumber].goodPoint[currentPrompt] - tempGoodTally;
                            gText.text = "-" + (characterList.characters[rangeNumber].goodPoint[currentPrompt] - tempSubNumber).ToString();
                        }
                    }
                    else
                    {
                        goodTally = 0;
                        gText.text = "";
                    }

                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        gText.text = "-" + characterList.characters[rangeNumber].goodPoint[currentPrompt].ToString();
                    }
                   
                }

                //Bad Add away
                badTally += characterList.characters[rangeNumber].badPoint[currentPrompt];
                if (badTally >= 200 && rangeNumber != 40)
                {
                    if (tempBadTally != 200)
                    {
                        if (badTally + characterList.characters[rangeNumber].badPoint[currentPrompt] > 200)
                        {
                            tempAddingNumber = (200 - tempBadTally);
                            bText.text = "+" + (tempAddingNumber).ToString();

                            if (badTally >= 200)
                            {
                                badTally = 200;
                            }
                        }
                    }
                    else
                    {
                        badTally = 200;
                        bText.text = "";
                    }
     
                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        bText.text = "+" + characterList.characters[rangeNumber].badPoint[currentPrompt].ToString();
                    }
                    
                }

            }


        }
        //no
        else 
        {
            //No answer 
            if (characterList.characters[rangeNumber].point[currentPrompt] == true) //Yes means good
            {
                //good take away
                goodTally -= characterList.characters[rangeNumber].goodPoint[currentPrompt];
                if (goodTally <= 0 && rangeNumber != 40) //MAKE CONST
                {
                    if (tempGoodTally != 0)
                    {
                        if (goodTally - characterList.characters[rangeNumber].goodPoint[currentPrompt] < 0)
                        {
                            tempSubNumber = characterList.characters[rangeNumber].goodPoint[currentPrompt] - tempGoodTally;
                            gText.text = "-" + (characterList.characters[rangeNumber].goodPoint[currentPrompt] - tempSubNumber).ToString();
                        }
                    }
                    else
                    {
                        goodTally = 0;
                        gText.text = "";
                    }
                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        gText.text = "-" + characterList.characters[rangeNumber].goodPoint[currentPrompt].ToString();
                    }
                    
                }


                //Bad Add away
                badTally += characterList.characters[rangeNumber].badPoint[currentPrompt];
                if (badTally >= 200 && rangeNumber != 40)
                {
                    if (tempBadTally != 200)
                    {
                        if (badTally + characterList.characters[rangeNumber].badPoint[currentPrompt] > 200)
                        {
                            tempAddingNumber = (200 - tempBadTally);
                            bText.text = "+" + (tempAddingNumber).ToString();

                            if (badTally >= 200)
                            {
                                badTally = 200;
                            }
                        }
                    }
                    else
                    {
                        badTally = 200;
                        bText.text = "";
                    }

                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        bText.text = "+" + characterList.characters[rangeNumber].badPoint[currentPrompt].ToString();
                    }
                   
                }

            }
            else
            {
                //good add points
                goodTally += characterList.characters[rangeNumber].goodPoint[currentPrompt];

                if (goodTally >= 200 && rangeNumber != 40) //MAKE CONST
                {
                    if (tempGoodTally != 200)
                    {
                        if (goodTally + characterList.characters[rangeNumber].goodPoint[currentPrompt] > 200)
                        {
                            tempAddingNumber = (200 - tempGoodTally);
                            gText.text = "+" + (tempAddingNumber).ToString();

                            if (goodTally >= 200)
                            {
                                goodTally = 200;
                            }
                        }
                    }
                    else
                    {
                        goodTally = 200;
                        gText.text = "";
                    }
                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        gText.text = "+" + characterList.characters[rangeNumber].goodPoint[currentPrompt].ToString();
                    }
                }


                //Bad take away
                badTally -= characterList.characters[rangeNumber].badPoint[currentPrompt];
                if (badTally <= 0 && rangeNumber != 40)
                {
                    if (tempBadTally != 0)
                    {
                        if (badTally - characterList.characters[rangeNumber].badPoint[currentPrompt] < 0)
                        {
                            tempSubNumber = characterList.characters[rangeNumber].badPoint[currentPrompt] - tempBadTally;
                            bText.text = "-" + (characterList.characters[rangeNumber].badPoint[currentPrompt] - tempSubNumber).ToString();
                        }
                    }
                    else
                    {
                        badTally = 0;
                        bText.text = "";
                    }
                }
                else
                {
                    if(rangeNumber != 40)
                    {
                        bText.text = "-" + characterList.characters[rangeNumber].badPoint[currentPrompt].ToString();
                    }
                }
 
              
            }


        }

        BarUpdate();
    }

    public void Yes ()
    {
        answerType = true;
        answerA = true;
        

        if(rangeNumber == 34 && (currentPrompt == 0|| currentPrompt == 1))
        {
            bramAnswer = true;
            bramAdventure = true;
        }

        if (rangeNumber == 11)
        {
            Brook();
        }
        if (rangeNumber == 15 && currentPrompt == 0)
        {
            villageBool = true;
        }


        PointSystem(answerA);

        if (rangeNumber == 1 && currentPrompt == 1)
        {
            characterList.characters[rangeNumber].GoodChoice = false;
        }
        if (rangeNumber == 25 && (currentPrompt == 0 || currentPrompt == 1))
        {
            noToHarmony = false;
        }
        if ((rangeNumber == 24) && (currentPrompt == 1 || currentPrompt == 2 || currentPrompt == 3))
        {
            characterList.characters[rangeNumber].saidYes = true;
        }
  

        if (goodTally < 0)
        {
            goodTally = 0;
        }


        if (badTally < 0)
        {
            badTally = 0;
        }

        currentState = characterState.answerPrompt;
        

        
    }
    public void No()
    {

        answerType = false;

        answerA = false;

        if (rangeNumber == 34 && (currentPrompt == 0 || currentPrompt == 1))
        {
            bramAnswer = false;
        }


        PointSystem(answerA);

        if (rangeNumber == 1 && currentPrompt == 1)
        {
            characterList.characters[rangeNumber].GoodChoice = true;
        }
        if (rangeNumber == 25 && (currentPrompt == 0 || currentPrompt == 1))
        {
            noToHarmony = true;
        }
        if ((rangeNumber == 24) && (currentPrompt == 1 || currentPrompt == 2 || currentPrompt == 3))
        {
            characterList.characters[rangeNumber].saidYes = false;
        }
        if (rangeNumber == 12)
        {
            characterList.characters[rangeNumber].done = true;
        }
        if (rangeNumber == 15)
        {
            Wendle();
        }
        if(rangeNumber == 38 && currentPrompt == 0)
        {
            characterList.characters[rangeNumber].done = true;
        }


        if (goodTally < 0)
        {
            goodTally = 0;
           
        }

        if (badTally < 0)
        {

            badTally = 0;
        }

        currentState = characterState.answerPrompt;


    }

    public void BarUpdate ()
    {
        float newBarValue;

        newBarValue = minGood + ((maxGood - minGood) * ((float)goodTally / (float)maxPoints));
        goodPosition.y = newBarValue;

  


        newBarValue = minBad + ((maxBad - minBad) * ((float)badTally / (float)maxPoints));
        badPosition.y = newBarValue;



        newBarValue = minCoin + ((maxCoin - minCoin) * ((float)coinTally / (float)maxCoins));
        coinsPosition.y = newBarValue;



        newBarValue = minEssance + ((maxEssance - minEssance) * ((float)essanceTally / (float)maxEssancePoints));
        essancePosition.y = newBarValue;

        
    }

    public void coins(bool answerA)
    {
        tempCoinTally = coinTally;
        int tempSubNumber = 0;

        //If yes 
        if(answerA == true)
        {
            //If true then adding to the wallet
            if(characterList.characters[rangeNumber].coins[currentPrompt] != 0)
            {
                if (characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] == true)
                {
                    coinTally += characterList.characters[rangeNumber].coins[currentPrompt];
                    cText.text = "+" + characterList.characters[rangeNumber].coins[currentPrompt].ToString();
                }
                else // else false and taking from wallet
                {

                    coinTally -= characterList.characters[rangeNumber].coins[currentPrompt];
                    if (coinTally <= 0)
                    {
                        if (tempCoinTally != 0)
                        {
                            if (coinTally - characterList.characters[rangeNumber].coins[currentPrompt] < 0)
                            {
                                tempSubNumber = characterList.characters[rangeNumber].coins[currentPrompt] - tempCoinTally;
                                cText.text = "-" + (characterList.characters[rangeNumber].coins[currentPrompt] - tempSubNumber).ToString();
                            }
                        }
                        else
                        {
                            coinTally = 0;
                            cText.text = "";
                        }

                    }
                    else
                    {
                        cText.text = "-" + characterList.characters[rangeNumber].coins[currentPrompt].ToString();
                    }



                }
            }
            else
            {
                cText.text = "";
            }


        }
        else
        {
            coinTally += 0;
        }

        if (coinTally <= 0)
        {
            coinTally = 0;
        }

    }

    public void Essance(bool answerA)
    {
        tempEssanceTally = essanceTally;
        int tempSubNumber = 0;
        int tempAddNumber = 0;
        //If yes 
        if (answerA == true)
        {
            //If true then adding to the essance wallet
            if (characterList.characters[rangeNumber].essanceAmount[currentPrompt] != 0)
            {
                if ((characterList.characters[rangeNumber].takeEssance[currentPrompt] == false))
                {
                    essanceTally += characterList.characters[rangeNumber].essanceAmount[currentPrompt];
                    if (essanceTally >= maxEssancePoints)
                    {
                        if (tempEssanceTally != maxEssancePoints)
                        {
                            if (tempEssanceTally + characterList.characters[rangeNumber].essanceAmount[currentPrompt] > maxEssancePoints)
                            {
                                tempAddNumber = (maxEssancePoints - tempEssanceTally);
                                eText.text = "+" + (tempAddNumber).ToString();

                                if (essanceTally >= maxEssancePoints)
                                {
                                    essanceTally = maxEssancePoints;
                                }
                            }
                        }
                        else
                        {
                            essanceTally = maxEssancePoints;
                            eText.text = "";
                        }

                    }
                    else
                    {
                        eText.text = "+" + characterList.characters[rangeNumber].essanceAmount[currentPrompt].ToString();
                    }
                }
                else // else false and taking from wallet
                {

                    essanceTally -= characterList.characters[rangeNumber].essanceAmount[currentPrompt];

                    if (essanceTally <= 0)
                    {
                        if (tempEssanceTally != 0)
                        {
                            if (essanceTally - characterList.characters[rangeNumber].essanceAmount[currentPrompt] < 0)
                            {
                                tempSubNumber = characterList.characters[rangeNumber].essanceAmount[currentPrompt] - tempEssanceTally;
                                eText.text = "-" + (characterList.characters[rangeNumber].essanceAmount[currentPrompt] - tempSubNumber).ToString();
                            }
                        }
                        else
                        {
                            essanceTally = 0;
                            eText.text = "";
                        }

                    }
                    else
                    {
                        if (characterList.characters[rangeNumber].essanceAmount[currentPrompt] == 0)
                        {
                            eText.text = "";
                        }
                        else
                        {
                            eText.text = "-" + characterList.characters[rangeNumber].essanceAmount[currentPrompt].ToString();
                        }

                    }

                }
            }
                
           
        }
        else
        {
            essanceTally += 0;
        }

    }
    private void Stats(int goodTally, int badTally, Image greyThing, Image fine, Image doingGood, Image great, Image wonderful, Image doingBad, Image terrible, Image horrible)
    {
        //((goodTally >= 0 && goodTally <= 20) && (badTally >= 0 && badTally <= 20))
        difference = goodTally - badTally;

        if (difference < 0)
        {
            difference = badTally - goodTally;
        }

        greyThing.gameObject.SetActive(true);
        moon.gameObject.SetActive(true);
        clickStats.gameObject.SetActive(true);
        statsMenu.gameObject.SetActive(true);

        if (goodTally > badTally) // going down good path
        {
            //Normal
            if (difference >= 0 && difference <= 50)
            {
                fine.gameObject.SetActive(true);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(false);

                if(moonTrue == true)
                {
                    stats.text = "The world is doing fine. Not good not bad just fine.";
                    
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }
               
            }
            //Good
            else if ((goodTally > 25 && goodTally <= 65))
            {
                fine.gameObject.SetActive(false);
                doingGood.gameObject.SetActive(true);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(false);
                if (moonTrue == true)
                {
                    if (goodTally <= 40)
                    {
                        stats.text = "The world looks a little brighter.";

                    }
                    else if (goodTally <= 65 && goodTally > 40)
                    {
                        stats.text = "The world is on the mend. You're heading down a good path.";
                    }
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }
               
            }
            //Great
            else if ((goodTally > 65 && goodTally <= 180))
            {
                fine.gameObject.SetActive(false);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(true);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(false);
                if (moonTrue == true)
                {
                    if (goodTally <= 100)
                    {
                        stats.text = "Is the world glowing? It looks kind of pretty.";
                    }
                    else if (goodTally <= 150 && goodTally > 100)
                    {
                        stats.text = "The world has grown a little. It's reaching it's full potential!";
                    }
                    else if (goodTally > 150 && goodTally <= 180)
                    {
                        stats.text = "The world continues to grow and change. For the better right?";
                    }
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }

              
            }
            //Wonderful
            else if (goodTally > 180)
            {
                fine.gameObject.SetActive(false);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(true);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(false);
                if (moonTrue == true)
                {
                    if (goodTally <= 199)
                    {
                        stats.text = "The world has grown a little. It's reaching its full potential! But is it becoming too powerful?";
                    }
                    else if (goodTally >= 200)
                    {
                        stats.text = "The world has reached maximum goodness and prosperity! but for some reason this feels wrong...";
                    }
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }

               
            }
        }
        else
        {
            //Normal
            if (difference >= 0 && difference <= 50)
            {
                fine.gameObject.SetActive(true);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(false);

                if (moonTrue == true)
                {
                    stats.text = "The world is doing fine. Not good not bad just fine.";
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }

               
            }
            //bad
            else if (badTally > 25 && badTally <= 65)
            {

                fine.gameObject.SetActive(false);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(true);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(false);
                if (moonTrue == true)
                {
                    if (badTally <= 40)
                    {
                        stats.text = "The world seems dull. Maybe it's just the lighting?";
                    }
                    else if (badTally <= 65 && badTally > 40)
                    {
                        stats.text = "The world seems sad. Is this the right path?";
                    }
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }

               
            }
            //terrible
            else if (badTally > 65 && badTally <= 180)
            {
                fine.gameObject.SetActive(false);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(true);
                horrible.gameObject.SetActive(false);
                if (moonTrue == true)
                {
                    if (badTally <= 100)
                    {
                        stats.text = "The world is dying.";
                    }
                    else if (badTally <= 150 && badTally > 100)
                    {
                        stats.text = "Is that fire? That can't be good.";
                    }
                    else if (badTally > 150 && badTally <= 180)
                    {
                        stats.text = "The world continued to slowly fall in to chaos.";
                    }
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }

               
            }
            //horrible
            else if (badTally > 180)
            {
                fine.gameObject.SetActive(false);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(true);

                if (moonTrue == true)
                {
                    if (badTally <= 199)
                    {
                        stats.text = "The world has been engulfed into flame and hatred.";
                    }
                    else if (badTally >= 200)
                    {
                        stats.text = "The world has reached maximum destruction. It's only a matter of time now until the world falls apart. Is this what we truly wanted?";
                    }
                }
                else
                {
                    stats.text = "The moons gone... that probably wasn't important anyway.";
                    moonTrue = true;
                }

              
            }

        }
    }

    void Update()
    {

        switch (currentState)
        {
            case characterState.start:                          //*******START********//
                sillyIndex = 0;

                gText.text = "";
                bText.text = "";
                cText.text = "";
                eText.text = "";
                fadeTime = 240;

                gText.alpha = 1;
                bText.alpha = 1;
                cText.alpha = 1;
                eText.alpha = 1;

                answerReady = true;

                //Set all stat panels to false 
                yes.gameObject.SetActive(false);
                noCoins.gameObject.SetActive(false);
                noEssence.gameObject.SetActive(false);
                no.gameObject.SetActive(false);
                click.gameObject.SetActive(false);
                clickStats.gameObject.SetActive(false);

                fine.gameObject.SetActive(false);
                doingGood.gameObject.SetActive(false);
                great.gameObject.SetActive(false);
                wonderful.gameObject.SetActive(false);
                doingBad.gameObject.SetActive(false);
                terrible.gameObject.SetActive(false);
                horrible.gameObject.SetActive(false);
                greyThing.gameObject.SetActive(false);
                moon.gameObject.SetActive(false);

                check1 = false;
                check2 = false;
                check3 = false;
                check4 = false;

                player2.color = Color.clear;
                player3.color = Color.clear;
                player1.color = Color.white;
                fairyDoor.color = Color.clear;

                calander.text = daysTally.ToString();

                //if(instructions.activeInHierarchy == false)
                //{
                    if (dayCycleCounter == 1)
                    {
                        ChangeColor();
                        StartCoroutine(FadeOut(night));
                        StartCoroutine(FadeIn(day));

                        if (startGame == false)
                        {
                            if (essanceTally < maxEssancePoints)
                            {
                                essanceTally += ((maxEssancePoints - essanceTally) / 2);
                                essance.text = essanceTally.ToString();
                                BarUpdate();

                                buddy = true;
                            }
                        }
                    }
                    if (dayCycleCounter == 2)
                    {
                        StartCoroutine(FadeOut(day));
                        StartCoroutine(FadeIn(sunSet));
                    }
                    if (dayCycleCounter == 3)
                    {
                        StartCoroutine(FadeOut(sunSet));
                        StartCoroutine(FadeIn(night));
                        daysTally++;
                    }
                //}

                currentState = characterState.randomizer;

                break;
            case characterState.randomizer:
                if (instructions.activeInHierarchy == false)
                {
                    //Rand character 

                    // Standard rand character
                   
                    if (coinTally <= 100)
                    {
                        rangeNumber = Random.Range(5, 15);
                        if ((rangeNumber == arrayOfCharacters[0] ||
                               rangeNumber == arrayOfCharacters[1] ||
                               rangeNumber == arrayOfCharacters[2] ||
                               rangeNumber == arrayOfCharacters[3] ||
                               characterList.characters[rangeNumber].done == true))
                        {
                            break;
                        }

                    }
                    else if (coinTally >= 300)
                    {
                        rangeNumber = Random.Range(15, 28);

                        if ((rangeNumber == arrayOfCharacters[0] ||
                               rangeNumber == arrayOfCharacters[1] ||
                               rangeNumber == arrayOfCharacters[2] ||
                               rangeNumber == arrayOfCharacters[3] ||
                               characterList.characters[rangeNumber].done == true))
                        {
                            break;
                        }
                    }
                    else
                    {
                        rangeNumber = Random.Range(charMin, charMax);
                        // If  char is done, reroll

                        if ((rangeNumber == arrayOfCharacters[0] ||
                               rangeNumber == arrayOfCharacters[1] ||
                               rangeNumber == arrayOfCharacters[2] ||
                               rangeNumber == arrayOfCharacters[3] || 
                               characterList.characters[rangeNumber].done == true))
                        {
                            // rangeNumber = Random.Range(charMin, charMax);
                            break;
                        }
                   
                    }

                    //If start of the game or 3rd day mushy comes out
                    if (startGame == true || (daysTally == 3 && dayCycleCounter == 1))
                    {
                        rangeNumber = 0;
                    }

                    //If end of the game
                    if (gameOver == true)
                    {
                        rangeNumber = 40;
                        GameOver();
                    }

                    //Taking care of Prince Pump and Pancake ending since it was too hard to get in 31 days
                    if ((daysTally == 5 && dayCycleCounter == 1) && continuePumpPri == false)
                    {
                        rangeNumber = 1; //Prompt 0 Princess
                        PrinceAndPrincess();
                    }
                    else if (((daysTally == 10 && dayCycleCounter == 3) && badTally >= 50) && continuePumpPri == false)
                    {
                        rangeNumber = 2; //Prompt 0 Prince
                        continuePumpPri = true;
                        PrinceAndPrincess();
                    }
                    if (continuePumpPri == true)
                    {
                        if (((daysTally == 15 && dayCycleCounter == 1)))
                        {
                            rangeNumber = 1; // Prompt 1 princess
                            PrinceAndPrincess();
                        }
                        else if ((daysTally == 20 && dayCycleCounter == 3))
                        {
                            rangeNumber = 2; //Prompt 1/2 prince
                            PrinceAndPrincess();
                            if (characterList.characters[1].GoodChoice == true)
                            {
                                characterList.characters[2].place = 2;
                            }
                            else
                            {
                                characterList.characters[2].place = 1;
                            }
                        }
                        else if (((daysTally == 25 && dayCycleCounter == 1)))
                        {
                            rangeNumber = 1; //Prompt 2 last before double scene
                            PrinceAndPrincess();
                        }
                        else if ((((daysTally == 30 && dayCycleCounter == 3))))
                        {
                            rangeNumber = 2; //Prompt 3 for both double scene
                            characterList.characters[2].ready = true;
                            characterList.characters[1].ready = true;

                            PrinceAndPrincess();
                            characterList.characters[2].place = 3;
                        }
                    }



                    //Puny Brain
                    if (rangeNumber == 24 && characterList.characters[rangeNumber].done != true)
                    {
                        if ((daysTally == 13 && dayCycleCounter == 3) && characterList.characters[24].place == 0)
                        {
                            rangeNumber = 24;
                        }
                        else if ((daysTally == 22 && dayCycleCounter == 3) && characterList.characters[24].place == 1)
                        {
                            rangeNumber = 24;
                        }
                        else if ((daysTally == 28 && dayCycleCounter == 3) && characterList.characters[24].place == 2)
                        {
                            rangeNumber = 24;
                        }
                    }

                    //For Bram
                    if (rangeNumber == 34)
                    {
                        Bram();
                    }
                    else if((characterList.characters[34].place > 1 && (daysTally == 27 && dayCycleCounter == 2)) && characterList.characters[34].done != true)
                    {
                        rangeNumber = 34;
                        bramAdventure = true;
                        Bram();
                    }

                    
                    //Sets the currentPrompt
                    currentPrompt = characterList.characters[rangeNumber].place;


                    //Puts characters into the array
                    arrayOfCharacters[numberOfCharacters] = rangeNumber;
                    numberOfCharacters++;

                    //character skin
                    characterSkin = Resources.Load<Sprite>(characterList.characters[rangeNumber].skin);
                    character = GameObject.Find("Character");
                    character.AddComponent<SpriteRenderer>();
                    character.GetComponent<SpriteRenderer>().sprite = characterSkin;

                    //character dlog box and name
                    characterDlog = GameObject.Find("DialogText");
                    characterName = GameObject.Find("NameText");
                    mText = characterDlog.GetComponent<TextMeshProUGUI>();
                    name = characterName.GetComponent<TextMeshProUGUI>();

                    //Sets character in position off screen
                    character.transform.position = leavingPosition;
                    character.transform.localRotation = Quaternion.Euler(0, 0, 0);


                    //Sets the dialog to blank
                    // characterDlog.SetActive(false);
                    //mText.enabled = false;
                    mText.text = "";
                    name.text = "";
                    stats.text = "";

                    currentState = characterState.restockPoints;                  //*******WALK IN********//
                }

                break;
            case characterState.restockPoints:

                if (buddy == true)
                {
                    if (Vector3.Distance(essanceBar.transform.position, essancePosition) > 0.001f)//(essanceBar.transform.position != essancePosition)
                    {
                        essanceBar.transform.position = Vector3.MoveTowards(essanceBar.transform.position, essancePosition, speedEssance * Time.deltaTime);
                    }
                    else
                    {
                        buddy = false;
                        currentState = characterState.walkIn;
                    }
                }
                else
                {
                    currentState = characterState.walkIn;
                }
               
                break;
            case characterState.walkIn:

                if (rangeNumber == 10 || rangeNumber == 29 || rangeNumber == 1)
                {
                    fairyDoor.color = Color.white;
                }
                //character walking into position
                if (secondCharacter == true) //If there's a second character
                {
                    if (Vector3.Distance(character2.transform.position, endPosition2) > 0.001f)//(character2.transform.position != endPosition2) // move the second character to the correct position
                    {
                        character2.transform.position = Vector3.MoveTowards(character2.transform.position, endPosition2, speed * Time.deltaTime);
                    }
                }
                if (Vector3.Distance(character.transform.position, endPosition) > 0.001f)//(character.transform.position != endPosition)
                {
                    character.transform.position = Vector3.MoveTowards(character.transform.position, endPosition, speed * Time.deltaTime);
                }
                else
                {
                    mText.text = "";
                    sillyIndex = 0;
                    currentState = characterState.promptOne;
                }



                break;
            case characterState.promptOne:                            //*******PROMPT ONE********//
     
                //Scroll appears
                panel.gameObject.SetActive(true);
                //name
                name.text = characterList.characters[rangeNumber].name;

                player1.color = Color.clear;
                player2.color = Color.white;
                player3.color = Color.clear;
                


                if (sillyIndex < characterList.characters[rangeNumber].prompt[currentPrompt].Length)
                {

                    DisplayLine(characterList.characters[rangeNumber].prompt[currentPrompt]);
                  
                }
                else
                {

                    if (secondCharacter != true)
                    {


                        if (characterList.characters[rangeNumber].secondPrompt[currentPrompt] == true)
                        {
                            if ((sillyIndex >= characterList.characters[rangeNumber].prompt[currentPrompt].Length - 1))
                            {
                                //If there's a second prompt


                                click.gameObject.SetActive(true);
                                if ((Input.GetKey(KeyCode.Return)) || (Input.GetMouseButtonDown(0)))
                                {
                                    mText.text = "";
                                    sillyIndex = 0;
                                    click.gameObject.SetActive(false);
                                    currentState = characterState.promptTwo;
                                }


                            }


                        }
                        else if (characterList.characters[rangeNumber].secondPrompt[currentPrompt] == false)
                        {
                            if ((sillyIndex >= characterList.characters[rangeNumber].prompt[currentPrompt].Length - 1))
                            {
                                if ((characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] == true) ||
                                  ((coinTally >= characterList.characters[rangeNumber].coins[currentPrompt]) && (characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] == false)))
                                {
                                    if ((characterList.characters[rangeNumber].takeEssance[currentPrompt] == false) ||
                                       ((essanceTally >= characterList.characters[rangeNumber].essanceAmount[currentPrompt]) && (characterList.characters[rangeNumber].takeEssance[currentPrompt] == true)))
                                    {
                                        if (((essanceTally >= characterList.characters[rangeNumber].essanceAmount[currentPrompt]) && (characterList.characters[rangeNumber].takeEssance[currentPrompt] == true)) || (characterList.characters[rangeNumber].takeEssance[currentPrompt] == false))
                                        {
                                            yes.gameObject.SetActive(true);
                                            no.gameObject.SetActive(true);
                                            click.gameObject.SetActive(false);
                                        }
                                        else
                                        {

                                            yes.gameObject.SetActive(false);
                                            noEssence.gameObject.SetActive(true);
                                            noCoins.gameObject.SetActive(false);
                                            no.gameObject.SetActive(true);
                                            click.gameObject.SetActive(false);

                                        }
                                    }
                                    else
                                    {
                                        yes.gameObject.SetActive(false);
                                        noEssence.gameObject.SetActive(true);
                                        noCoins.gameObject.SetActive(false);
                                        no.gameObject.SetActive(true);
                                        click.gameObject.SetActive(false);
                                    }

                                }
                                else
                                {

                                    yes.gameObject.SetActive(false);
                                    noCoins.gameObject.SetActive(true);
                                    noEssence.gameObject.SetActive(false);
                                    no.gameObject.SetActive(true);
                                    click.gameObject.SetActive(false);

                                }

                                //If theirs not then go to answer 
                                currentState = characterState.answer;
                            }

                        }

                    }
                    else
                    {
                        if ((sillyIndex >= characterList.characters[rangeNumber].prompt[currentPrompt].Length - 1))
                        {
                            click.gameObject.SetActive(true);
                            if ((Input.GetKey(KeyCode.Return)) || (Input.GetMouseButtonDown(0)))
                            {
                                //mText.enabled = false;
                                mText.text = "";
                                sillyIndex = 0;
                                currentState = characterState.promptOneCharacter2;
                            }
                        }
                    }
                }
               
                

                
                break;
            case characterState.promptOneCharacter2:                    //************Character Two**********//
              

                name.text = characterList.characters[secondCharacterNumber].name;

                if (sillyIndex < characterList.characters[secondCharacterNumber].prompt[3].Length)
                {

                    DisplayLine(characterList.characters[secondCharacterNumber].prompt[3]);

                }
                else
                {
                    if ((sillyIndex >= characterList.characters[rangeNumber].prompt[currentPrompt].Length - 1))
                    {
                        //If there's a second prompt


                        click.gameObject.SetActive(true);
                        if ((Input.GetKey(KeyCode.Return)) || (Input.GetMouseButtonDown(0)))
                        {
                            mText.text = "";
                            sillyIndex = 0;
                            currentState = characterState.promptTwo;
                        }
                    }
                }


 
 
                break;
                
            case characterState.promptTwo:                                //*******PROMPT TWO********//
           

                if (secondCharacter == true)
                {
                    name.text = characterList.characters[2].name;
                }

                if (sillyIndex < characterList.characters[rangeNumber].promptTwo[currentPrompt].Length)
                {
                    DisplayLine(characterList.characters[rangeNumber].promptTwo[currentPrompt]);
                }
                else
                {
                    if ((sillyIndex >= characterList.characters[rangeNumber].promptTwo[currentPrompt].Length - 1))
                    {
                        if ((characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] == true) ||
                                  ((coinTally >= characterList.characters[rangeNumber].coins[currentPrompt]) && (characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] == false)))
                        {
                            if ((characterList.characters[rangeNumber].takeEssance[currentPrompt] == false) ||
                               ((essanceTally >= characterList.characters[rangeNumber].essanceAmount[currentPrompt]) && (characterList.characters[rangeNumber].takeEssance[currentPrompt] == true)))
                            {
                                if (((essanceTally >= characterList.characters[rangeNumber].essanceAmount[currentPrompt]) && (characterList.characters[rangeNumber].takeEssance[currentPrompt] == true)) || (characterList.characters[rangeNumber].takeEssance[currentPrompt] == false))
                                {
                                    yes.gameObject.SetActive(true);
                                    no.gameObject.SetActive(true);
                                    click.gameObject.SetActive(false);
                                }
                                else
                                {

                                    yes.gameObject.SetActive(false);
                                    noEssence.gameObject.SetActive(true);
                                    noCoins.gameObject.SetActive(false);
                                    no.gameObject.SetActive(true);
                                    click.gameObject.SetActive(false);

                                }
                            }
                            else
                            {
                                yes.gameObject.SetActive(false);
                                noEssence.gameObject.SetActive(true);
                                noCoins.gameObject.SetActive(false);
                                no.gameObject.SetActive(true);
                                click.gameObject.SetActive(false);
                            }

                        }
                        else
                        {

                            yes.gameObject.SetActive(false);
                            noEssence.gameObject.SetActive(false);
                            noCoins.gameObject.SetActive(true);
                            no.gameObject.SetActive(true);
                            click.gameObject.SetActive(false);

                        }
                        
                         currentState = characterState.answer;
                    }
                }

               


                break;

            case characterState.answer:                                  //*******ANSWER********//

                if (((Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.N))))
                {

                    if ((Input.GetKey(KeyCode.Y)))
                    {
                        if ((characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] == true) ||
                                  ((coinTally >= characterList.characters[rangeNumber].coins[currentPrompt]) && (characterList.characters[rangeNumber].coinGiveOrTake[currentPrompt] == false)))
                        {
                            if ((characterList.characters[rangeNumber].takeEssance[currentPrompt] == false) ||
                               ((essanceTally >= characterList.characters[rangeNumber].essanceAmount[currentPrompt]) && (characterList.characters[rangeNumber].takeEssance[currentPrompt] == true)))
                            {
                                if (((essanceTally >= characterList.characters[rangeNumber].essanceAmount[currentPrompt]) && (characterList.characters[rangeNumber].takeEssance[currentPrompt] == true)) || (characterList.characters[rangeNumber].takeEssance[currentPrompt] == false))
                                {

                                    Yes();
                                }
                            }
                        }


                    }
                    else if (Input.GetKey(KeyCode.N))
                    {


                        No();

                    }

                    noEssence.gameObject.SetActive(false);
                    noCoins.gameObject.SetActive(false);
                    yes.gameObject.SetActive(false);
                    no.gameObject.SetActive(false);
                    click.gameObject.SetActive(false);

                    currentState = characterState.answerPrompt;


                }


                break;
            case characterState.answerPrompt:

                yes.gameObject.SetActive(false);
                no.gameObject.SetActive(false);
                noEssence.gameObject.SetActive(false);
                noCoins.gameObject.SetActive(false);

                if (answerReady == true)
                {
                    mText.text = "";
                    sillyIndex = 0;
                }
                answerReady = false;
                tempETally = tempEssanceTally;

                if (answerType == true)
                {
                    if(sillyIndex < characterList.characters[rangeNumber].yes[currentPrompt].Length)
                    {
                        DisplayLine(characterList.characters[rangeNumber].yes[currentPrompt]);
                    }
                    else
                    {
                        flip = true;
                        tempTally = tempGoodTally;
                        currentState = characterState.addPoints;
                    }
                   
                }
                else
                {
                    if (sillyIndex < characterList.characters[rangeNumber].no[currentPrompt].Length)
                    {
                        DisplayLine(characterList.characters[rangeNumber].no[currentPrompt]);
                    }
                    else
                    {
                        flip = true;
                        tempTally = tempGoodTally;
                        currentState = characterState.addPoints;
                    }
                }
                break;
            case characterState.addPoints:
   
                //Move the good numbers

                if (goodTally != 200)
                {
                    if (currentGoodNumber != goodTally)
                    {
                        if (tempGoodTally <= goodTally)
                        {
                            if (tempGTally != goodTally)
                            {
                                if (tempGCounter == 2)
                                {
                                    tempGTally++;
                                    goodPoints.text = tempGTally.ToString();
                                    tempGCounter = 0;
                                }
                                tempGCounter++;
                            }

                        }
                        else if (tempGoodTally > goodTally)
                        {

                            if (tempGTally != goodTally)
                            {
                                if (tempGCounter == 2)
                                {
                                    tempGTally--;
                                    goodPoints.text = tempGTally.ToString();
                                    tempGCounter = 0;
                                }
                                tempGCounter++;
                            }

                        }

                    }
                    else
                    {
                        if (goodTally == 0 && tempGTally > goodTally)
                        {
                            if (tempGTally != goodTally)
                            {
                                if (tempGCounter == 2)
                                {
                                    tempGTally--;
                                    goodPoints.text = tempGTally.ToString();
                                    tempGCounter = 0;
                                }
                                tempGCounter++;
                            }
                        }
                    }

                }
                else
                {
                    if (goodTally == 200 && tempGoodTally == 200)
                    {
                        check1 = true;
                        goodPoints.text = goodTally.ToString();
                    }
                    else if (tempGoodTally <= goodTally)
                    {
                        if (tempGTally != goodTally)
                        {
                            if (tempGCounter == 2)
                            {
                                tempGTally++;
                                goodPoints.text = tempGTally.ToString();
                                tempGCounter = 0;
                            }
                            tempGCounter++;
                        }

                    }
                }

                if (tempGTally == goodTally)
                {
                    check1 = true;
                    goodPoints.text = goodTally.ToString();
                }


                //BadTally
                if (badTally != 200)
                {
                    if (currentBadNumber != badTally)
                    {
                        if (tempBadTally <= badTally)
                        {
                            if (tempBTally != badTally)
                            {
                                if (tempBCounter == 2)
                                {
                                    tempBTally++;
                                    badPoints.text = tempBTally.ToString();
                                    tempBCounter = 0;
                                }
                                tempBCounter++;
                            }

                        }
                        else if (tempBadTally > badTally)
                        {

                            if (tempBTally != badTally)
                            {
                                if (tempBCounter == 2)
                                {
                                    tempBTally--;
                                    badPoints.text = tempBTally.ToString();
                                    tempBCounter = 0;
                                }
                                tempBCounter++;
                            }

                        }

                    }
                    else
                    {
                        if (badTally == 0 && tempBTally > badTally)
                        {
                            if (tempBTally != badTally)
                            {
                                if (tempBCounter == 2)
                                {
                                    tempBTally--;
                                    badPoints.text = tempBTally.ToString();
                                    tempBCounter = 0;
                                }
                                tempBCounter++;
                            }
                        }
                    }

                }
                else
                {
                    if (badTally == 200 && tempBadTally == 200)
                    {
                        check2 = true;
                        badPoints.text = badTally.ToString();
                    }
                    else if (tempBadTally <= badTally)
                    {
                        if (tempBTally != badTally)
                        {
                            if (tempBCounter == 2)
                            {
                                tempBTally++;
                                badPoints.text = tempBTally.ToString();
                                tempBCounter = 0;
                            }
                            tempBCounter++;
                        }

                    }
                }

                if (tempBTally == badTally)
                {
                    check2 = true;
                    badPoints.text = badTally.ToString();
                }


                if (currentCoinsNumber != coinTally)
                {
                    if (tempCoinTally <= coinTally)
                    {
                        if (tempCTally != coinTally)
                        {
                            if (tempCCounter == 1)
                            {
                                tempCTally++;
                                coinsText.text = tempCTally.ToString();
                                tempCCounter = 0;
                            }
                            tempCCounter++;
                        }

                    }
                    else if (tempCoinTally > coinTally)
                    {

                        if (tempCTally != coinTally)
                        {
                            if (tempCCounter == 1)
                            {
                                tempCTally--;
                                coinsText.text = tempCTally.ToString();
                                tempCCounter = 0;
                            }
                            tempCCounter++;
                        }

                    }

                }
                else
                {
                    if (coinTally == 0 && tempCTally > coinTally)
                    {
                        if (tempCTally != coinTally)
                        {
                            if (tempCCounter == 1)
                            {
                                tempCTally--;
                                coinsText.text = tempCTally.ToString();
                                tempCCounter = 0;
                            }
                            tempCCounter++;
                        }
                    }
                }
                if (tempCTally == coinTally)
                {
                    check3 = true;
                    coinsText.text = coinTally.ToString();
                }

                //Essance Tally

                if (characterList.characters[rangeNumber].essanceAmount[currentPrompt] != 0)
                {
                    if (essanceTally != 20)
                    {
                        //if(characterList.characters[rangeNumber].essanceAmount[currentPrompt] != 0)
                        //{
                        if (tempEssanceTally != essanceTally)
                        {
                            if (tempEssanceTally < essanceTally)
                            {
                                if (tempETally != essanceTally)
                                {
                                    if (tempECounter == 2)
                                    {
                                        tempETally++;
                                        essance.text = tempETally.ToString();
                                        tempECounter = 0;
                                    }
                                    tempECounter++;
                                }

                            }
                            else 
                            {

                                if (tempETally != essanceTally)
                                {
                                    if (tempECounter == 2)
                                    {
                                        tempETally--;
                                        essance.text = tempETally.ToString();
                                        tempECounter = 0;
                                    }
                                    tempECounter++;
                                }

                            }

                        }
                        else
                        {
                            if (essanceTally == 0 && tempETally > essanceTally)
                            {
                                if (tempETally != essanceTally)
                                {
                                    if (tempECounter == 2)
                                    {
                                        tempETally--;
                                        essance.text = tempETally.ToString();
                                        tempECounter = 0;
                                    }
                                    tempECounter++;
                                }
                            }
                        }



                    }
                    else
                    {
                        //if (characterList.characters[rangeNumber].essanceAmount[currentPrompt] != 0)
                        //{
                        if (essanceTally == 20 && tempEssanceTally == 20)
                        {
                            check4 = true;
                            essance.text = essanceTally.ToString();
                        }
                        else if (tempEssanceTally <= essanceTally)
                        {
                            if (tempETally != essanceTally)
                            {
                                if (tempECounter == 2)
                                {
                                    tempETally++;
                                    essance.text = tempETally.ToString();
                                    tempECounter = 0;
                                }
                                tempECounter++;
                            }

                        }
                        // }
                    }
                }
                else
                {
                    check4 = true;
                }

                if (tempETally == essanceTally)
                {
                    check4 = true;
                    essance.text = essanceTally.ToString();
                }



                if (check1 == true && check2 == true && check3 == true && check4 == true)
                {
                    currentState = characterState.clickButton;
                }

                break;
            case characterState.clickButton:

                click.gameObject.SetActive(true);

                if ((Input.GetKey(KeyCode.Return)) || (Input.GetMouseButtonDown(0)))
                {

                    mText.text = "";
                    name.text = "";
                    panel.gameObject.SetActive(false);
                    sillyIndex = 0;

                    currentState = characterState.flip;
                }


                    break;
            case characterState.flip:

                click.gameObject.SetActive(false);
                player2.color = Color.clear;
                player1.color = Color.clear;
                player3.color = Color.white;

                // float smoothTime = 5f;
                float yVelocity = 0.0f;
                float rZ = character.transform.rotation.z;
                if (rY < 179)
                {
                    rY = Mathf.SmoothDamp(rY, 180, ref yVelocity, .03f);
                    character.transform.rotation = Quaternion.Euler(0, rY, rZ);

                    if (secondCharacter == true)
                    {
                        character2.transform.rotation = Quaternion.Euler(0, rY, rZ);
                    }
                }
                else
                {
                    currentState = characterState.walkOut;
                    rY = 0;
                }

                    break;
                

            case characterState.walkOut:                                    //*******WALK OUT********//

                yes.gameObject.SetActive(false);
                no.gameObject.SetActive(false);


                //Moving the bars
                if(coinTally <= 1000)
                {
                    if (Vector3.Distance(coinsBar.transform.position, coinsPosition) > 0.001f) // move the second character to the correct position
                    {
                        coinsBar.transform.position = Vector3.MoveTowards(coinsBar.transform.position, coinsPosition, speedCoins * Time.deltaTime);
                    }
                }
                if (Vector3.Distance(essanceBar.transform.position, essancePosition) > 0.001f) // move the second character to the correct position
                {
                    essanceBar.transform.position = Vector3.MoveTowards(essanceBar.transform.position, essancePosition, speedEssance * Time.deltaTime);
                }
                if (Vector3.Distance(badBar.transform.position, badPosition) > 0.001f) //(badBar.transform.position != badPosition)// move the second character to the correct position
                {
                    badBar.transform.position = Vector3.MoveTowards(badBar.transform.position, badPosition, speedGoodBad * Time.deltaTime);
                }
                if (Vector3.Distance(goodBar.transform.position, goodPosition) > 0.001f)//(goodBar.transform.position != goodPosition) // move the second character to the correct position
                {
                    goodBar.transform.position = Vector3.MoveTowards(goodBar.transform.position, goodPosition, speedGoodBad * Time.deltaTime);
                }

                if (secondCharacter == true)
                {
                    character2.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    if (Vector3.Distance(character2.transform.position, leavingPosition2) > 0.001f)//(character2.transform.position != leavingPosition2)
                    {
                        character2.transform.position = Vector3.MoveTowards(character.transform.position, leavingPosition2, speed * Time.deltaTime);
                    }
                }
                //character.transform.position != leavingPosition)
                if (Vector3.Distance(character.transform.position, leavingPosition) > 0.001f)
                {                    
                    character.transform.position = Vector3.MoveTowards(character.transform.position, leavingPosition, speed * Time.deltaTime);
                }
                else
                {
                    if (numberOfCharacters == 3)
                    {
                        mText.text = "";
                        gText.text = "";
                        bText.text = "";
                        cText.text = "";
                        eText.text = "";
                        panel.gameObject.SetActive(false);
                        sillyIndex = 0;


                        currentState = characterState.stats;
                    }
                    else
                    {
                        mText.text = "";
                        name.text = "";
                        panel.gameObject.SetActive(false);
                        sillyIndex = 0;
                        currentState = characterState.fadeAway;
                    }
                }


                break;
            case characterState.stats:                                    //*******STATS********//

                if (numberOfCharacters != 3)
                {
                    currentState = characterState.fadeAway;
                }
                else if (numberOfCharacters == 3)
                {
                   
                    panel.gameObject.SetActive(false);
                    yes.gameObject.SetActive(false);
                    no.gameObject.SetActive(false);

                    if (villageBool == true)
                    {
                        village.color = Color.white;
                        smoke1.color = Color.white;
                        smoke2.color = Color.white;
                        smoke3.color = Color.white;
                    }

                    //Initialize the char array
                    for (int P = 0; P < 7; P++)
                    {
                        arrayOfCharacters[P] = -1;
                    }

                    if (rangeNumber == 24)
                    {
                        PunyBrain();
                    }
                    Stats(goodTally, badTally, greyThing, fine, doingGood, great, wonderful, doingBad, terrible, horrible);

                    if ((Input.GetKey(KeyCode.Return)) || (Input.GetMouseButtonDown(0)))
                    {
                        numberOfCharacters = 0;
                        name.text = "";
                        mText.text = "";
                        sillyIndex = 0;
                        currentState = characterState.fadeAway;
                    }
                }

                    break;
            case characterState.fadeAway:
    
                if (fadeTime > 0)
                {
                    FadeTextOut(gText);
                    FadeTextOut(bText);
                    FadeTextOut(cText);
                    FadeTextOut(eText);

                }
                else
                {
                    currentState = characterState.finish;
                }
                break;
            case characterState.finish:                              //*******FINISH********//
 
                sillyIndex = 0;
                int nextPrompt = currentPrompt + 1;
                secondCharacter = false;


                if (characterList.characters[rangeNumber].specialCharacter != true)
                {
                    if ((nextPrompt > characterList.characters[rangeNumber].lineNumber) && characterList.characters[rangeNumber].oneLiner != true)
                    {
                        characterList.characters[rangeNumber].done = true;
                    }
                }

                startGame = false;

                dayCycleCounter++;

                if (dayCycleCounter > 3)
                {
                    dayCycleCounter = 1;
                }

                goodBar.transform.position = goodPosition;
                badBar.transform.position = badPosition;
                coinsBar.transform.position = coinsPosition;
                essanceBar.transform.position = essancePosition;

                if(rangeNumber == 12)
                {
                    characterList.characters[12].coinGiveOrTake[currentPrompt] = true;
                }
                if(characterList.characters[32].place > 1)
                {
                    characterList.characters[rangeNumber].done = true;
                }

                if (gameOver == false)
                {
                    characterList.characters[rangeNumber].place++;
                    panel.gameObject.SetActive(false);
                    currentState = characterState.start;

                }
                //If a character has only one repetitive dialog prompt then set it equal to it after their intro prompt
                if ((characterList.characters[rangeNumber].oneLiner == true) && (characterList.characters[rangeNumber].place >= 1))
                {
                    OneLiner();
                    //characterList.characters[rangeNumber].place = 1;
                }
                //If character has more than one line and is repetitive
                if ((characterList.characters[rangeNumber].oneLiner == false) && (characterList.characters[rangeNumber].repetitive == true))
                {
                    RepeatCharacter();
                }

                //Reset Brooks coinGive or take 
                if(rangeNumber == 11)
                {
                    characterList.characters[11].coinGiveOrTake[1] = true;
                }
                //If the character is Sir Puny Brain
                if (rangeNumber == 24)
                {
                    PunyBrain();
                    currentPrompt = characterList.characters[rangeNumber].place;
                }
                if (rangeNumber == 25)
                {
                    if ((characterList.characters[rangeNumber].start != true) && (noToHarmony == true))
                    {
                        characterList.characters[rangeNumber].place--;
                    }
                    Harmony();
                }
                if (rangeNumber == 34)
                {
                    Bram();
                }
                if (gameOver == true)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + ending);
                }
                if (daysTally == 31 && dayCycleCounter == 1)
                {
                    gameOver = true;
                }


                break;
            default:
                break; //never should get hit
        }

            
           
           
        
    }
}



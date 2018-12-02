using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//enum = easy way to label/organize 
//Going to use index #'s 0-9
public enum DanceType
{
    //Next time make idle the first one :(
    Left,
    LeftLeft,
    HopLeft,
    TornadoLeft,
    Right,
    RightRight,
    HopRight,
    TornadoRight,
    Up,
    Down,
    Idle
};

public class GameController : MonoBehaviour
{   
    //Array of classes in "ArrowSequence" Script
    public ArrowSequence[] Sequences;
    public GameObject[] Gauge;

    //Pictures
    public GameObject EndGame;
    public GameObject EndScore;


    //Spacebar
    public GameObject SpacebarTilemap;
    public GameObject SpacebarBlueText;
    public GameObject SpacebarRedText;

    public Animator BunnyAnimator;

    //Int cuz yous countin it buddio
    private int currentSequence;
    //Done with all 10 sequences, tells it to stop going to next
    //or just tells it to stop going to next if isComplete = true
    private bool isComplete;

    //SpacebarTimer
    private float SpacebarTimer;
    public float SpacebarGoalTime;
    //Bool to indicate that we're using timer
    private bool isSpacebarTimerActive;


    //Timer for score to show up after 10 seconds

    private float Timer;
    public float GoalTime;

    public Text EndScoreText;


    //Audio
    public AudioSource DanceAudioSource;




    void Start ()
    {
        Timer = 0;

        isComplete = false;
        EndGame.SetActive(false);
        EndScore.SetActive(false);

        //Text; a script so we gotta put .gameobject
        EndScoreText.gameObject.SetActive(false);

        SpacebarTimer = 0;
        isSpacebarTimerActive = false;


        //1st index
        currentSequence = 0;

        //Activates the 1st one
        Sequences[0].ActivateSequence(this);
    }


    void MoveToNextSequence()
    {
        //+1 to go to next index AND fill up gauge by 1
        currentSequence = currentSequence + 1;

        SpacebarTilemap.SetActive(false);
        SpacebarBlueText.SetActive(false);
        SpacebarRedText.SetActive(false);



        //To not activate the next sequence if no more items in array
        if (currentSequence < Sequences.Length)
        {
            //THIS = MYSELF (GameController)
            Sequences[currentSequence].ActivateSequence(this);
        }
        else
        {
            isComplete = true;
            EndGame.SetActive(true);
        }
    }


	void Update ()
    {

        Timer = Timer + Time.deltaTime;

        if (Timer > GoalTime)
        {
            EndScore.SetActive(true);
            EndScoreText.gameObject.SetActive(true);

            //Current Seq = int (the gauge score)
            //+ "" makes it a string; text is a string (string = basically text)
            EndScoreText.text = (currentSequence) + "";
            isComplete = true;

            SpacebarTilemap.SetActive(false);
            SpacebarBlueText.SetActive(false);
            SpacebarRedText.SetActive(false);


        }

        



        //Dont check (if statements) if game is complete
        //When sequence is done LF > SPACE KEY
        //All arrow keys clicked


        //This is after Space is clicked
        if (isSpacebarTimerActive)
        {
            //SpacebarTimer = SpacebarTimer + Time.deltaTime;
            SpacebarTimer += Time.deltaTime;

            if (SpacebarTimer > SpacebarGoalTime)
            {
                isSpacebarTimerActive = false;

                MoveToNextSequence();

            }
        }
        //Move on to this condition if ^ isn't true
		else if (isComplete == false && Sequences[currentSequence].IsComplete())
        {
            //SPACE KEY CLICKED
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Gauge[currentSequence].SetActive(true);
                SpacebarTimer = 0;
                isSpacebarTimerActive = true;

                SpacebarRedText.SetActive(true);
                SpacebarBlueText.SetActive(false);
                Dance(DanceType.TornadoLeft);
            }
            //SPACE KEY NOT CLICKED
            else
            {
                SpacebarTilemap.SetActive(true);
                SpacebarBlueText.SetActive(true);

            }
        }
	}

    public void Dance(DanceType DanceType)
    {
        //KEY TAP AUDIO PLAYS EVERYTIME BUNNY DANCES
        DanceAudioSource.Play();

        //Converting enum to integer (index #)
        int DanceInt = (int) DanceType;

        //Setting the conditions (in the animator) to match up to the integers (index #) ^
        BunnyAnimator.SetInteger("DanceMove", DanceInt);
    }
}

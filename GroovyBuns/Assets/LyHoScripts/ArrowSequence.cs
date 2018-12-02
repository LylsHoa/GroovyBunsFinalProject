using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSequence : MonoBehaviour
{
    //List of arrows, that I can put in sequences
    //Array values are called INDEXES :(
    //Contains the 
    public Arrows[] ArrowList;

   //Not active = Arrows red (COMPLETED)
    private bool isComplete = false;
    //
    private int currentArrowIndex = 0;

    //CurrentController because (in a case of multiple game controllers which this game will never have but just incase for some weird unknown reason this note is erally long but this is the reason why its named that its not what i woulda personally named it but it makes sense.
    private GameController CurrentController;

    //Turn on
    public void ActivateSequence(GameController Controller)
    {
        isComplete = false;
        currentArrowIndex = 0;
        gameObject.SetActive(true);
        //Put A controller into the Current Controller
        CurrentController = Controller;
    }

    //completed sequence after spacebar 
    public bool IsComplete()
    {
        return isComplete;
    }

    void Update()
    {   //If the game object is turned on- wink wonk
        if (gameObject.activeSelf)
        {
            //LF > Arrow key
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                HandleArrowInput(ArrowType.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                HandleArrowInput(ArrowType.Right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                HandleArrowInput(ArrowType.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                HandleArrowInput(ArrowType.Down);
            }
        }
    }

    //Handling = dealing with input --> looking for the input and doing something with it
    //Deactivates the arrow in the list
    // +1 means to move to the next arrow, to read the next arrow
    void HandleArrowInput(ArrowType ArrowType)
    {
        if (ArrowList[currentArrowIndex].TypeOfArrow == ArrowType)
        {
            //Each arrow has a dancetype :)
            CurrentController.Dance(ArrowList[currentArrowIndex].DanceType);

            ArrowList[currentArrowIndex].DeactivateArrow();
            currentArrowIndex = currentArrowIndex + 1;
        }

        //The sequence is done, no more arrows to read (Turns off)
        //When all red (complete) the sequence turns off
        if (ArrowList.Length <= currentArrowIndex)
        {
            isComplete = true;
            gameObject.SetActive(false);
        }
    }

}

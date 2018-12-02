using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum = easy way to label/organize 
public enum ArrowType
{
    Left,
    Right,
    Up,
    Down
};

public class Arrows : MonoBehaviour
{
    //Call renderer to set what sprite arrows look like 
   
    public SpriteRenderer SpriteRenderer;

    public Sprite OnLeftArrow;
    public Sprite OffLeftArrow;

    public Sprite OnRightArrow;
    public Sprite OffRightArrow;

    public Sprite OnUpArrow;
    public Sprite OffUpArrow;

    public Sprite OnDownArrow;
    public Sprite OffDownArrow;

    public ArrowType TypeOfArrow;

    public DanceType DanceType;


    void Start ()
    {

        ChangeArrowType(TypeOfArrow, true);
    }
	

    public void DeactivateArrow()
    {
        ChangeArrowType(TypeOfArrow, false);
    }





    //Function created to match up arrows to the renderer/pictures
    //Function always meant to be called with an arrow type

   //TURNS ARROWS RED
	void ChangeArrowType(ArrowType type, bool active)
    //bool t/f 
    {
      
        if (type == ArrowType.Left)
        {
            if (active)
            {
                SpriteRenderer.sprite = OnLeftArrow;
            }
            else
            {
                SpriteRenderer.sprite = OffLeftArrow;
            }
        }

        //Else if = IF NOT
        else if (type == ArrowType.Right)
        {
            if (active)
            {
                SpriteRenderer.sprite = OnRightArrow;
            }
            else
            {
                SpriteRenderer.sprite = OffRightArrow;
            }
        }


        else if (type == ArrowType.Up)
        {
            if (active)
            {
                SpriteRenderer.sprite = OnUpArrow;
            }
            else
            {
                SpriteRenderer.sprite = OffUpArrow;
            }
        }


        else if (type == ArrowType.Down)
        {
            if (active)
            {
                SpriteRenderer.sprite = OnDownArrow;
            }
            else
            {
                SpriteRenderer.sprite = OffDownArrow;
            }
        }
    }
}

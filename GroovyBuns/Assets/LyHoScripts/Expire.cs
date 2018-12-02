using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expire : MonoBehaviour
{
    //TURNS OFF INSTURCTIONS >:D

    public float GoalTime;

    private float Timer;



	void Start ()
    {
        Timer = 0;


	}
	

	void Update ()
    {
        Timer = Timer + Time.deltaTime;
        
        if (Timer > GoalTime)
        {
            gameObject.SetActive(false);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreboard : MonoBehaviour
{

    public int Score;
    public GameObject error; //change this to whatever thefail state is

    private void Start()
    {
        Score = 0;
    }

    public void ChangeScore(int change)
    {
        Score += change;
        if (Score == 0)
        {
            if (error != null)
            {
                error.SetActive(true);
            }
            
        }
        else
        {
            if (error != null)
            {
                error.SetActive(false);
            }
        }
            
    }

}

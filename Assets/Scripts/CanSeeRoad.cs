using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeeRoad : MonoBehaviour
{
    GameObject manager;

    void Awake()
    {
         manager = GameObject.FindGameObjectWithTag("GameController");
        
    }

    void OnBecameInvisible()
    {
        manager.GetComponent<scoreboard>().ChangeScore(-1);
        
    }

    private void OnBecameVisible()
    {
        manager.GetComponent<scoreboard>().ChangeScore(1);
    }
}

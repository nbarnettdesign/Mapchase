using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeeRoad : MonoBehaviour
{
    scoreboard manager;

    void Awake()
    {
         manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<scoreboard>();
    }

    void OnBecameInvisible()
    {
        manager.ChangeScore(-1);
    }

    private void OnBecameVisible()
    {
        manager.ChangeScore(1);
    }
}

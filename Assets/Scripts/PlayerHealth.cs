using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    void Start()
    {
        playerHealth = 10;
    }

    void Update()
    {
        if (playerHealth != 0)
        {
            if (Input.GetKeyDown("o"))
            {
                playerHealth -= 1;
            }
        }
    }
}

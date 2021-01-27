using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public bool VictoryEnter;

    private void OnTriggerEnter(Collider other)
    {
        VictoryEnter = true;
    }
}
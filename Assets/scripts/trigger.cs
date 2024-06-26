using UnityEngine;
using System;

public class Trigger : MonoBehaviour
{
    public static Action enterTrigger;
    public static Action exitTrigger;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") enterTrigger?.Invoke();
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player") exitTrigger?.Invoke();
    }
}

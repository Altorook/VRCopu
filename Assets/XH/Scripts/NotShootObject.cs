using System;
using UnityEngine;

public class NotShootObject : MonoBehaviour
{
    internal void BeenFocus()
    {
        //sound here
        Debug.Log("please not shoot me ");
        AudioManager.PlaySound(7);
    }

    
}

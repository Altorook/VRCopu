using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InstructionsManager : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;

    private void Start()
    {
        AudioManager.PlaySound(0);
        Card1.SetActive(true);
        Card2.SetActive(false);
        Card3.SetActive(false);
        Card4.SetActive(false);
        Card5.SetActive(false);
        Card6.SetActive(false);
    }

    public void CheckSafety()
    {
        Card1.SetActive(false);
        Card2.SetActive(true);
        Card3.SetActive(false);
        Card4.SetActive(false);
        Card5.SetActive(false);
        Card6.SetActive(false);
    }
    public void LoadMagAndPullHandle()
    {
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(true);
        Card4.SetActive(false);
        Card5.SetActive(false);
        Card6.SetActive(false);
    }
    public void TurnOffSafetyAndPullTrigger()
    {
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(false);
        Card4.SetActive(true);
        Card5.SetActive(false);
        Card6.SetActive(false);
    }
    public void UnloadMagAndPullHandle()
    {
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(false);
        Card4.SetActive(false);
        Card5.SetActive(true);
        Card6.SetActive(false);
    }
    public void Jam()
    {
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(false);
        Card4.SetActive(false);
        Card5.SetActive(false);
        Card6.SetActive(true);
    }
}

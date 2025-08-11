using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public enum GameState
    {
        DontPoint=0,
        Chambering=1,
        Shooting=2,
        Checkclear=3,
        FreeTime=4,
        Jam
    }
    public GameState state = GameState.DontPoint;

    [SerializeField] DontPS dps;
    [SerializeField] Chambs chamb;
    [SerializeField] ShootS shoot;
    [SerializeField] ClearGunS clearGun;
    [SerializeField] JamS jam;
    [SerializeField] FreeTS free;
    bool hasJammed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    { 
        DontPoint();
    }
    public void DontPoint()
    {
        dps.enabled = true;
        chamb.enabled = false;
        shoot.enabled = false;
        clearGun.enabled = false;
        jam.enabled = false;
        free.enabled = false;
    }
    public void Chamber()
    {
        dps.enabled = false;
        chamb.enabled = true;
        shoot.enabled = false;
        clearGun.enabled = false;
        jam.enabled = false;
        free.enabled = false;
    }
    public void Shooting()
    {
        dps.enabled = false;
        chamb.enabled = false;
        shoot.enabled = true;
        clearGun.enabled = false;
        jam.enabled = false;
        free.enabled = false;
    }
    public void CheckClear()
    {
        dps.enabled = false;
        chamb.enabled = false;
        shoot.enabled = false;
        clearGun.enabled = true;
        jam.enabled = false;
        free.enabled = false;
    }
    public void Jam()
    {
        dps.enabled = false;
        chamb.enabled = false;
        shoot.enabled = false;
        clearGun.enabled = false;
        jam.enabled = true;
        free.enabled = false;
    }
    public void FreeTime()
    {
        dps.enabled = false;
        chamb.enabled = false;
        shoot.enabled = false;
        clearGun.enabled = false;
        jam.enabled = false;
        free.enabled = true;
    }
    public void Jammed()
    {
        if(state == GameState.FreeTime && !hasJammed)
        {
            state = GameState.Jam;
        hasJammed = true;
            Jam();
        }
    }
    public void UnJammed()
    {
        state = GameState.FreeTime;
    }
    public void ChangeStage()
    {
        if((int)state < 4)
        {
            state++;
        }
        switch (state)
        {
            case GameState.DontPoint:
                DontPoint();
                break;

            case GameState.Chambering:
                Chamber();
                break;

            case GameState.Shooting:
                Shooting();
                break;

            case GameState.Checkclear:
                CheckClear();
                break;

            case GameState.Jam:
                Jam();
                break;

            case GameState.FreeTime:
                FreeTime();
                break;

            default:
                Debug.Log("Unknown game state");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

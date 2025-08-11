using System.Collections;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public enum GameState
    {
        DontPoint=0,
        Chambering=1,
        Shooting=2,
        Checkclear=3,
        Jam=4,
        FreeTime=5
    }
    public GameState state = GameState.DontPoint;

    [SerializeField] 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void DontPoint()
    {

    }
    public void Chamber()
    {

    }
    public void Shooting()
    {

    }
    public void CheckClear()
    {

    }
    public void Jam()
    {

    }
    public void FreeTime()
    {

    }
    // Update is called once per frame
    void Update()
    {
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
                Debug.LogWarning("Unknown game state");
                break;
        }
    }
}

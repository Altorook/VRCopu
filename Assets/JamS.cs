using UnityEngine;

public class JamS : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        //play sound
    }
    public void Completed()
    {
        gameSystem.UnJammed();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class ClearGunS : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    bool hasPlayed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (!hasPlayed)
        {
            AudioManager.PlaySound(4);
            hasPlayed = true;
        }
       // AudioManager.PlaySound(4);
    }
    public void Completed()
    {
        gameSystem.ChangeStage();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

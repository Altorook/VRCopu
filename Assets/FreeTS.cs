using UnityEngine;

public class FreeTS : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    bool hasPlayed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (!hasPlayed)
        {
            AudioManager.PlaySound(8);
            hasPlayed = true;
        }
    
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

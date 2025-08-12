using UnityEngine;

public class DontPS : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    bool hasPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if(!hasPlayed)
        {
            AudioManager.PlaySound(1);
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

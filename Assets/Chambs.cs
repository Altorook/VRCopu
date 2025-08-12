using UnityEngine;
using UnityEngine.Events;


public class Chambs : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    bool hasPlayed;
    public UnityEvent ChangeCard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (!hasPlayed)
        {
            AudioManager.PlaySound(2);
            hasPlayed = true;
            ChangeCard.Invoke();
        }
  //      AudioManager.PlaySound(2);
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

using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class ShootS : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    bool hasPlayed;
    public UnityEvent ChangeCard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (!hasPlayed)
        {
            StartCoroutine(Sound());
            hasPlayed = true;
            ChangeCard.Invoke();
        }
        
    }
    public void Completed()
    {
        gameSystem.ChangeStage();
    }
    IEnumerator Sound()
    {
        AudioManager.PlaySound(3);
        yield return new WaitForSeconds(5);
        AudioManager.PlaySound(6);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

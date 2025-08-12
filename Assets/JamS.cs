using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class JamS : MonoBehaviour
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
        gameSystem.UnJammed();
    }
    IEnumerator Sound()
    {
        AudioManager.PlaySound(9);
        yield return new WaitForSeconds(6.5f);
        AudioManager.PlaySound(10);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

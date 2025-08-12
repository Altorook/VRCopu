using System.Collections;
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
            StartCoroutine(Sound());
            hasPlayed = true;
        }
      
    }
    IEnumerator Sound()
    {
        AudioManager.PlaySound(0);
        yield return new WaitForSeconds(6);
        AudioManager.PlaySound(1);
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

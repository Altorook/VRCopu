using System.Collections;
using UnityEngine;

public class JamS : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        StartCoroutine(Sound());
    }
    public void Completed()
    {
        gameSystem.UnJammed();
    }
    IEnumerator Sound()
    {
        AudioManager.PlaySound(9);
        yield return new WaitForSeconds(5);
        AudioManager.PlaySound(10);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

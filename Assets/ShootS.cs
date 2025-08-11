using UnityEngine;
using System.Collections;
public class ShootS : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        StartCoroutine(Sound());
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

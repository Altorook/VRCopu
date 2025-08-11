using UnityEngine;

public class Chambs : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        AudioManager.PlaySound(2);
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

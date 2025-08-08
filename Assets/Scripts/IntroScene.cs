using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    [SerializeField] TMP_Text countDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayStart());
    }
    IEnumerator DelayStart()
    {
        
        yield return new WaitForSeconds(5);
        countDown.SetText(10.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(9.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(8.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(7.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(6.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(5.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(4.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(3.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(2.ToString());
        yield return new WaitForSeconds(1);
        countDown.SetText(1.ToString());
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

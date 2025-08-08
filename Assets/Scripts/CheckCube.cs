using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SceneManagement;

public class CheckCube : MonoBehaviour
{
    [SerializeField] RubCubeLogic RCLogic;
    [SerializeField] MoveCubeCover MCC;
    public bool waitForShuffle = true;
    [SerializeField] GameObject floor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(10);
        floor.SetActive(false);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("StartScene");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trig");
        if(other.gameObject.name == "RubCubeObject" && !waitForShuffle)
        {
            if (RCLogic.CheckWin())
            {
                MCC.StartMove(false);
                StartCoroutine(Win());
            }
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Col");
    //}
}

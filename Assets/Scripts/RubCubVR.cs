using UnityEngine;

public class RubCubVR : MonoBehaviour
{
    [SerializeField] GameObject[] gizmoArray;
    public void OnGrabCube()
    {
        for(int i = 0; i < gizmoArray.Length; i++)
        {
            gizmoArray[i].gameObject.SetActive(true);
        }
    }
    public void OnDropCube()
    {
        for (int i = 0; i < gizmoArray.Length; i++)
        {
            gizmoArray[i].gameObject.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

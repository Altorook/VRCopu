using UnityEngine;

public class CollectChildren : MonoBehaviour
{
    public bool isGrabbed;
    [SerializeField] Transform faceOrigin;
    bool hasTooManyChildren = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTooManyChildren)
        {
            if(transform.childCount > 1)
            {
                transform.GetChild(1).SetParent(transform.parent);
            }
            else
            {
                hasTooManyChildren = false;
            }
        }
    }
    public void OnGrabbed()
    {
        isGrabbed = true;
        hasTooManyChildren = false;
    }
    public void OnRelease()
    {
        isGrabbed= false;
        hasTooManyChildren = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (isGrabbed)
        {
            other.transform.SetParent(faceOrigin);
          //  Debug.Log("Yea");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (isGrabbed)
        {
            collision.transform.SetParent(faceOrigin);
           // Debug.Log("Yea");
        }
    }
}

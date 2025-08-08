using UnityEngine;

public class GunDetect : MonoBehaviour
{
    [SerializeField] GameObject originalPoint;
    [SerializeField] GameObject directionPoint;
    [SerializeField] private Vector3 direction;
    [SerializeField] float distance = 1000f;
    void Update()
    {
        direction = directionPoint.transform.position - originalPoint.transform.position;
        GunSafeDetect();
    }
    private void GunSafeDetect()
    {
       
        RaycastHit hit;
        Debug.DrawRay(originalPoint.transform.position, direction * distance, Color.red, 1.0f);
        Physics.Raycast(originalPoint.transform.position,direction , distance);
    }

}

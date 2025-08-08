using UnityEngine;

public class GunDetect : MonoBehaviour
{
    [SerializeField] GameObject originalPoint;
    [SerializeField] GameObject directionPoint;
    [SerializeField] private Vector3 direction;
    [SerializeField] float distance = 1000f;
    void FixedUpdate()
    {
        direction = directionPoint.transform.position - originalPoint.transform.position;
        GunSafeDetect();
    }
    private void GunSafeDetect()
    {
        RaycastHit hit;
        if (!Physics.Raycast(originalPoint.transform.position, direction.normalized, out hit, distance))
        {
           
            return;
        }
       
        Debug.DrawRay(originalPoint.transform.position, direction * distance, Color.red, 1.0f);
      
        if (hit.collider.GetComponent<Target>() != null)
        {
            var target = hit.collider.GetComponent<Target>();
            target.BeenFocus();

        }
        else if (hit.collider.GetComponent<NotShootObject>() != null)
        {
            var notShoot = hit.collider.GetComponent<NotShootObject>();
            notShoot.BeenFocus();
        }
    }

}

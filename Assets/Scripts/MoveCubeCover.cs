using UnityEngine;

public class MoveCubeCover : MonoBehaviour
{
    float bottomY;
    float topY;
    [SerializeField] float ChangeInPos;
    bool doMove;
    bool moveUp;
    float posState = 0;
    [SerializeField] float speedToMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomY = transform.position.y;
        topY = transform.position.y + ChangeInPos;
        StartMove(true);
    }
    public void StartMove(bool isUp)
    {
        posState = 0;
        doMove = true;
        moveUp = isUp;
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (doMove)
        {
            if (moveUp)
            {
                posState += Time.deltaTime * speedToMove;
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(bottomY, topY, posState),transform.position.z);
                    if (posState >= 1)
                {
                    doMove = false;
                   
                }
            }
            else
            {
                posState += Time.deltaTime * speedToMove * 5;
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(topY, bottomY, posState), transform.position.z);
                if (posState <= 0)
                {
                    doMove = false;
                }
            }
            
        }
    }
}

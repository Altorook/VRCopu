using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChargingHandle : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Transform pulledPos;
    [SerializeField] Transform chargingHandleTransform;
    public float lerpState;
    bool isGrabbed;
    [SerializeField] float resetSpeed;

    Transform controllerTransform;
    Vector3 grabStartPos;
    [SerializeField] float distanceToPull;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = chargingHandleTransform.localPosition;
    }
    public void PullBackLerp()
    {
chargingHandleTransform.localPosition = Vector3.Lerp(startPos,pulledPos.localPosition,lerpState);
    }
    public void ReleasedChargingHandle()
    {
        lerpState -= Time.deltaTime * resetSpeed;
    }
    public void GrabStart(SelectEnterEventArgs args)
    {
        Debug.Log("GRab");
        isGrabbed = true;
        controllerTransform = args.interactorObject.transform;
        grabStartPos = controllerTransform.position;
    }
    public void GrabEnd()
    {
        Debug.Log("LETGO");
        isGrabbed=false;
    }
    // Update is called once per frame
    void Update()
    {
        PullBackLerp();
        if(!isGrabbed)
        {
            ReleasedChargingHandle();
        }
        else
        {
            lerpState =Mathf.Clamp(Vector3.Distance(grabStartPos,controllerTransform.position)/distanceToPull,0,1);
        }
    }
}

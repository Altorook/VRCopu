using TMPro;
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
    [SerializeField] GunSystem gunSystem;
    bool isPulledBack;

    [SerializeField] float percentChanceToJam;
    bool autoMoveHandle;
    bool doReset;
    [SerializeField] float shootHandleMoveSpeed;


    [SerializeField] TMP_Text lerpT;
    [SerializeField] TMP_Text isGrab;
    [SerializeField] TMP_Text other;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = chargingHandleTransform.localPosition;
    }
    public void PullBackLerp()
    {
        chargingHandleTransform.localPosition = Vector3.Lerp(startPos, pulledPos.localPosition, lerpState);
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
        isGrabbed = false;
    }
    public bool GunCicled()
    {
        float rand = Random.Range(0f, 100f);
        if (rand <= percentChanceToJam)
        {
            return false;
        }
        else
        {
            autoMoveHandle = true;
            doReset = false;
            return true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        PullBackLerp();
        if (autoMoveHandle)
        {
            if (!doReset)
            {
                lerpState += Time.deltaTime * shootHandleMoveSpeed;
                if (lerpState >= 1)
                {
                    doReset = true;
                }
            }
            else
            {
                lerpState -= Time.deltaTime * shootHandleMoveSpeed;
                if (lerpState <= 0)
                {
                    autoMoveHandle = false;
                    gunSystem.ChargingHandlePulled();
                }
            }
        }
        else if (!isGrabbed)
        {
            ReleasedChargingHandle();
            if (lerpState <= 0)
            {
                isPulledBack = false;
            }
        }
        else
        {
            lerpState = Mathf.Clamp(Vector3.Distance(grabStartPos, controllerTransform.position) / distanceToPull, 0, 1);
            if (lerpState >= 1 && !isPulledBack)
            {
                isPulledBack = true;
                gunSystem.ChargingHandlePulled();
            }
        }
        lerpState = Mathf.Lerp(lerpState, 0, 1);
    lerpT.SetText(lerpState.ToString());
        isGrab.SetText(isGrabbed.ToString());
        other.SetText(Vector3.Distance(grabStartPos, controllerTransform.position).ToString());
    }
    
}

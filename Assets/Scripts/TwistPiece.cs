using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwistPiece : MonoBehaviour
{
 //   public TMP_Text rotationValueText;

    private bool _isRotating = false;

    Transform controllerIntractor;

    float _startRotation = 0;
    Quaternion _currentRotation;

    public float changeInRotation;
    [SerializeField] RubCubeRotate RCRot;
    [SerializeField] int indexOf;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void TwistStart(SelectEnterEventArgs args)
    {
        changeInRotation = 0;
        controllerIntractor = args.interactorObject.transform;
        _isRotating = true;

        _startRotation = controllerIntractor.eulerAngles.z;
        RCRot.StartRotation(indexOf,this);
    }



    public void TwistEnd()
    {
        _isRotating = false;
        RCRot.EndRotation(indexOf, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isRotating) return;

        var rotation = controllerIntractor.eulerAngles.z - _startRotation;
        changeInRotation = rotation;
   //    rotationValueText.text = rotation.ToString();
    }
}

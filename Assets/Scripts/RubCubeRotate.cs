using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class RubCubeRotate : MonoBehaviour
{
    [SerializeField] GameObject FaceAOrigin;
    [SerializeField] CollectChildren ACollect;

    [SerializeField] GameObject FaceBOrigin;
    [SerializeField] CollectChildren BCollect;

    [SerializeField] GameObject FaceCOrigin;
    [SerializeField] CollectChildren CCollect;

    [SerializeField] GameObject FaceDOrigin;
    [SerializeField] CollectChildren DCollect;

    [SerializeField] GameObject FaceEOrigin;
    [SerializeField] CollectChildren ECollect;

    [SerializeField] GameObject FaceFOrigin;
    [SerializeField] CollectChildren FCollect;

    [SerializeField] RubCubeLogic RCLogic;
 //   [SerializeField] TMP_Text rot;
//    [SerializeField] TMP_Text other;
    TwistPiece currentTP;
    int currentTPIndex;
    bool isRotating = false;
    Quaternion currentLocalRotation;
    Quaternion rotation;
    [SerializeField] int timesToScramble;
    [SerializeField] CheckCube CC;
    [SerializeField] float shuffleSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         StartCoroutine(Shuffle());
        //  ACollect.OnRelease();
        //ACollect.OnGrabbed();
        ////  yield return new WaitForSeconds(3);
        //RotateFaceRandomizer(0, true);
        //ACollect.OnRelease();
    }
    IEnumerator Shuffle()
    {
        //RCLogic.CheckWin();
        //BCollect.OnGrabbed();

        for(int i = 0; i < timesToScramble; i++)
        {
            yield return new WaitForSeconds(shuffleSpeed);
            int rand = Random.Range(0, 6);
            int randLR = Random.Range(0, 2);
            if(rand == 0)
            {
                if(randLR == 0)
                {
                    ACollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(0, true);
                    ACollect.OnRelease();
                }
                else
                {
                    ACollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(0, false);
                    ACollect.OnRelease();
                }
            }
            else if(rand == 1)
            {
                if (randLR == 0)
                {
                    BCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(1, true);
                    BCollect.OnRelease();
                }
                else
                {
                    BCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(1, false);
                    BCollect.OnRelease();
                }
            }
            else if(rand == 2)
            {
                if (randLR == 0)
                {
                    CCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(2, true);
                    CCollect.OnRelease();
                }
                else
                {
                    CCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(2, false);
                    CCollect.OnRelease();
                }
            }
            else if(rand == 3)
            {
                if (randLR == 0)
                {
                    DCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(3, true);
                    DCollect.OnRelease();
                }
                else
                {
                    DCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(3, false);
                    DCollect.OnRelease();
                }
            }
            else if(rand == 4)
            {
                if (randLR == 0)
                {
                    ECollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(4, true);
                    ECollect.OnRelease();
                }
                else
                {
                    ECollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(4, false);
                    ECollect.OnRelease();
                }
            }
            else
            {
                if (randLR == 0)
                {
                    FCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(5, true);
                    FCollect.OnRelease();
                }
                else
                {
                    FCollect.OnGrabbed();
                    yield return new WaitForSeconds(shuffleSpeed);
                    RotateFaceRandomizer(5, false);
                    FCollect.OnRelease();
                }
            }
            
        }
        CC.waitForShuffle = false;
        // yield return new WaitForSeconds(3);
        //RotateFaceRandomizer(1, true);
        //BCollect.OnRelease();
        //    RCLogic.CheckWin();
        //    CCollect.OnGrabbed();
        //    yield return new WaitForSeconds(3);
        //    RotateFace(2, true);
        //    CCollect.OnRelease();
        //    DCollect.OnGrabbed();
        //    yield return new WaitForSeconds(3);
        //    RotateFace(3, true);
        //    DCollect.OnRelease();
        //    ECollect.OnGrabbed();
        //    yield return new WaitForSeconds(3);
        //    RotateFace(4, true);
        //    ECollect.OnRelease();
        //    FCollect.OnGrabbed();
        //    yield return new WaitForSeconds(3);
        //    RotateFace(5, true);
        //    FCollect.OnRelease();
        //    yield return new WaitForSeconds(3);
        //    RCLogic.PrintFaceA();
    }
    public void RotateWithHand(int index, TwistPiece twistPiece)
    {
     //   rot.SetText(twistPiece.changeInRotation.ToString());
        if (twistPiece.changeInRotation < 180 && twistPiece.changeInRotation > 0)
        {
            if (index == 0)
            {
                 rotation = Quaternion.Euler(0, Mathf.Clamp(360-twistPiece.changeInRotation, 270, 360), 0);
             //   FaceAOrigin.transform.localRotation = currentLocalRotation * (rotation) ;

            }
            else if (index == 1)
            {
                 rotation = Quaternion.Euler(Mathf.Clamp(twistPiece.changeInRotation, 0, 90), 0, 0);
              //  FaceBOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 2)
            {
                 rotation = Quaternion.Euler(0, 0, Mathf.Clamp(360-twistPiece.changeInRotation, 270, 360));
              //  FaceCOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 3)
            {
                 rotation = Quaternion.Euler(0, Mathf.Clamp(twistPiece.changeInRotation, 0, 90), 0);
               // FaceDOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 4)
            {
                 rotation = Quaternion.Euler(0, 0, Mathf.Clamp(twistPiece.changeInRotation, 0, 90));
             //   FaceEOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else
            {
                 rotation = Quaternion.Euler(Mathf.Clamp(360-twistPiece.changeInRotation, 270, 360), 0, 0);
              //  FaceFOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
        }else if(twistPiece.changeInRotation <= 360 && twistPiece.changeInRotation >= 180)
        {
            if (index == 0)
            {
                 rotation = Quaternion.Euler(0, Mathf.Clamp(360-twistPiece.changeInRotation, 0, 90), 0);
              //  FaceAOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 1)
            {
                 rotation = Quaternion.Euler(Mathf.Clamp(twistPiece.changeInRotation, 270, 360), 0, 0);
            //    FaceBOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 2)
            {
                 rotation = Quaternion.Euler(0, 0, Mathf.Clamp(360-twistPiece.changeInRotation, 0, 90));
            //    FaceCOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 3)
            {
                 rotation = Quaternion.Euler(0, Mathf.Clamp(twistPiece.changeInRotation, 270, 360), 0);
               // FaceDOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 4)
            {
                 rotation = Quaternion.Euler(0, 0, Mathf.Clamp(twistPiece.changeInRotation, 270, 360));
                //FaceEOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else
            {
                 rotation = Quaternion.Euler(Mathf.Clamp(360-twistPiece.changeInRotation, 0, 90), 0, 0);
              //  FaceFOrigin.transform.localRotation = currentLocalRotation * rotation;
              
            }
         
        }else if (twistPiece.changeInRotation <= 0 && twistPiece.changeInRotation >= -180)
        {
            if (index == 0)
            {
                rotation = Quaternion.Euler(0, Mathf.Clamp(360 - (360 +twistPiece.changeInRotation), 0, 90), 0);
                //  FaceAOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 1)
            {
                rotation = Quaternion.Euler(Mathf.Clamp(360 + twistPiece.changeInRotation, 270, 360), 0, 0);
                //    FaceBOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 2)
            {
                rotation = Quaternion.Euler(0, 0, Mathf.Clamp(360 - (360 +twistPiece.changeInRotation), 0, 90));
                //    FaceCOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 3)
            {
                rotation = Quaternion.Euler(0, Mathf.Clamp((360 + twistPiece.changeInRotation), 270, 360), 0);
                // FaceDOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 4)
            {
                rotation = Quaternion.Euler(0, 0, Mathf.Clamp((360 + twistPiece.changeInRotation), 270, 360));
                //FaceEOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else
            {
                rotation = Quaternion.Euler(Mathf.Clamp(360 - (360 + twistPiece.changeInRotation), 0, 90), 0, 0);
                //  FaceFOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
        }
        else if(twistPiece.changeInRotation < -180)
        {
            if (index == 0)
            {
                rotation = Quaternion.Euler(0, Mathf.Clamp(360 - (360 + twistPiece.changeInRotation), 270, 360), 0);
                //   FaceAOrigin.transform.localRotation = currentLocalRotation * (rotation) ;

            }
            else if (index == 1)
            {
                rotation = Quaternion.Euler(Mathf.Clamp((360 + twistPiece.changeInRotation), 0, 90), 0, 0);
                //  FaceBOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 2)
            {
                rotation = Quaternion.Euler(0, 0, Mathf.Clamp(360 - (360 + twistPiece.changeInRotation), 270, 360));
                //  FaceCOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 3)
            {
                rotation = Quaternion.Euler(0, Mathf.Clamp((360 + twistPiece.changeInRotation), 0, 90), 0);
                // FaceDOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else if (index == 4)
            {
                rotation = Quaternion.Euler(0, 0, Mathf.Clamp((360 + twistPiece.changeInRotation), 0, 90));
                //   FaceEOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
            else
            {
                rotation = Quaternion.Euler(Mathf.Clamp(360 - (360 + twistPiece.changeInRotation), 270, 360), 0, 0);
                //  FaceFOrigin.transform.localRotation = currentLocalRotation * rotation;

            }
        }
        if (index == 0)
        {
            //rotation = Quaternion.Euler(0, Mathf.Clamp(360 - (360 + twistPiece.changeInRotation), 270, 360), 0);
            FaceAOrigin.transform.localRotation = currentLocalRotation * (rotation) ;

        }
        else if (index == 1)
        {
            //rotation = Quaternion.Euler(Mathf.Clamp((360 + twistPiece.changeInRotation), 0, 90), 0, 0);
            FaceBOrigin.transform.localRotation = currentLocalRotation * rotation;

        }
        else if (index == 2)
        {
            //rotation = Quaternion.Euler(0, 0, Mathf.Clamp(360 - (360 + twistPiece.changeInRotation), 270, 360));
            FaceCOrigin.transform.localRotation = currentLocalRotation * rotation;

        }
        else if (index == 3)
        {
            //rotation = Quaternion.Euler(0, Mathf.Clamp((360 + twistPiece.changeInRotation), 0, 90), 0);
            FaceDOrigin.transform.localRotation = currentLocalRotation * rotation;

        }
        else if (index == 4)
        {
            //rotation = Quaternion.Euler(0, 0, Mathf.Clamp((360 + twistPiece.changeInRotation), 0, 90));
            FaceEOrigin.transform.localRotation = currentLocalRotation * rotation;

        }
        else
        {
            //  rotation = Quaternion.Euler(Mathf.Clamp(360 - (360 + twistPiece.changeInRotation), 270, 360), 0, 0);
            FaceFOrigin.transform.localRotation = currentLocalRotation * rotation;

        }
    //    other.SetText("X - " + rotation.x.ToString() + " Y - " + rotation.y.ToString() + " Z - " + rotation.z.ToString());
        
    }
    public void StartRotation(int index, TwistPiece twistPiece)
    {
        currentTP = twistPiece;
        currentTPIndex = index;
        isRotating = true;
        if (index == 0)
        {
           currentLocalRotation= FaceAOrigin.transform.localRotation;
            ACollect.OnGrabbed();
        }
        else if (index == 1)
        {
            currentLocalRotation = FaceBOrigin.transform.localRotation;
            BCollect.OnGrabbed();
        }
        else if (index == 2)
        {
            currentLocalRotation = FaceCOrigin.transform.localRotation;
            CCollect.OnGrabbed();
        }
        else if (index == 3)
        {
            currentLocalRotation = FaceDOrigin.transform.localRotation;
            DCollect.OnGrabbed();
        }
        else if (index == 4)
        {
            currentLocalRotation = FaceEOrigin.transform.localRotation;
            ECollect.OnGrabbed();
        }
        else
        {
            currentLocalRotation = FaceFOrigin.transform.localRotation;
            FCollect.OnGrabbed();
        }
    }
    public void EndRotation(int index, TwistPiece twistPiece)
    {
        
        isRotating = false;
        if (index == 0)
        {
            
           
            FaceAOrigin.transform.localRotation = currentLocalRotation;
            if((twistPiece.changeInRotation > 45 && twistPiece.changeInRotation < 180) || (twistPiece.changeInRotation < -180 && twistPiece.changeInRotation > -310))
            {
                RotateFaceRandomizer(index, true);
            }else if((twistPiece.changeInRotation >= 180 && twistPiece.changeInRotation <= 310) || (twistPiece.changeInRotation < -45 && twistPiece.changeInRotation > -180))
            {
                RotateFaceRandomizer(index, false);
            }
            ACollect.OnRelease();
        }
        else if (index == 1)
        {
            FaceBOrigin.transform.localRotation = currentLocalRotation;
            if ((twistPiece.changeInRotation > 45 && twistPiece.changeInRotation < 180) || (twistPiece.changeInRotation < -180 && twistPiece.changeInRotation > -310))
            {
                RotateFaceRandomizer(index, true);
            }
            else if ((twistPiece.changeInRotation >= 180 && twistPiece.changeInRotation <= 310) || (twistPiece.changeInRotation < -45 && twistPiece.changeInRotation > -180))
            {
                RotateFaceRandomizer(index, false);
                
            }
            BCollect.OnRelease();
        }
        else if (index == 2)
        {
            FaceCOrigin.transform.localRotation = currentLocalRotation;
            if ((twistPiece.changeInRotation > 45 && twistPiece.changeInRotation < 180) || (twistPiece.changeInRotation < -180 && twistPiece.changeInRotation > -310))
            {
                RotateFaceRandomizer(index, true);
            }
            else if ((twistPiece.changeInRotation >= 180 && twistPiece.changeInRotation <= 310) || (twistPiece.changeInRotation < -45 && twistPiece.changeInRotation > -180))
            {
                RotateFaceRandomizer(index, false);
            }
            CCollect.OnRelease();
        }
        else if (index == 3)
        {
            FaceDOrigin.transform.localRotation = currentLocalRotation;
            if ((twistPiece.changeInRotation > 45 && twistPiece.changeInRotation < 180) || (twistPiece.changeInRotation < -180 && twistPiece.changeInRotation > -310))
            {
                RotateFaceRandomizer(index, true);
            }
            else if ((twistPiece.changeInRotation >= 180 && twistPiece.changeInRotation <= 310) || (twistPiece.changeInRotation < -45 && twistPiece.changeInRotation > -180))
            {
                RotateFaceRandomizer(index, false);
            }
            DCollect.OnRelease();
        }
        else if (index == 4)
        {
            FaceEOrigin.transform.localRotation = currentLocalRotation;
            if ((twistPiece.changeInRotation > 45 && twistPiece.changeInRotation < 180) || (twistPiece.changeInRotation < -180 && twistPiece.changeInRotation > -310))
            {
                RotateFaceRandomizer(index, true);
            }
            else if ((twistPiece.changeInRotation >= 180 && twistPiece.changeInRotation <= 310) || (twistPiece.changeInRotation < -45 && twistPiece.changeInRotation > -180))
            {
                RotateFaceRandomizer(index, false);
            }
            ECollect.OnRelease();
        }
        else
        {
            FaceFOrigin.transform.localRotation = currentLocalRotation;
            if ((twistPiece.changeInRotation > 45 && twistPiece.changeInRotation < 180) || (twistPiece.changeInRotation < -180 && twistPiece.changeInRotation > -310))
            {
                RotateFaceRandomizer(index, true);
            }
            else if ((twistPiece.changeInRotation >= 180 && twistPiece.changeInRotation <= 310) || (twistPiece.changeInRotation < -45 && twistPiece.changeInRotation > -180))
            {
                RotateFaceRandomizer(index, false);
            }
            FCollect.OnRelease();
        }

    }
    public void RotateFaceRandomizer(int index, bool isLeft)
    {
        float direction;
        if (isLeft)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        if(index == 0)
        {
            Quaternion rotation = Quaternion.Euler(0,-90*direction,0);
            FaceAOrigin.transform.localRotation *= rotation;
            RCLogic.RotateFace(RCLogic.faceA , isLeft);
        }
        else if(index == 1)
        {
            Quaternion rotation = Quaternion.Euler(90 * direction, 0, 0);
            FaceBOrigin.transform.localRotation *= rotation;
            RCLogic.RotateFace(RCLogic.faceB, isLeft);
        }
        else if (index == 2)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, -90 * direction);
            FaceCOrigin.transform.localRotation *= rotation;
            RCLogic.RotateFace(RCLogic.faceC, isLeft);
        }
        else if(index == 3)
        {
            Quaternion rotation = Quaternion.Euler(0, 90 * direction, 0);
            FaceDOrigin.transform.localRotation *= rotation;
            RCLogic.RotateFace(RCLogic.faceD, isLeft);
        }
        else if(index == 4){
            Quaternion rotation = Quaternion.Euler(0, 0, 90 * direction);
            FaceEOrigin.transform.localRotation *= rotation;
            RCLogic.RotateFace(RCLogic.faceE, isLeft);
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(-90 * direction, 0, 0);
            FaceFOrigin.transform.localRotation *= rotation;
            RCLogic.RotateFace(RCLogic.faceF, isLeft);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            RotateWithHand(currentTPIndex, currentTP);
        }
    }
}

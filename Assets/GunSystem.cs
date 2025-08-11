using JetBrains.Annotations;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    bool hasMagazine;
    bool roundChambered;
    bool safetyOn;

    [SerializeField] Transform safety;
    [SerializeField] ChargingHandle cHandle;

    [SerializeField] Chambs chamb;
    [SerializeField] ClearGunS clear;
    [SerializeField] ShootS shoot;
    [SerializeField] GameSystem gameSyst;
    [SerializeField] JamS jam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void MagazineIn()
    {
        hasMagazine = true;
    }
    public void MagazineOut()
    {
        hasMagazine = false;
    }
    public void ChargingHandlePulled()
    {
        if (hasMagazine)
        {
            roundChambered = true;
            if (chamb.isActiveAndEnabled)
            {
                chamb.Completed();
            }
        }
        else
        {
            roundChambered = false;
            if (clear.isActiveAndEnabled)
            {
                clear.Completed();
            }
        }
        if (jam.isActiveAndEnabled)
        {
            jam.Completed();
        }
    }
    public void SafetyToggled()
    {
        safetyOn = !safetyOn;
        if (safetyOn)
        {
            safety.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            safety.localRotation = Quaternion.Euler(0, 0, -90);
        }
    }
    public void ShootGun()
    {
        if (!safetyOn)
        {


            //Play gun shot
            if (roundChambered && !safetyOn)
            {
                if (cHandle.GunCicled())
                {
                    if (shoot.isActiveAndEnabled)
                    {
                        shoot.Completed();
                    }
                    //gun shot successfully
                }
                else
                {
                    if (shoot.isActiveAndEnabled)
                    {
                        shoot.Completed();
                    }
                    //gun Jammed
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

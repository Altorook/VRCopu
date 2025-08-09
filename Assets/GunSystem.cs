using JetBrains.Annotations;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    bool hasMagazine;
    bool roundChambered;
    bool safetyOn;

    [SerializeField] Transform safety;
    [SerializeField] ChargingHandle cHandle;
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
        }
        else
        {
            roundChambered = false;
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
        if(roundChambered && !safetyOn)
        {
            if (cHandle.GunCicled())
            {
                //gun shot successfully
            }
            else
            {
                //gun Jammed
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

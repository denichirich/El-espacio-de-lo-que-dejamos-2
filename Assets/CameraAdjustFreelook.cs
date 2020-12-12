using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAdjustFreelook : MonoBehaviour
{
    public CinemachineFreeLook freeLookCam;
    public float valBehind = 0.28f;

    // Start is called before the first frame update
    void Start()
    {
        freeLookCam = this.GetComponent<CinemachineFreeLook>();
        
    }
    public void Relocate()
    {
        this.freeLookCam.m_XAxis.Value = valBehind;


    }
}

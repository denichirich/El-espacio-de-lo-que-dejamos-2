using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActiveChanger : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;

    // Start is called before the first frame update
    public void EnableComponent()
    {
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();
        vCam.gameObject.SetActive(true);
    }
    public void DisableCamera()
    {
        vCam.gameObject.SetActive(false);
    }
}

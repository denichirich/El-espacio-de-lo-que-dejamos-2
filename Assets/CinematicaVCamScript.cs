using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicaVCamScript : MonoBehaviour
{
    public string searchTagDirector = "dirMostrarCorales";

    public double timeConf = 4.2f;


    // Start is called before the first frame update
    void Start()
    {
        NarrativeManager.instance.PostInteraction.AddListener(SwitchToThisCamera);
    }

    public void SwitchToThisCamera()
    {
        var director = GameObject.FindGameObjectWithTag(searchTagDirector).GetComponent<PlayableDirector>();
        var cam = director.GetComponent<Cinemachine.CinemachineVirtualCamera>();

        timeConf = director.playableAsset.duration ;

        CamerasManager.instance.SetCamera(cam);
        cam.Priority = 25;
        director.Play();


        Destroy(this.gameObject, (float)timeConf);
    }

}

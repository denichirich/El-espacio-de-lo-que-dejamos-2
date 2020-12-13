using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMulti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var thisScene = SceneManager.GetActiveScene();

        // load all scenes
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            // skip if is current scene since we don't want it twice
            if (thisScene.buildIndex == i) continue;

            // Skip if scene is already loaded
            if (SceneManager.GetSceneByBuildIndex(i).IsValid()) continue;

            SceneManager.LoadScene(i, LoadSceneMode.Additive);
            // or depending on your usecase
            //SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
        }

    }
}

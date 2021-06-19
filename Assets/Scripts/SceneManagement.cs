using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    /* This functions loads specified scene using scene index. 
     * This can be reused for different buttons as we are not using any specific scene in here.
     * But, instead we can specify it later in the inspector. */
    public void SceneLoader(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}

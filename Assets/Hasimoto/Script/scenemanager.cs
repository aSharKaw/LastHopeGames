using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{

    public void toNextScene()
    {
        SceneManager.LoadScene("Test_scenemanager");
    }

}
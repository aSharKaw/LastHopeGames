using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    
    public void toNextScene()
    {
        SceneManager.LoadScene("Admission");
    }

    int push_count = 0;
    float reset_time = 0;

    public void Update()
    {
        if(inputManager.GetDownRight1() || inputManager.GetDownLeft1())
        {
            push_count++;
            Debug.Log(push_count + "回 押された");
            reset_time = 0;
        }

        if(push_count >=3)
        {
            Debug.Log("シーン遷移しました");
            toNextScene();
        }

        if (reset_time > 120)
        {
            push_count = 0;
            reset_time = 0;
            Debug.Log("リセットされました");
        }

        if (push_count >= 1)
        {
            reset_time++;
        }

    }

}
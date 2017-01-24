using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{

    [SerializeField]
    private TitleSequence _titleSequemce1;

    [SerializeField]
    private TitleSequence _titleSequemce2;

    // Update is called once per frame
    void Update()
    {
        //終わっていたらシーン遷移
        if(_titleSequemce1.title_end && _titleSequemce2.title_end)
        {
            SceneManager.LoadScene("Admission");
        }
    }
}

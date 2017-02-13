using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    ResultManager manager;

    [SerializeField]
    private GameObject winOverObj;
    [SerializeField]
    private GameObject winUnderObj;
    [SerializeField]
    private GameObject loseOverObj;
    [SerializeField]
    private GameObject loseUnderObj;

    private Image overImage;
    private Image underImage;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private bool player1P;
    
    //ResultManagerを検索
    [SerializeField]
    private GameObject resultManager;
    [SerializeField]
    private GameObject canvas;

    private int winner;

    void Start()
    {
        manager = resultManager.GetComponent<ResultManager>();

        winner = manager.winner;

        if(player1P)
        {
            if (winner == 1)
            {
                Destroy(loseOverObj);
                Destroy(loseUnderObj);
                overImage = winOverObj.GetComponent<Image>();
                underImage = winUnderObj.GetComponent<Image>();
            }
            else if (winner == 2)
            {
                Destroy(winOverObj);
                Destroy(winUnderObj);
                overImage = loseOverObj.GetComponent<Image>();
                underImage = loseUnderObj.GetComponent<Image>();
            }
            else
            {
                Destroy(loseOverObj);
                Destroy(loseUnderObj);
                overImage = winOverObj.GetComponent<Image>();
                underImage = winUnderObj.GetComponent<Image>();
            }
        }
        else
        {
            if (winner == 1)
            {
                Destroy(winOverObj);
                Destroy(winUnderObj);
                overImage = loseOverObj.GetComponent<Image>();
                underImage = loseUnderObj.GetComponent<Image>();
            }
            else if (winner == 2)
            {
                Destroy(loseOverObj);
                Destroy(loseUnderObj);
                overImage = winOverObj.GetComponent<Image>();
                underImage = winUnderObj.GetComponent<Image>();
            }
            else
            {
                Destroy(loseOverObj);
                Destroy(loseUnderObj);
                overImage = winOverObj.GetComponent<Image>();
                underImage = winUnderObj.GetComponent<Image>();

            }
        }
        
        //消しておく
        underImage.color = new Color(underImage.color.r,
            underImage.color.g,
            underImage.color.b,
            0);
    }

    // Update is called once per frame
    void Update()
    {
        //現在のα値を取得
        float toColor = underImage.color.a;
        //α値が0か1になったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            _speed = _speed * -1;
        }

        //α値を弄り続ける
        underImage.color = new Color(underImage.color.r,
            underImage.color.g,
            underImage.color.b,
            toColor + _speed);
    }
}

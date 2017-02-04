using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

    ResultCamera cameraManager;
    ResultMothion mothionManager;
    //白フェード！
    //フラグ受け取る！
    //勝ったほうにWIN、負けたらLOSE表示！
    //Display間違えないように！
    //モーションは仕様書参考！カメラグルグル！
    //タイムで遷移・・・の前にプレイありがとう画面表示！と同時にプレイ回数カウント！
    //黒フェードで遷移！

    //・・・まあフェードじゃなくてそのままメインにくっつけてもいい気がするわ。

    //ここにHP渡せばあとはやってくれるよ
    private float player1HP = 1;
    private float player2HP;

    

    [SerializeField]
    private int cameraRotateSpeed;

    [SerializeField]
    private GameObject player1Obj, player2Obj;
    [SerializeField]
    private GameObject camera1P, camera2P;

    

    private int winner;

    private int count;
    [SerializeField]
    private int limitCount = 10;

    void Start ()
    {
        cameraManager = GetComponent<ResultCamera>();
        mothionManager = GetComponent<ResultMothion>();

        if (player1HP > player2HP)
        {
            winner = 1;
        }
        //2P Wins
        else if (player1HP < player2HP)
        {
            winner = 2;
        }
        //draw
        else
        {
            winner = 0;
        }

        cameraManager.cameraStart(winner, ref camera1P, ref camera2P);
        mothionManager.mothionStart(winner, ref player1Obj, ref player2Obj);
    }

    void Update ()
    {
        if(count > limitCount * 60)
        {
            SceneManager.LoadScene("Title");
        }
        cameraManager.cameraUpdate(cameraRotateSpeed, ref camera1P, ref camera2P);
        count++;
	}
}

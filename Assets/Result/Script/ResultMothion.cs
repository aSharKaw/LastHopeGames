using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMothion : MonoBehaviour {

    public void mothionStart (int winner, ref GameObject player1, ref GameObject player2)
    {
        if (winner == 1)
        {
            player1.GetComponent<Animator>().SetBool("win", true);
            player2.GetComponent<Animator>().SetBool("lose", true);
        }
        else if (winner == 2)
        {
            player1.GetComponent<Animator>().SetBool("lose", true);
            player2.GetComponent<Animator>().SetBool("win", true);
        }
        else
        {
            player1.GetComponent<Animator>().SetBool("win", true);
            player2.GetComponent<Animator>().SetBool("win", true);
        }
    }
}

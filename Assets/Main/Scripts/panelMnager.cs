
using UnityEngine;
using UnityEngine.UI;

public class panelMnager : MonoBehaviour
{
  GameObject panel1, panel2;

  void Start()
  {
    panel1 = GameObject.Find("Panel1");
    panel2 = GameObject.Find("Panel2");
  }

  void Update()
  {
    if (boxerState.Left1 || boxerState.Right1) // 通ってる
    {
      panel2.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
    }
    else
    {
      panel2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
    if (boxerState.Left2 || boxerState.Right2) // 通ってる
    {
      panel1.GetComponent<Image>().color = new Color(11, 0, 0, 0.5f);
    }
    else
    {
      panel1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
  }
}

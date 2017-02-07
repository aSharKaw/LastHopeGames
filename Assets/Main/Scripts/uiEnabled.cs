
using UnityEngine;
using UnityEngine.UI;

public class uiEnabled : MonoBehaviour
{
  void Awake()
  {
    GetComponent<Image>().enabled = false;
  }

  void Update()
  {
    if (pauseManager.getPause())
    {
      GetComponent<Image>().enabled = true;
    }
    else
    {
      GetComponent<Image>().enabled = false;
    }
  }
}

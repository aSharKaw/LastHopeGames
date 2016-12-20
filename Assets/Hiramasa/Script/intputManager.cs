
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class intputManager : MonoBehaviour
{
  private ushort count = 0;

  void Update()
  {
    if (Input.GetButtonDown("TalconghaLeft"))
    {
      count++;
      Debug.Log("Left Input " + count.ToString());
    }
    if (Input.GetButtonDown("TalconghaRight"))
    {
      count++;
      Debug.Log("Right Input " + count.ToString());
    }
    if (Input.GetButtonDown("TalconghaStart"))
    {
      count++;
      Debug.Log("Start Input " + count.ToString());
    }
  }
}

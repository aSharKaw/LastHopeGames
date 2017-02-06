
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class index : MonoBehaviour
{
  private boxerState boxerState = new boxerState();

  private List<Object> myList;

  void Update()
  {
    myList.Add(boxerState);
  }
}

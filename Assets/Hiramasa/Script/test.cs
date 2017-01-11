
using UnityEngine;

public class test : MonoBehaviour
{
  //private Animator animator;

  void Start()
  {
    //animator = GetComponent<Animator>();
  }

  void Update()
  {
    //if (Input.GetKeyDown(KeyCode.Space))
    //{
    //  animator.SetBool("RightPunch", true);
    //}
    //else
    //{
    //  animator.SetBool("RightPunch", false);
    //}
    if (inputManager.GetDown1PLeft())
    {
      Debug.Log("GetDown1PLeft");
    }
    if (inputManager.GetDown1PRight())
    {
      Debug.Log("GetDown1PRight");
    }
    if (inputManager.GetDown1PStart())
    {
      Debug.Log("GetDown1PStart");
    }

    if (inputManager.GetDown2PLeft())
    {
      Debug.Log("GetDown2PLeft");
    }
    if (inputManager.GetDown2PRight())
    {
      Debug.Log("GetDown2PRight");
    }
    if (inputManager.GetDown2PStart())
    {
      Debug.Log("GetDown2PStart");
    }
  }
}

using UnityEngine;

public class movecamera : MonoBehaviour
{

    [SerializeField]
    float rotatey = 1;

    void Update ()
    {
        transform.Rotate(0, rotatey, 0);
    }

}

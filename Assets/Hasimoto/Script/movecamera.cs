using UnityEngine;

public class movecamera : MonoBehaviour
{

    float rotate_y = 0.1f;
    float move_x = 0;

    void Update ()
    {
        move_x += 0.1f;
        transform.Rotate(0, rotate_y, 0);
        transform.Translate(100 * Mathf.Sin(move_x), 0, 100 * Mathf.Cos(move_x));
    }

}

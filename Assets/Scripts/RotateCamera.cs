using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    float speed;

    void Update()
    {
        Vector3 dir = Vector3.zero;

        // Phone
        dir.y = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();



        // Tastiera
        if (Input.GetKey(KeyCode.RightArrow) && transform.localEulerAngles.y > -50f)
        {
            dir = Vector3.up;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.localEulerAngles.y < 50f)
        {
            dir = Vector3.down;
        }

        dir *= Time.deltaTime * speed;

        transform.Rotate(dir);
    }

    
}

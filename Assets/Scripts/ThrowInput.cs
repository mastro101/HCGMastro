using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowInput : MonoBehaviour {

    [SerializeField]
    float minMagnitudeSlice;
    Vector2 sliceVector;

    Ray mouseRay;
    RaycastHit mousePosition;

    Vector2 startPosition;
    Vector2 endPosition;
    private void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay, out mousePosition);


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
                Debug.Log("tacciato");
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endPosition = touch.position;
                sliceVector = endPosition - startPosition;
                Debug.Log("lasciato");

                if (sliceVector.magnitude > minMagnitudeSlice)
                {
                    throwObject();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startPosition = mousePosition.point;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            endPosition = mousePosition.point;
            sliceVector = endPosition - startPosition;
            Debug.Log("lasciato " + sliceVector.magnitude);
            if (sliceVector.magnitude > minMagnitudeSlice)
            {
                throwObject();
            }
        }
    }

    void throwObject()
    {
        Debug.Log("Lanciato");
    }
}

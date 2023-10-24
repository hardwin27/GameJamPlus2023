using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardingVisual : MonoBehaviour
{
    private Vector3 _cameraDirection;

    private void Update()
    {
        if (Camera.main != null)
        {
            _cameraDirection = Camera.main.transform.forward;
            /*_cameraDirection.y = 0;*/
        }

        transform.rotation = Quaternion.LookRotation(_cameraDirection);
    }
}

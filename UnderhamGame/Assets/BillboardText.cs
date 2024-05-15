using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(90, 0, 0);
    }

}

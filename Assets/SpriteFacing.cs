using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFacing : MonoBehaviour
{
    public Camera _Camera;
    public void LateUpdate()
    {
        transform.forward = _Camera.transform.forward;
    }
}

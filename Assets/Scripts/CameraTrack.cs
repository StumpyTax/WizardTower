using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraTrack : MonoBehaviour
{
    [FormerlySerializedAs("gameObject")] public GameObject trackedO;
    
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 tmp = new Vector3(trackedO.transform.position.x, trackedO.transform.position.y,trackedO.transform.position.z - 5);
        transform.position = tmp;
    }
}

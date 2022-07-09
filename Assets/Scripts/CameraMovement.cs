using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;
    private Vector3 dragOrigin;

    [SerializeField] private float zoomStep;
    [SerializeField] private float minCamSize;
    [SerializeField] private float maxCamSize;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        PanCamera();
    }

    private void PanCamera() {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            ZoomIn(false);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            ZoomIn(true);
        }
    }

    public void ZoomIn(bool increase) {
        float newSize = increase ? cam.orthographicSize + zoomStep : cam.orthographicSize - zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
}

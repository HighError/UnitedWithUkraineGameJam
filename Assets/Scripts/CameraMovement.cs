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

    private float minX = 1.5f;
    private float maxX = 15f;
    private float minY = 0.5f;
    private float maxY = 13.75f;


    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (!BaseWindow.isWindowActive)
        {
            PanCamera();
        }
    }

    private Vector3 ClampCamera(Vector3 targetPosition) {
        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);
        return new Vector3 (newX, newY, targetPosition.z);
    }

    private void PanCamera() {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position + difference);
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

        cam.transform.position = ClampCamera(cam.transform.position);
    }
}

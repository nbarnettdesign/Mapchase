using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanWithMouse : MonoBehaviour
{

    public Vector3 dragStart;
    public bool wasDown = false;
    public Vector3 cameraOffset = new Vector3(10, 10, 10);
    Vector3 camSpeed;

    private GameObject map;


    void Start()
    {
        map = GameObject.FindWithTag("Map");
        OnCameraMoved();
    }

    void OnCameraMoved()
    {
        if (map)
        {
            cameraOffset = transform.position - map.transform.position;
        }
    }

    void Update()
    {
        if (!map)
        {
            Debug.Log("Could not find map");
            return;
        }
        
        bool NowDown = Input.GetMouseButton(0);

        if (!wasDown && NowDown)
        {
            Debug.Log("start drag");
            dragStart = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        }
        else if (wasDown && NowDown)
        {
            Vector3 DragPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            Vector3 Delta = dragStart - DragPos;
            Debug.Log(Delta);
            cameraOffset += Delta;
        }
        wasDown = NowDown;

        transform.position = map.transform.position + cameraOffset;

    }
}

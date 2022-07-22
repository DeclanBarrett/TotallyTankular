using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.LookAt(Camera.main.transform);
        offset = new Vector3(0, Camera.main.transform.position.y - canvasLocation.transform.position.y, Camera.main.transform.position.z - canvasLocation.transform.position.z);
        Cursor.visible = false;
    }
    Vector3 offset;
    public Canvas canvasLocation;
    // Update is called once per frame
    void Update()
    {
        
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(cursorPosition);
        this.transform.position = cursorPosition; // - offset;
    }
}

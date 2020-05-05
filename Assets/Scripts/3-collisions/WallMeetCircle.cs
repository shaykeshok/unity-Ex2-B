using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMeetCircle : MonoBehaviour
{
    private Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        if (viewPos.y > screenBounds.y - objectHeight)
            viewPos.y = (screenBounds.y - objectHeight) * -1;
        else if (viewPos.y < (screenBounds.y - objectHeight) * -1)
            viewPos.y = (screenBounds.y - objectHeight);

        if (viewPos.x > screenBounds.x - objectWidth)
            viewPos.x = (screenBounds.x - objectWidth) * -1;
        else if (viewPos.x < (screenBounds.x - objectWidth) * -1)
            viewPos.x = (screenBounds.x - objectWidth);
        transform.position = viewPos;
    }

}


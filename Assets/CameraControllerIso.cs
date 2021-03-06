﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerIso : MonoBehaviour
{
    public Vector3 clampMin;
    public Vector3 clampMax;
    private void Update()
    {
        float translationX = Input.GetAxis("Horizontal")/ 2;
        float translationY = Input.GetAxis("Vertical")/ 2;
        float fastTranslationX = translationX * 2;
        float fastTranslationY = translationY * 2;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(fastTranslationX + fastTranslationY, 0, fastTranslationY - fastTranslationX);
        }
        else
        {
            transform.Translate(translationX + translationY, 0, translationY - translationX);
        }

        //mouse scrolling  
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        int scrollDistance = 1;
        float scrollSpeed = 70;

        //Horizontal camera movement
        //horizontal, left
        if (mousePosX < scrollDistance)
        {
            transform.Translate(-1, 0, 1);
        }
        //horizontal, right
        if (mousePosX >= Screen.width - scrollDistance)
        {
            transform.Translate(1, 0, -1);
        }

        //Vertical camera movement
        //scrolling down
        if (mousePosY < scrollDistance)
        {
            transform.Translate(-1, 0, -1);
        }
        //scrolling up
        if (mousePosY >= Screen.height - scrollDistance)
        {
            transform.Translate(1, 0, 1);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.orthographicSize -= 4;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 30, 80);
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.orthographicSize += 4;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 30, 80);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, clampMin.x, clampMax.x), transform.position.y, Mathf.Clamp(transform.position.z, clampMin.z, clampMax.z));

    }

}

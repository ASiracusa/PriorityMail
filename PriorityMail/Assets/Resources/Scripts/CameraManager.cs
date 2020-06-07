﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager current;

    private GameObject camAnchor;
    private Camera cam;

    void Start()
    {
        current = this;

        camAnchor = GameObject.Find("CameraAnchor");
        cam = GameObject.Find("CameraAnchor/Camera").GetComponent<Camera>();

        StartCoroutine(CursorEvents());
        StartCoroutine(RotateBoard());
    }

    private IEnumerator CursorEvents()
    {
        while (true)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, ~8))
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    Click(Input.GetMouseButtonDown(0), hit);
                }
                else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
                {
                    Release(Input.GetMouseButtonUp(0), hit);
                }
                else
                {
                    Hover(hit);
                }
            }

            yield return null;
        }
    }

    private IEnumerator RotateBoard()
    {
        float pos = 0;
        float velocity = 0;

        while (true)
        {
            if (Input.GetKey(KeyCode.A) && velocity < 1f)
            {
                velocity += Time.deltaTime / 5;
            }
            if (Input.GetKey(KeyCode.D) && velocity > -1f)
            {
                velocity -= Time.deltaTime / 5;
            }

            if (Input.GetMouseButton(2))
            {
                velocity = Input.GetAxis("Mouse X") / 15f;
            }

            pos += velocity;

            camAnchor.transform.position = new Vector3(17 * -Mathf.Sin(pos), 20, 17 * -Mathf.Cos(pos));
            camAnchor.transform.eulerAngles = new Vector3(45, pos * 180 / Mathf.PI, 0);

            velocity *= 0.95f;

            yield return null;
        }
    }

    public event Action<RaycastHit> onHover;
    public void Hover(RaycastHit hit)
    {
        onHover?.Invoke(hit);
    }

    public event Action<bool, RaycastHit> onClick;
    public void Click(bool left, RaycastHit hit)
    {
        onClick?.Invoke(left, hit);
    }

    public event Action<bool, RaycastHit> onRelease;
    public void Release(bool left, RaycastHit hit)
    {
        onRelease?.Invoke(left, hit);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfield : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    private static int points;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
      transform.position = startPosition + Vector3.forward * newPosition;
        if (GameController.points >= 100)
        {
            scrollSpeed = (-3);
        }
    }
}
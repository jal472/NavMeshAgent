﻿using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }

}

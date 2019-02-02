using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimArrow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Ball.OnAimingStateChanged += ToggleAimArrow;
    }

    private void OnDisable()
    {
        Ball.OnAimingStateChanged -= ToggleAimArrow;
    }

    private void ToggleAimArrow(bool aimingState)
    {
        spriteRenderer.enabled = aimingState;
    }

    private void Update()
    {
        transform.rotation = Mouse.FaceMouse(transform.position);
    }
}

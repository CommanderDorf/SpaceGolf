using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceMeter : MonoBehaviour
{

    [SerializeField] private Image forceMeterFill;

    private void OnEnable()
    {
        Ball.OnPowerChanged += UpdateForceMeter;
        Ball.OnAimingStateChanged += ToggleForceMeter;
    }

    private void OnDisable()
    {
        Ball.OnPowerChanged -= UpdateForceMeter;
        Ball.OnAimingStateChanged -= ToggleForceMeter;
    }

    public void UpdateForceMeter(float force, float maxForce)
    {
        forceMeterFill.fillAmount = force / maxForce;
    }

    public void ToggleForceMeter(bool visible)
    {
        forceMeterFill.enabled = visible;
    }

    private void Update()
    {
        transform.rotation = Mouse.FaceMouse(transform.position);
    }
}
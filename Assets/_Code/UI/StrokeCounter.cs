using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StrokeCounter : MonoBehaviour
{
    private TextMeshProUGUI countTMP;

    private void Awake()
    {
        countTMP = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameController.OnStrokeChanged += UpdateCounter;
    }

    private void OnDisable()
    {
        GameController.OnStrokeChanged -= UpdateCounter;
    }

    private void UpdateCounter(int strokeCount)
    {
        countTMP.text = strokeCount.ToString();
    }
}

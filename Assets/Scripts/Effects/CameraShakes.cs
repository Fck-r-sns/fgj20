﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakes : MonoBehaviour
{

    private Transform _transform;
    
    [SerializeField]
    private float _shakeDuration = 0f;	
    
    [SerializeField]
    private float _shakeAmount = 0.7f;
    
    [SerializeField]
    private float _decreaseFactor = 1.0f;
    
    	
    private Vector3 _originalPos;
    
    private void Awake()
    {
        _transform = transform;
    }
    
    private void OnEnable()
    {
        _originalPos = _transform.localPosition;
    }

    public void Shake(float duration)
    {
        _shakeDuration = duration;
        enabled = true;
    }
    
    private void LateUpdate()
    {
        if (_shakeDuration > 0)
        {
            _transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;
			
            _shakeDuration -= Time.deltaTime * _decreaseFactor;
        }
        else
        {
            _shakeDuration = 0f;
            enabled = false;
            _transform.localPosition = _originalPos;
        }
    }
}
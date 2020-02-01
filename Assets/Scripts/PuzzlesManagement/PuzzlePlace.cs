﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlace : MonoBehaviour//, IInteractive
{
    public event Action OnFix;

    [SerializeField] private Transform _puzzlePoint;

    [SerializeField] private GameObject _indicator;
    
    void Awake()
    {        
        _indicator.SetActive(false);      
    }

    public void InitWithPuzzle(GameObject puzzleObject)
    {
        puzzleObject.transform.SetParent(_puzzlePoint);
        puzzleObject.transform.localPosition = Vector3.zero;        
        puzzleObject.transform.localRotation = Quaternion.identity;        
        puzzleObject.transform.Rotate(90, 0, 0);
        puzzleObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        
        _puzzlePoint.gameObject.SetActive(false);
    }

    public void Break()
    {
         _indicator.SetActive(true);
        _puzzlePoint.gameObject.SetActive(true);
    }

    public void Fix()
    {
        _puzzlePoint.gameObject.SetActive(false);
        _indicator.SetActive(false);
        OnFix?.Invoke();
        GetComponentInChildren<IInteractive>().StopInteraction();        
    }
}

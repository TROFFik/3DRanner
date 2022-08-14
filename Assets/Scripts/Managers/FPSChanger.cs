using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSChanger : MonoBehaviour
{
    [SerializeField] private int fps;
    void Start()
    {
        Application.targetFrameRate = fps;
    }
}

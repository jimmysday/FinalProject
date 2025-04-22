using NUnit.Framework;
using System.Xml.Linq;
using System;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class MainDoorTrigger : MonoBehaviour
{
    [SerializeField] private MainDoorContrall doorControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.tag == "Player" ){
            Debug.Log("enter trigger");
            doorControl.Operate();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger Exit");
        if (other.tag == "Player" ){
            Debug.Log("exit trigger");
            doorControl.Operate();
        }
    }
}

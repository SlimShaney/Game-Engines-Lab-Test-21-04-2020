using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class trafficLightInstantiator : MonoBehaviour
{
    private readonly GameObject[] _trafficLights = new GameObject[10];
    
    void Start()
    {
        CreateTrafficLights();
        CreateCar();
    }

    void CreateTrafficLights()
    {
        for (int i = 0; i < _trafficLights.Length; i++)
        {
            GameObject trafficLightInstance = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            trafficLightInstance.AddComponent<lightscript>();
            trafficLightInstance.transform.parent = transform;
            
            trafficLightInstance.name = "Traffic Light #" + (i + 1);
            transform.eulerAngles = new Vector3(0, 360/_trafficLights.Length * i, 0);
            trafficLightInstance.transform.position = Vector3.forward * 10;
            _trafficLights[i] = trafficLightInstance;            
        }
    }

    void CreateCar()
    {
        GameObject carInstance = GameObject.CreatePrimitive(PrimitiveType.Cube);
        carInstance.AddComponent<carScript>();
        carInstance.name = "Car";
    }
}
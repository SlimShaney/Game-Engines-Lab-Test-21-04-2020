using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagement : MonoBehaviour
{
    public GameObject[] trafficLights = new GameObject[10];
    
    void Start()
    {
        CreateTrafficLights();
        CreateCar();
    }

    void CreateTrafficLights()
    {
        for (int i = 0; i < trafficLights.Length; i++)
        {
            GameObject trafficLightInstance = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            trafficLightInstance.AddComponent<lightscript>();
            trafficLightInstance.transform.parent = transform;
            
            trafficLightInstance.name = "Traffic Light #" + (i + 1);
            transform.eulerAngles = new Vector3(0, 360/trafficLights.Length * i, 0);
            trafficLightInstance.transform.position = Vector3.forward * 10;
            trafficLights[i] = trafficLightInstance;            
        }
    }

    void CreateCar()
    {
        GameObject carInstance = GameObject.CreatePrimitive(PrimitiveType.Cube);
        carInstance.transform.localScale = new Vector3(1, 1, 1.5f);
        carInstance.AddComponent<carScript>();
        carInstance.name = "Car";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carScript : MonoBehaviour
{

    private Renderer _colourRenderer;

    private gameManagement _managerScript;
    private GameObject _target;
    public Renderer lightColour;

    private Vector3 velocity;
    private float maxVelocity = 3;
    private float maxForce = 1;
    
    void Start()
    {
        _colourRenderer = GetComponent<MeshRenderer>();
        _colourRenderer.material.color = Color.magenta;
        _managerScript = FindObjectOfType<gameManagement>();
        velocity = Vector3.zero;
        TargetSelect();
    }

    void Update()
    {
        if (lightColour.material.color != Color.green || 
            (Vector3.Distance(this.transform.position, _target.transform.position) <= 0.2))
        {
            TargetSelect();
        }
        MoveToTarget();
        
        
    }

    void TargetSelect()
    {
        _target = _managerScript.trafficLights[Random.Range(0, _managerScript.trafficLights.Length)];
        lightColour = _target.GetComponent<Renderer>();
    }

    void MoveToTarget()
    {
        var desiredVelocity = _target.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * maxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        velocity = Vector3.ClampMagnitude(velocity + steering, maxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;        
    }
}

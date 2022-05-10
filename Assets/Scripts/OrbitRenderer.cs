using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitRenderer : MonoBehaviour
{
    public LineRenderer lr;
    public Orbit orbit;
    public Rigidbody rb;
    int segments = 100;

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            float nu = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
            float u = orbit.omega + nu;
            float r = orbit.a * (1 - orbit.e * orbit.e) / (1 + orbit.e * Mathf.Cos(nu));
            float x = r * (Mathf.Cos(u) * Mathf.Cos(orbit.RAAN) - Mathf.Sin(u) * Mathf.Cos(orbit.i) * Mathf.Sin(orbit.RAAN));
            float y = r * (Mathf.Cos(u) * Mathf.Sin(orbit.RAAN) + Mathf.Sin(u) * Mathf.Cos(orbit.i) * Mathf.Cos(orbit.RAAN));
            float z = r * (Mathf.Sin(u) * Mathf.Sin(orbit.i));
            //float x = Mathf.Sin(angle) * xAxis;
            //float x = orbit.a * (Mathf.Cos(E) - orbit.e);
            //float y = Mathf.Cos(angle) * yAxis;
            //float y = orbit.a * Mathf.Sqrt(1 - orbit.e * orbit.e) * Mathf.Sin(E);
            points[i] = new Vector3(x, z, y) + rb.position; // Unity puts the z axis where I would normally have the y axis
        }
        points[segments] = points[0];
        lr.positionCount = segments + 1;
        lr.SetPositions(points);

    }

    void OnValidate()
    {
        CalculateEllipse();
    }
   
    // Start is called before the first frame update
    void Start()
    {
        CalculateEllipse();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateEllipse();
    }
}

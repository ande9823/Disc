using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOrigin = new Vector3();
    Vector3 temPos = new Vector3();

    private void Start()
    {
        posOrigin = transform.position;
    }

    private void Update()
    {
        temPos = posOrigin;
        temPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = temPos;
    }
}

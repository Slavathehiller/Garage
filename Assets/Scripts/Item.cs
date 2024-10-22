using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Light _light;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void LightOn(bool swich)
    {
        _light.enabled = swich;
    }

    public void Drop()
    {
        transform.parent = null;
        _rb.isKinematic = false;
    }
}

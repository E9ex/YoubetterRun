using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ragdollController : MonoBehaviour
{
    private List<Collider> _colliders = new List<Collider>();
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    public Animator Animator;
    private void Awake()
    {
        _colliders = GetComponentsInChildren<Collider>().ToList();
        _rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
        foreach (var collider in _colliders)
        {
            collider.enabled = false;
        }
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
    }
    public void OpenRigidbody()
    {
        Animator.enabled = false;
        foreach (var collider in _colliders)
        {
            collider.enabled = true;
            collider.isTrigger = false;
        }
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
        }
    }
}// class

using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    private float _radius = 10f;
    private float _explosionForce = 250f;

    private bool _explodeThisFrame = false;
    private Vector3 _centerExplosion;
    private List<Rigidbody> _explosiveObjects;

    private void FixedUpdate()
    {
        if (_explodeThisFrame)
        {
            if (_centerExplosion != null)
            {
                for (int i = 0; i < _explosiveObjects.Count; i++)
                {
                    if (_explosiveObjects[i] != null)
                        _explosiveObjects[i].AddExplosionForce(_explosionForce, _centerExplosion, _radius);
                }
            }

            _explodeThisFrame = false;
        }
    }

    public void Explode(Transform centerExplosion, List<Rigidbody> explosiveObjects)
    {
        if (centerExplosion != null && explosiveObjects != null)
        {
            _explodeThisFrame = true;
            _centerExplosion = centerExplosion.position;
            _explosiveObjects = explosiveObjects;
        }
    }
}
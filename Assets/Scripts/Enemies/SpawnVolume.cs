using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnVolume : MonoBehaviour
{
    private BoxCollider collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }
    public Vector3 GetPositionInBounds()
    {
        var bounds = collider.bounds;
        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), transform.position.y, Random.Range(bounds.min.z, bounds.max.z));
    }

}

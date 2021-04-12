using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    [SerializeField] private ItemScriptables pickup;
    [Tooltip("manual override for drop amount. if left at -1 it will use the amount from the scriptible Object")]
    [SerializeField] private int Amount = -1;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshFilter meshFilter;

    private ItemScriptables itemInstance;

    private void Awake()
    {
        if (meshRenderer == null) GetComponentInChildren<MeshRenderer>();
        if (meshFilter == null) GetComponentInChildren<MeshFilter>();
        Instantiate();
    }

    public void Instantiate()
    {
        itemInstance = Instantiate(pickup);
        if(Amount > 0) itemInstance.SetAmount(Amount);
        ApplyMesh();
    }

    private void ApplyMesh()
    {
        if (meshFilter) meshFilter.mesh = pickup.itemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        if (meshRenderer) meshRenderer.materials = pickup.itemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
    }

    private void OnValidate()
    {
        if (meshRenderer == null) GetComponentInChildren<MeshRenderer>();
        if (meshFilter == null) GetComponentInChildren<MeshFilter>();
        ApplyMesh();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        itemInstance.UseItem(other.GetComponent<PlayerController>());

    }
}

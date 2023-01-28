using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpriteComponent : MonoBehaviour
{
    [SerializeField] private Mesh[] prefabs;
    private int currentPrefab;
    private MeshFilter meshFilter;
    private void Awake() {
        meshFilter = GetComponent<MeshFilter>();
    }

    [ContextMenu("Switch")]
    public void Switch(){
        currentPrefab = (int)Mathf.Repeat(currentPrefab+1, prefabs.Length);
        meshFilter.mesh = prefabs[currentPrefab];
    }
}

using UnityEngine;

public class detailDistance : MonoBehaviour
{
    void Start()
    {
        Terrain.activeTerrain.detailObjectDistance = 4000;
    }
}
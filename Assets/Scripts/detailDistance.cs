using UnityEngine;

public class detailDistance : MonoBehaviour
{
    void Start()
    {
        Terrain.activeTerrain.detailObjectDistance = 3000;
    }
}
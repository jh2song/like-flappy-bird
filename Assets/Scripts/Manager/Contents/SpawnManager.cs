using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager
{
    public Object Pillar;

    public int[] OffsetX = { 10, 15, 20 };
    public int[] OffsetY = { -1, 0, 1 };

    public void Init()
    {
        Pillar = Resources.Load("Prefabs/Pillar");
    }

    public void Spawn()
    {
        int xIdx = Random.Range(0, OffsetX.Length);
        int yIdx = Random.Range(0, OffsetY.Length);
        Vector3 offsetVec = new Vector3(OffsetX[xIdx], OffsetY[yIdx], 0);

        GameObject.Instantiate(Pillar, Vector3.zero + offsetVec, Quaternion.identity);
    }
}

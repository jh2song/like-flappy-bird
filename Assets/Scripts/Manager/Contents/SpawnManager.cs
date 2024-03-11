using System.Collections;
using UnityEngine;

public class SpawnManager
{
    public Object Pillar;

    public float offsetX = 10f;
    public int[] OffsetY = { -1, 0, 1 };

    public void Init()
    {
        Pillar = Resources.Load("Prefabs/Pillar");
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            int yIdx = Random.Range(0, OffsetY.Length);
            Vector3 offsetVec = new Vector3(offsetX, OffsetY[yIdx], 0);

            GameObject.Instantiate(Pillar, offsetVec, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}

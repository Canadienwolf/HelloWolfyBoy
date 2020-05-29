using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPositions : MonoBehaviour
{
    public GameObject[] NPCPrefab;

    public Vector3 center;
    public Vector3 size;

    // Update is called once per frame
    public void OnClickSpawn()
    {
        SpawnNPC();
    }

    public void SpawnNPC()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(NPCPrefab[0], pos, Quaternion.identity);
        Instantiate(NPCPrefab[1], pos, Quaternion.identity);
        Instantiate(NPCPrefab[2], pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0,1,1,0.5f);
        Gizmos.DrawCube(center, size);
    }
}

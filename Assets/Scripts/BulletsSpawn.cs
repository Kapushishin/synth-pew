using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSpawn : MonoBehaviour
{
    public Transform spawnPos;
    public Vector2 range;
    public GameObject bullet;
    public float frequency;

    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        Vector2 pos = spawnPos.position + new Vector3(0, range.y);
        Instantiate(bullet, pos, Quaternion.identity);
        yield return new WaitForSeconds(frequency);
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(Spawn());
    }
}

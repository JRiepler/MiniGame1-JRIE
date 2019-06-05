using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabAirdrop;
    public GameObject boundaryLeft;
    public GameObject boundaryRight;
    public GameObject boundaryTop;
    public GameObject airdropParent;
    private bool spawn = true;

    public float minSpawnDelay = 1.0f;
    public float maxSpawnDelay = 5.0f;

    public int xMinLeft;
    public int xMaxLeft;
   // public float airdropMinSize = 0.1f;
    public float airdropSize = 0.05f;

    public float flyGravityMin = 0.1f;
    public float flyGravityMax = 0.8f;

    public int yPos;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        xMaxLeft = (int)boundaryRight.gameObject.transform.position.x;
        xMinLeft = (int)boundaryLeft.gameObject.transform.position.x;
        yPos = (int)boundaryTop.gameObject.transform.position.y;
    }

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnFly();
        }

    }

    private void SpawnFly()
    {
        // transform.position = new Vector3(Random.Range(xMinLeft, xMaxLeft), yPos, 0);

       // float airdropSize = Random.Range(airdropMinSize, airdropMaxSize);

        GameObject airdropClone = (GameObject)Instantiate(prefabAirdrop, transform.position, transform.rotation);
        airdropClone.transform.SetParent(airdropParent.transform);
        airdropClone.transform.localPosition = new Vector3(Random.Range(-6, +6),0, 0f);
        Debug.Log("Local Scale: " + airdropSize);
        airdropClone.transform.localScale = new Vector3(airdropSize, airdropSize, 0f);
        //flyClone.transform.localScale = new Vector3(1, 1, 0);
       // airdropClone.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2, 2), Random.Range(-10, -1));
    }
}
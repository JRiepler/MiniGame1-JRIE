using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirdropSpawn : MonoBehaviour
{
    public Airdrop airdropPrefab;
    public GameObject boundaryLeft;
    public GameObject boundaryRight;
    public GameObject boundaryTop;
    public GameObject flyParent;
    private bool spawn = true;

    public float minSpawnDelay = 1.0f;
    public float maxSpawnDelay = 5.0f;

    public int xMinLeft;
    public int xMaxLeft;
    public float flyMinSize = 0.1f;
    public float flyMaxSize = 0.5f;

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
            SpawnAirdrop();
        }

    }

    private void SpawnAirdrop()
    {
        // transform.position = new Vector3(Random.Range(xMinLeft, xMaxLeft), yPos, 0);

        float dropSize = Random.Range(dropMinSize, dropMaxSize);

        Airdrop dropClone = (Airdrop)Instantiate(airdropPrefab, transform.position, transform.rotation);
        dropClone.transform.SetParent(dropParent.transform);
        dropClone.transform.localPosition = new Vector3(Random.Range(xMinLeft, xMaxLeft), dropParent.transform.position.y, 0f);
        Debug.Log("Local Scale: " + dropSize);
        dropClone.transform.localScale = new Vector3(dropSize, dropSize, 0);
        //flyClone.transform.localScale = new Vector3(1, 1, 0);

        dropClone.GetComponent<SpriteRenderer>().sortingOrder = Random.Range(2, 8);
        if (dropClone.GetComponent<SpriteRenderer>().sortingOrder == 7)
        {
            dropClone.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        dropClone.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2, 2), Random.Range(-10, -1));
    }
}

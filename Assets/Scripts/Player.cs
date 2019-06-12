using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] Scoremanager myData;
    [SerializeField] TextMeshProUGUI scoreText;

    private const string AXISHORIZONTAL = "Horizontal";
    private float moveSpeed = 3.0f;

    private void Move()
    {
        var deltaX = Input.GetAxis(AXISHORIZONTAL) * Time.deltaTime * moveSpeed;
        var newPosX = Mathf.Clamp(transform.position.x + deltaX, -400f, 400f);

        transform.position = new Vector2(newPosX, transform.position.y);
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.tag == "Airdrop" && gameObject.name == "Truck")
        {
            Debug.Log("ScoreInPlayer" + myData.scoreValue);
            scoreText.text = myData.scoreValue.ToString();

        }
    }

}



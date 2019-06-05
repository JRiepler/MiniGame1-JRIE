using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Collectible : MonoBehaviour
{
    public Scoremanager myData;
    public GameObject displayText;
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = displayText.GetComponent<TextMeshProUGUI>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.name == "Truck" && collision.gameObject.tag == "Airdrop")
        {
            myData.scoreValue += 10;
            Destroy(gameObject, 0f);
            Debug.Log("Score" + myData.scoreValue);
            scoreText.text = myData.scoreValue.ToString();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BottomHitbox")
        {
            myData.scoreValue -= 1;
            Destroy(gameObject, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEvent" + collision.gameObject.name);
    }


}

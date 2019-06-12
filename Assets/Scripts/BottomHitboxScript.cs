using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomHitboxScript : MonoBehaviour {
    [SerializeField] Scoremanager myData;
    [SerializeField] TextMeshProUGUI scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerevent" + collision.gameObject.name);

        if (collision.gameObject.tag == "Airdrop" && gameObject.name == "BottomHitbox")
        {
            Debug.Log("ScoreInPlayer" + myData.scoreValue);
            scoreText.text = myData.scoreValue.ToString();

        }
    }

}

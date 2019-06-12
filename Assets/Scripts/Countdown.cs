using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float startTimeInSec = 10;
    public SceneLoader sceneLoader;

    private TextMeshProUGUI timeInSec;
    private float time;

    private void Start()
    {
        time = startTimeInSec;
        timeInSec = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeInSec.text = time.ToString("00");

        if (time <= 0)
        {
            sceneLoader.LoadSceneOutro();

        }
    }
}
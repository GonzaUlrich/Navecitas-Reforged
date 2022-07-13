using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2Movement : MonoBehaviour
{
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSpeed =2;
    private Text score;
    private int scoreNum;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        scoreNum = int.Parse(score.text);
        if (scoreNum > 1000)
        {
            movementSpeed *= 1.5f;
        }
    }
    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * movementSpeed;
    }
}

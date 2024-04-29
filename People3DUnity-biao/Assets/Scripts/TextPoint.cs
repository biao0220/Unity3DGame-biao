using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPoint : MonoBehaviour
{
    TMP_Text textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Total Enemy: " + EnemyGenerator.enemyCount + " Points: " + EnemyGenerator.point; 
    }
}

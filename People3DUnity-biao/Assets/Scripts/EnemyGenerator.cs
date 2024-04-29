using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float CD = 1f;
    private float timer = 0;
    public float enemyRange = 100f;
    public int totalEnemy = 100;
    public static int enemyCount = 0;
    public static int point = 0;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > CD && enemyCount < totalEnemy)
        {
            timer = 0;
            CD = Random.Range(0.3f, CD);
            //Vector3.forward (0, 0, 1)  Vector3.right  (1, 0, 0)
            Vector3 pos = transform.position + Vector3.forward * Random.Range(-enemyRange, enemyRange)
                          + Vector3.right * Random.Range(-enemyRange, enemyRange);

            Instantiate(enemyPrefab, pos, transform.rotation);

            enemyCount++;
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            Application.Quit();
        }
    }
}

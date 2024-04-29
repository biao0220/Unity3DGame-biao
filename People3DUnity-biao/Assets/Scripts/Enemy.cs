using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    //Enemy”ÎPlayerœ‡∏Ùæ‡¿Î
    private float distance;
    //ÀŸ∂»
    public float enemySpeed = 5f;
    //œÏ”¶æ‡¿Î
    public float repondDistance = 200;
    //À¿Õˆæ‡¿Î
    public float deathDistance = 0.8f;

    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance < repondDistance)
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        }

        if(distance < deathDistance)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Laser")
        {
            Instantiate(explosionPrefab,transform.position + new Vector3(0, 0.1f, 0), transform.rotation);
            Destroy(gameObject);
            EnemyGenerator.enemyCount--;
            EnemyGenerator.point++;

        }
    }
}

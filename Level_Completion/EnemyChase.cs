using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public int speed;
    [SerializeField] private GameObject player;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}

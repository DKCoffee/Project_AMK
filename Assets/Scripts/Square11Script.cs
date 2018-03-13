using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square11Script : MonoBehaviour {

    public enum EnemyState
    {
        WALK,
        ATTACK
    }

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    private float distance;
    [SerializeField] private float attackDistance;
    private bool inFieldOfView = false;
    private bool isAttacking = false;
    private EnemyState enemyState = EnemyState.WALK;

    [SerializeField] private Transform bulletSpawn;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletSpeed;

    [SerializeField] private float timeToShoot = 2;

    [SerializeField] private float lastTimeShoot;

    // Use this for initialization
    void Start()
    {
        target = FindObjectOfType<PlayerScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpawn.rotation = Quaternion.LookRotation(Vector3.forward, target.position - bulletSpawn.position);
    }

    public void Move()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        //Debug.Log("Distance" + distance);

        if (distance <= attackDistance)
        {
            inFieldOfView = true;

        }
        else
        {
            inFieldOfView = false;
        }
        //Debug.Log("is Attacking " + isAttacking);

        if (inFieldOfView)
        {
            enemyState = EnemyState.ATTACK;
        }
        else
        {
            enemyState = EnemyState.WALK;
        }

        switch (enemyState)
        {
            case EnemyState.WALK:
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                //BoyAnimation.SetFloat("Speed", moveSpeed);


                break;
            case EnemyState.ATTACK:

                Attack();
                //BoyAnimation.SetTrigger("IsAttack");
                break;
        }
    }

    private void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeShoot > timeToShoot)
        {
            GameObject Bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawn.up * bulletSpeed;
            Destroy(Bullet, 5);
            lastTimeShoot = Time.realtimeSinceStartup;

        }
    }
}

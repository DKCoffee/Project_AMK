using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] float speed;
    private Rigidbody2D body;

    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeToThrow = 2;
    [SerializeField] private float lastTimeThrow;

    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        body.velocity = movement;
        Debug.Log(Input.GetAxis("Horizontal"));

        Attack();
    }

    public void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)

        {
            GameObject Snowball = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            Snowball.GetComponent<Rigidbody2D>().velocity = bulletSpawn.right * bulletSpeed;
            Destroy(Snowball, 5);
            lastTimeThrow = Time.realtimeSinceStartup;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

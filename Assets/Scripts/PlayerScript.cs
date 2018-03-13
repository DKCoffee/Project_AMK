﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour {

    [SerializeField] float speed;
    private Rigidbody2D body;
    private float fullHealth = 15;
    private float health;
    private float percentageHealth = 100;
    public Text lifeText;

    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeToThrow = 2;
    [SerializeField] private float lastTimeThrow;

    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        health = fullHealth;
        SetLifeText();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        body.velocity = movement;

        Attack();
        playerDead();
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

    private void Health()
    {
        health = health - 1;
        percentageHealth = health / fullHealth*100;
        SetLifeText();
    }

    private void playerDead()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }

    private void SetLifeText()
    {
        lifeText.text = percentageHealth.ToString("F0")+" %";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OneDamage")
        {
            Health();
        }
    }
}

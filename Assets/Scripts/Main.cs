﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    public float radius;
    public GameObject enemy;
    public GameObject ring;
    public Quaternion rot;
    private int iframe;

    public float arenaRadius;
    public float enemyRadius;
    public Vector3 center;

    void Start() {
        center = gameObject.transform.position;
        SpawnEnemies();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            int bulletIteration = 0;
            foreach (Level.marker bullet in Level.bulletStructs) {
                Level.bulletStructs[bulletIteration].fired = false;
                bulletIteration++;
            }
            int warpIteration = 0;
            foreach (Level.marker warp in Level.warpStructs) {
                Level.warpStructs[warpIteration].fired = false;
                warpIteration++;
            }
            Level.song.time = 0;
            Level.lastBullet = 0;
            Level.lastWarp = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Level.spinRate += 1;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Level.spinRate -= 1;
        }

        iframe++;

        if (iframe > 30) {
            MakeRing();
            iframe = 0;
        }

        Level.checkMarkers();
    }

    void SpawnEnemies() {
        for (int i = 0; i < Level.enemies; i++) {
            float ang = i * Mathf.PI * 2f / Level.enemies;
            Vector3 newPos = new Vector3(Mathf.Cos(ang) * radius, Mathf.Sin(ang) * radius, 0);
            GameObject enemyInstance = Instantiate(enemy, newPos, Quaternion.identity);
            enemyInstance.gameObject.name = (i + 1).ToString();
            Enemy enemyObject = enemyInstance.GetComponent<Enemy>();
            enemyObject.i = i + 1;
        }
    }

    void MakeRing() {
        Instantiate(ring, new Vector3(0, 0, 0), rot);
    }
}

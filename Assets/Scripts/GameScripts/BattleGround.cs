using System;
using System.Collections;
using System.Collections.Generic;
using Ash.MyUtils;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleGround : MonoBehaviour
{
    public Collider2D collider2D;
    public List<EnemyController> enemies;
    public List<Transform> enemySpawnLocations;
    public CinemachineVirtualCamera battlegroundCam;
    public CameraController cam;
    public float radius;

    public Vector2 GetRandomPosition => new Vector2(Random.Range(cam.GetMinXBounds, cam.GetMaxXBounds),
                                            Random.Range(cam.GetMinYBounds, cam.GetMaxYBounds));
    
    private int spawnIndex = -1;

    private void Awake()
    {
        cam = FindObjectOfType<CameraController>();
    }

    public void DeactiveTrigger()
    {
        collider2D.enabled = false;
    }
    
    public Vector2 GetNextSpawnLocation()
    {
        spawnIndex++;
        if (spawnIndex > enemySpawnLocations.Count - 1)
            spawnIndex = 0;

        return enemySpawnLocations[spawnIndex].position;
    }

    public void ActivateCam()
    {
        battlegroundCam.enabled = true;
    }

    public void DeactivateCam()
    {
        battlegroundCam.enabled = false;
    }
}

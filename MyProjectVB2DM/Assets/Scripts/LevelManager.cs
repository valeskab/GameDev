using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class LevelManager : MonoBehaviour
{
    private PoolingBehaviour pooler;
    private int createdTiles;

    private TileBehaviour lastTile;
    //[Header("Tiles")]
    [SerializeField] private TileBehaviour firstTile;
    [SerializeField] private int normalTileLenght = 11;

    private void Awake()
    {
        GetComponent<PoolingBehaviour>();
    }

    private void Start()
    {
        lastTile = firstTile;
    }

    private void CreateTile()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            AddThisTile(normalTileLenght);
        }
    }

    private void AddThisTile(float lenght)
    {
        StabilizeNewTilePos(lenght);
        createdTiles++;
    }


    private Vector3 StabilizeNewTilePos(float lenght)
    {
        return lastTile.transform.position + Vector3.forward * lenght;
    }

    private void AnswerNewBlockRequest()
    {
        CreateTile();
    }

    private void OnEnable()
    {
        Limit.NewBlockRequestEvent += AnswerNewBlockRequest;
    }

    private void OnDisable()
    {
        Limit.NewBlockRequestEvent -= AnswerNewBlockRequest;
    }
}

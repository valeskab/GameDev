using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Normal,
    Enemy,
    Coins
}
public class TileBehaviour : MonoBehaviour
{
    [SerializeField] private TileType tileType;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float playerRespawnTime;
    [SerializeField] private Vector2 playerStartPosition;

    private GameObject player;
    private float playerRespawnCounter;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More that 1 GameManager instance!");
        }

        Instance = this;

        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (player != null)
        {
            Destroy(player);
        }

        GameObject newPlayer = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        player = newPlayer;

        playerRespawnCounter = playerRespawnTime;
    }

    private void Update()
    {
        playerRespawnCounter -= Time.deltaTime;

        if (playerRespawnCounter <= 0f)
        {
            SpawnPlayer();
        }
    }
}

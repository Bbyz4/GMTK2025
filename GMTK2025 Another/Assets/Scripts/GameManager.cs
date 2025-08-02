using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float playerRespawnTime;
    [SerializeField] private Vector2 playerStartPosition;

    private GameObject player;
    private float playerRespawnCounter;

    //0 - double jump, 1 - glide, 2 - dash
    private bool[] unlockedAbilities = new bool[3];

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More that 1 GameManager instance!");
        }

        Instance = this;

        for (int i = 0; i < 3; i++)
        {
            unlockedAbilities[i] = false;
        }

        SpawnPlayer();
    }

    public void UnlockAbility(int abilityID)
    {
        if (abilityID >= 3)
        {
            return;
        }

        unlockedAbilities[abilityID] = true;
    }

    private void SpawnPlayer()
    {
        if (player != null)
        {
            Destroy(player);
        }

        GameObject newPlayer = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        player = newPlayer;

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().ChangeTarget(player);

        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.SetAbilities(unlockedAbilities);

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

    public void CompleteLevel()
    {
        Debug.Log("Level complete!");
    }

    public void MarkPlayerAsDead()
    {
        SpawnPlayer();
    }
}

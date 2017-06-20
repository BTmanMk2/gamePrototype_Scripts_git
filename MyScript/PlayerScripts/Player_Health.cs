using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    private Player_Master playerMaster;
    private Player_Armor playerArmor;

    public int playerHealth;
    public int maxHealth;
    public Text healthText;

	// Use this for initialization
	void Start () {
        //StartCoroutine(TestHealthDeduction());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        SetInitialReferences();
        SetUI();
        playerMaster.EventPlayerHealthDeduction += DeductHealth;
        playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }

    private void OnDisable()
    {
        playerMaster.EventPlayerHealthDeduction -= DeductHealth;
        playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        playerMaster = GetComponent<Player_Master>();
        playerArmor = GetComponent<Player_Armor>();
    }

    IEnumerator TestHealthDeduction()
    {
        yield return new WaitForSeconds(3);
        playerMaster.CallEventPlayerHealthDeduction(1);
    }

    void DeductHealth(int healthChange)
    {
        int currentArmor = playerArmor.playerCurrentArmor;
        if (currentArmor > 0) {
            playerMaster.CallEventPlayerArmorDeduction(healthChange);
            healthChange = healthChange / 2;
        }
        playerHealth -= healthChange;
        if (playerHealth <= 0) {
            playerHealth = 0;
            gameManagerMaster.CallEventGameOver();
        }
        SetUI();
    }

    void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;
        if (playerHealth > maxHealth) {
            playerHealth = maxHealth;
        }
        SetUI();
    }

    void SetUI()
    {
        if (healthText != null) {
            healthText.text = playerHealth.ToString();
            //Debug.Log(healthText.color);
            if (((float)playerHealth / (float)maxHealth) <= 0.2) {
                healthText.color = new Color(1, 0x9c/0xff, 0x9c/0xff, 1);
            
            }else {
                healthText.color = new Color(0x9c/0xff, 1, 0xa5/0xff, 1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float Health;
    private PlayerUi ui;
    private GameObject Player;
    public float maxHealth = 110f;
    void Awake()
    {
        Health = maxHealth;
        Player = GameObject.Find("Player");
        ui = Player.GetComponent<PlayerUi>();
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, maxHealth);

    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }
    public void RestoreHealth(float healAmount)
    {
        Health += healAmount;
    }
    void Die()
    {

        ui.UpdateText("You killed the enemy");
        Destroy(gameObject);
        StartCoroutine((DelayAction(1000)));
        ui.UpdateText(string.Empty);

        //delay 2 seconds




    }
    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
    }
}

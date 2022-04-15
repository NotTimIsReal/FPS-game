using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float Health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image FrontHealthBar;
    public Image BackHealthBar;
    public Canvas PlayerUI;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, maxHealth);
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        float fillF = FrontHealthBar.fillAmount;
        float fillB = BackHealthBar.fillAmount;
        float hFraction = Health / maxHealth;
        if (fillB > hFraction)
        {
            FrontHealthBar.fillAmount = hFraction;
            BackHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            BackHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            BackHealthBar.fillAmount = hFraction;
            BackHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            FrontHealthBar.fillAmount = Mathf.Lerp(fillF, BackHealthBar.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        lerpTimer = 0;
        UpdateHealth();
        if (Health <= 0)
        {
            Time.timeScale = 0.2f;
            float percentComplete = 10f;
            //stop PlayerLook
            PlayerUi.FindObjectOfType<PlayerUi>().DeathText();
            GetComponent<InputManager>().gameObject.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.SmoothDamp(transform.rotation.z, 90, ref percentComplete, 0.2f));

        }
    }
    public void RestoreHealth(float healAmount)
    {
        Health += healAmount;
        lerpTimer = 0;
    }
}

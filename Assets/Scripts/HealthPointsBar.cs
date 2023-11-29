
using UnityEngine;
using UnityEngine.UI;

public class HealthPointsBar : MonoBehaviour
{
    [SerializeField] public Slider bar;
   
    public void SetMaxHealth(int health,int maxHealth)
    {
        bar.maxValue = maxHealth;
        bar.value = health;
    }
   public void SetHealth(int health)
    {
        bar.value = health;
    }
}

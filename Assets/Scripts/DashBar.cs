using UnityEngine;
using UnityEngine.UI;

public class DashCooldownSlider : MonoBehaviour
{
    public Slider slider; // Reference to the slider UI element
    public Player player; // Reference to the player script

    void Update()
    {
        // Calculate the remaining cooldown time percentage
        float cooldownPercentage = player.GetDashCooldownRemaining() / player.dashCooldown;

        // Update the slider value
        slider.value = 1 - cooldownPercentage; // Invert the percentage to fill the slider when cooldown is complete
    }
}

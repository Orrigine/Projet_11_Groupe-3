using System;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public static event Action OnHeal;
    private void OnTriggerEnter(Collider other)
    {
        // S'assurer que le player a bien le tag "Player"
        if (other.gameObject.layer == Player._playerLayer)
        {
            OnHeal?.Invoke();   
            // Apply a visual effect on a player 
                // => Level up effect / activate shield 
            // Héritage à utiliser si besoin

            // Play a sound (?)

            Destroy(gameObject);
        }
    }

}

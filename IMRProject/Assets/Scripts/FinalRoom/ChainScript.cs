using UnityEngine;

public class ChainScript : MonoBehaviour
{
    public GameObject door;

    private bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            gameObject.SetActive(false);
            ChainCounter.instance.IncrementHitChainCount();

            if (CheckBothChainsHit())
            {
                door.SetActive(false);
            }
        }
    }

    private bool CheckBothChainsHit()
    {
        return ChainCounter.instance.AreBothChainsHit();
    }
}

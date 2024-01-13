using UnityEngine;

public class ChainCounter : MonoBehaviour
{
    public static ChainCounter instance;

    private int hitChainCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementHitChainCount()
    {
        hitChainCount++;
    }

    public bool AreBothChainsHit()
    {
        return hitChainCount >= 2;
    }
}

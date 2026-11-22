using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.Instance.AddScore(10, "Coin");
    }
}
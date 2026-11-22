using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
            GameManager.Instance.AddScore(50, "Enemy");
    }
}
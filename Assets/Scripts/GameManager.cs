using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindAnyObjectByType<GameManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                    Debug.Log("[GameManager] 씬에 없어서 새로 생성했습니다.");
                }
            }
            return instance;
        }
    }

    public int Score { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"[GameManager] 중복 발견! 새로 생긴 오브젝트(ID: {GetInstanceID()})를 삭제합니다.");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log($"[GameManager] 생성 완료 (ID: {GetInstanceID()})");
    }

    public void AddScore(int amount, string from)
    {
        Score += amount;
        Debug.Log($"[GameManager] {from}에서 +{amount}점 → 현재 점수: {Score} (ID: {GetInstanceID()})");
    }
}

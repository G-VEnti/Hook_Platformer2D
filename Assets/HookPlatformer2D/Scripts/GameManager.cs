using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool keyObtained;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);

        keyObtained = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

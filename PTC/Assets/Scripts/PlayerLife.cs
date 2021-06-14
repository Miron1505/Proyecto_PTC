using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static float life;
    private Slider lifebar;

    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        lifebar = GameObject.FindGameObjectWithTag("lifebar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        lifebar.value = life;

        if (life <= 0)
        {
            gameObject.SetActive(false);

            GameOverManager.gameOverManager.CallGameOver();
        }
    }

}

using UnityEngine;
using Spine.Unity;
using UnityEngine.SceneManagement;
public class Heart : MonoBehaviour
{

    public GameController m_gc;
    public PlayerController player;
    [SerializeField] private float startingHealth;
    private bool dead;

    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }
    public void TakeDame(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            player.SetChangeState("hurt");
        }
        else
        {
            if ((!dead))
            {
                player.SetChangeState("sad");
                Death();
                dead = true;
            }
        }

    }
    private void Update()
    {

    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

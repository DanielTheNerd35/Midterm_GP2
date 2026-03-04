using System.Collections;
using UnityEngine;

public class SeedBehavior : MonoBehaviour
{
    public PlantState currentState;

[Header("Visuals")]
    [SerializeField] private GameObject seedVisual;
    [SerializeField] private GameObject moundVisual;
    [SerializeField] private GameObject sproutVisual;
    [SerializeField] private GameObject grownVisual;

[Header("Growth Timers")]
    [SerializeField] private float plantDelay = 2f;
    [SerializeField] private float sproutDelay = 5f;
    [SerializeField] private float growDelay = 8f;

    private bool isTransitioning;


    // private Animator anim;
    // public MouseInteract mouse;

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Awake()
    // {
    //     anim = GetComponent<Animator>();
    // }

    private void Start()
    {
        ChangeState(PlantState.Seed);
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentState == PlantState.Seed && collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(PlantSeed());
        }
    }

    private IEnumerator PlantSeed()
    {
        isTransitioning = true;

        yield return new WaitForSeconds(plantDelay);

        ChangeState(PlantState.Planted);

        yield return new WaitForSeconds(sproutDelay);

        ChangeState(PlantState.Sprouting);

        yield return new WaitForSeconds(growDelay);

        ChangeState(PlantState.Grown);

        yield return new WaitForSeconds(3f);

        ChangeState(PlantState.Harvestable);

        isTransitioning = false;
    }

    private void ChangeState(PlantState newState)
    {
        currentState = newState;

        //turn everything off first
        seedVisual.SetActive(false);
        moundVisual.SetActive(false);
        sproutVisual.SetActive(false);
        grownVisual.SetActive(false);

        switch (currentState)
        {
            case PlantState.Seed:
                seedVisual.SetActive(true);
                break;
            case PlantState.Planted:
                moundVisual.SetActive(true);
                break;
            case PlantState.Sprouting:
                sproutVisual.SetActive(true);
                break;
            case PlantState.Grown:
                grownVisual.SetActive(true);
                break;
            case PlantState.Harvestable:
                grownVisual.SetActive(true);
                break;
        }
    }
}


public enum PlantState
{
    Seed,
    Planted,
    Sprouting,
    Grown,
    Harvestable
}

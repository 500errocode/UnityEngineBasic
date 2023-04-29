using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private RaceManager _raceManager;

    private void OnTriggerEnter(Collider other)
    {
        if ((1<<other.gameObject.layer & _targetMask) > 0)
        {
            _raceManager.RegisterFinishedHorse(other.GetComponent<Horse>());
        }
    }
}

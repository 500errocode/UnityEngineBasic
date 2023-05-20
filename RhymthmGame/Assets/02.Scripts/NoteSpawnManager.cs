using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Video;

namespace RhythmGame
{
    public class NoteSpawnManager : MonoBehaviour
    {
        public static NoteSpawnManager instance;

        public float noteFallingDistance => transform.position.y - noteHitters.position.y;
        public float noteFallingTime => noteFallingDistance / GameManager.instance.speed;
        [SerializeField] private Transform noteHitters;
        private Dictionary<KeyCode, NoteSpawner> _spawners = new Dictionary<KeyCode,
          NoteSpawner>();
        private Queue<NoteData> _noteQueue;
        private float _timeMark;
        private bool _doSpawn;
        private bool _isCorouting;
        private Coroutine _coroutine;
        [SerializeField] private VideoPlayer _videoPlayer;
        public void StartSpawn()
        {
            if (_isCorouting)
                return;

            _timeMark = Time.time;
            _videoPlayer.clip = SongDataLoader.videoClip;
            _doSpawn = true;

            // Coroutine: ������ƾ, Ư�� �Լ��� ������ �ٸ� �Լ��� ȣ���ϵ��� �����ؼ� �����ϴ� ��ƾ
            // Unity �� Coroutine : IEnumerator �� MonoBehaviour �� ����ϸ�,
            // �ش� MonoBehaviour �� Update() ������ ���� �Ŀ� ��ϵ� IEnumerator.MoveNext() ��
            // �ϰ� ȣ���ϴ� ���·� �񵿱��ƾ�� ��������.
            // StartCoroutine() �� �ܼ��� ��ϸ� �ϴ°��̱� ������ �� �����ӿ��� ����ȣ��� ������ ���������.
            // ��ü���Ǵ� MonoBehaviour �� ��Ȱ��ȭ/�ı� �� �� �ڷ�ƾ�� �����Ҽ�����.
            _isCorouting = true;
            _coroutine = StartCoroutine(PlayVideo(noteFallingTime));
        }

        private IEnumerator PlayVideo(float delay)
        {
            yield return new WaitForSeconds(delay);
            _videoPlayer.Play();
            _isCorouting = false;
        }

        public void Register(NoteSpawner spawner)
        {
            if (_spawners.ContainsKey(spawner.key))
            {
                throw new System.Exception($"[NoteSpawnManager] : {spawner.key} �� �ش��ϴ� ��Ʈ������� �̹� ��ϵǾ��ֽ��ϴ�. NoteSpawner ���� key ���� Ȯ���ϼ���.");
            }
            else
            {
                _spawners.Add(spawner.key, spawner);
            }
        }
        private void Awake()
        {
            instance = this;
            _noteQueue = new Queue<NoteData>(SongDataLoader.songData.noteList.OrderBy(note => note.time));
        }

        private void Update()
        {
            if (_doSpawn)
            Spawning();
        }

        private void Spawning()
        {
            while (_noteQueue.Count > 0)
            {
                // �� �� ��Ʈ�� �ð��� ����Ǿ����� Ȯ��
                if (_noteQueue.Peek().time <= Time.time - _timeMark)
                {
                    _spawners[_noteQueue.Dequeue().key].Spawn();
                }
                else
                {
                    break;   
                }
            }
        }
    }
}

using UnityEngine;

namespace RTS.Core
{
    [CreateAssetMenu]
    public class GameData : ScriptableObject
    {
        [field:SerializeField] public PhysicsSettings Physics { get; private set; } = default;
        [field:SerializeField] public InputSettings Input { get; private set; } = default;
        [field:SerializeField] public ColorSettings Color { get; private set; } = default;
        
        private static GameData _instance = default;
        public static GameData Instance
        {
            get
            {
                if (_instance == null) 
                    _instance = Resources.Load<GameData>(nameof(GameData));
                return _instance;    
            }
        }
    }
}
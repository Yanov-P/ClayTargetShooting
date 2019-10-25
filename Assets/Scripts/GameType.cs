using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClayTargetShooting
{
    [CreateAssetMenu(fileName = "New GameType", menuName = "GameType", order = 51)]
    public class GameType : ScriptableObject
    {
        public int _maxAmmo = -1;
        public int _maxScore = -1;
        public int _maxTime = -1;
        public int _record = -1;
        public int _lastTry = -1;
    }
}

using System;

namespace Valientar.Gameplay.Core.FSM
{
    public sealed partial class Blackboard
    {
        private readonly struct Key
        {
            public readonly Type Type;
            public readonly string Name;


            public Key(Type type, string name)
            {
                Type = type;
                Name = name;
            }
        }
    }
}

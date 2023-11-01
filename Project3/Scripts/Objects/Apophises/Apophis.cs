using Project3.Scripts.Core;

namespace Project3.Scripts.Objects.Apophises
{
    internal abstract class Apophis : Component
    {
        public ApophisData apophisData;

        public virtual void Action() { }
    }
}
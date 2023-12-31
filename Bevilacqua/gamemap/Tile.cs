﻿using Interactable;
using OOP22_rusco_dc_csharp.Marcaccio.actors;
using IEntity = OOP22_rusco_dc_csharp.Marcaccio.IEntity;

namespace OOP22_rusco_dc_csharp.Bevilacqua.GameMap
{
    public abstract class Tile : ITile, IEntity
    {
        private IInteractable? content = null;

        public Tuple<int, int> Position { get; }
        public bool IsAccessible { get; }

        public Tile(Tuple<int, int> position, bool isAccessible)
        {
            this.Position = position;
            this.IsAccessible = isAccessible;
        }

        public virtual bool Put(IInteractable obj)
        {
            if (this.content == null)
            {
                this.content = obj;
                return true;
            }
            return false;
        }

        public virtual IInteractable? Get()
        {
            return this.content;
        }

        public IInteractable? Empty()
        {
            IInteractable? content = this.Get();
            if (content != null)
            {
                this.content = null;
            }
            return content;
        }

        public Action<IActor> GetEffect()
        {
            return (IActor actor) => { };
        }

        public int GetID()
        {
            return 1;
        }

        public Tuple<int, int> GetPos()
        {
            return this.Position;
        }

        public abstract string GetPath();
    }
}

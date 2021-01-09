using game2020.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Commands
{
    public class MoveCommand : IGameCommand
    {
        public Vector2 Speed;
        public MoveCommand()
        {
            this.Speed = new Vector2(6, 6);
        }

        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= this.Speed;
            transform.Position += direction;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace PhoneGameTest
{
    public class GameObject2D
    { 
        public Vector2 LocalPosition { get; set; }
        public Vector2 WorldPosition{ get; private set; }

        public Vector2 LocalScale{ get; set; }
        public Vector2 WorldScale{ get; private set; }

        public float LocalRotation{ get; set; }
        public float WorldRotation { get; private set; }

        public Vector2 PivotPoint { get; set; }
        protected Matrix WorldMatrix;

        public GameObject2D Parent { get; set; }
        public List<GameObject2D> Children { get; set; }

        bool DrawBefore3D { get; set; }

        public bool CanDraw { get; set; }

        public GameObject2D()
        {
            LocalScale = WorldScale = Vector2.One;
            Children = new List<GameObject2D>();
            CanDraw = true;
        }
        
        public void Translate(Vector2 position)
        {
            LocalPosition = position;
        }


        public virtual void Initialize() 
        {
            Children.ForEach(child => child.Initialize());
        }
        public virtual void LoadContent(ContentManager contentManager) { }
        public virtual void Update(RenderContext renderContext) 
        {
            WorldMatrix =
                Matrix.CreateTranslation(new Vector3(-PivotPoint, 0)) *
                Matrix.CreateScale(new Vector3(LocalScale, 1)) *
                Matrix.CreateRotationZ(MathHelper.ToRadians(LocalRotation)) *
                Matrix.CreateTranslation(new Vector3(LocalPosition, 0));

            if (Parent != null)
            {
                WorldMatrix = Matrix.Multiply(WorldMatrix, Matrix.CreateTranslation(new Vector3(Parent.PivotPoint, 0)));
                WorldMatrix = Matrix.Multiply(WorldMatrix, Parent.WorldMatrix);
            }
        }
        public virtual void Draw(RenderContext renderContext) { }

        

        public void AddChild(GameObject2D child)
        {
            if (!Children.Contains(child))
            {
                Children.Add(child);
                child.Parent = this;
            }
        }

        public void RemoveChild(GameObject2D child)
        {
            if (Children.Remove(child))
                child.Parent = null;
        }

    }
}

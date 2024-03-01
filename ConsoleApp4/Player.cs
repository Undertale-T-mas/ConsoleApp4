namespace Test
{
    public struct Vec2
    {
        public float x, y;

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

    public class Entity
    {
        public Vec2 position;
        public float radius;

        public virtual bool IsCollide(Entity entity)
        {
            float deltaX = entity.position.x - position.x;
            float deltaY = entity.position.y - position.y;

            float distance = MathF.Sqrt(deltaY * deltaY + deltaX * deltaX);
            return distance < radius + entity.radius;
        }
    }
    public interface Hitable
    {
        void Hit(int damage);
    }
    public class Bullet : Entity
    {
        public int damage;

        private void HitEntity(Hitable hitable)
        {
            hitable.Hit(damage);
        }
        public void CheckHit(Entity other)
        {
            if (other is not Hitable a) return;

            if(other.IsCollide(this))
            {
                HitEntity(a);
            }
        }
    }
    public class Player : Entity, Hitable
    {
        public int _id;
        public string _name;

        public int hp = 10;

        public void Hit(int damage)
        {
            hp -= damage;
            if (hp <= 0) Console.WriteLine("Player is dead!");
        }

        public override string ToString()
        {
            return $"The player has name {_name}, id = {_id}";
        }

        public override bool IsCollide(Entity entity)
        {
            if(this.hp <= 0) return false;
            return base.IsCollide(entity);
        }
    }
}

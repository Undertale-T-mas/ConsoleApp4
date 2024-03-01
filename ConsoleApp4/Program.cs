using Test;

Player p = new();
p._name = "test";
p._id = 1;
Player q = p;
q._id += 1;
Console.WriteLine(q);
q.position.x = 0;
q.position.y = 0;
q.radius = 5;
Bullet bullet = new();
bullet.position.x = 2;
bullet.position.y = 2;
bullet.radius = 5;

Console.WriteLine(bullet.position);

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"damage = {i}");
    bullet.damage = i;

    bullet.CheckHit(q);
}
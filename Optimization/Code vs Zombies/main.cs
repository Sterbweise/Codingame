using System;
using System.Linq;
using System.Collections.Generic;



class Player
{
    public class Human
    {
        public int id { get; set;}
        public int x { get; set; }
        public int y { get; set; }
        public int Indanger { get; set; }
        public int Save { get; set; }

        public Human(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.Indanger = 0;
            this.Save = 1;
        }
    }

    public class Zombie
    {
        public int id { get; set;}
        public int x { get; set; }
        public int y { get; set; }
        public int x_next { get; set; }
        public int y_next { get; set; }

        public Zombie(int id, int x, int y, int x_next, int y_next)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.x_next = x_next;
            this.y_next = x_next;
        }
    }

    public static double Distance(int x1, int y1, int x2, int y2)
    {
        int dx = x1-x2;
        int dy = y1-y2;
        double distance =  Math.Sqrt(dx * dx + dy * dy);
        return distance;
    }

    public static Human ClosestHuman(Human ClosestHuman, Human human, int Player_X, int Player_Y)
    {
        double d1 =  Distance(human.x, human.y, Player_X, Player_Y);
        double d2 =  Distance(ClosestHuman.x, ClosestHuman.y, Player_X, Player_Y);
        if ( d1 <= d2 && human.Save == 1){
            ClosestHuman = human;
        }
        return ClosestHuman;
    }

    public static void HumanInDanger(Human human, List<Zombie> Zombies)
    {
        human.Indanger = 0;
        foreach (Zombie zombie in Zombies){
            if ( Distance(zombie.x, zombie.y, human.x, human.y) < 2000 && human.Save == 1){
                human.Indanger = 1;
            }
        }
    }

    public static void CanSaveHuman(Human ClosestHuman, List<Zombie> Zombies, int Player_X, int Player_Y)
    {

        foreach (Zombie zombie in Zombies){
            double d1 =  Distance(Player_X, Player_Y, ClosestHuman.x, ClosestHuman.y);
            double d2 =  Distance(zombie.x_next, zombie.y_next,ClosestHuman.x, ClosestHuman.y);
            //Console.Error.WriteLine($"Distance Player {d1}, Distance Zombie{d2}");
            if ( d2*2.3 < d1 ){
                ClosestHuman.Save = 0;
            }
        }
    }
    static void Main(string[] args)
    {
        string[] inputs;

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);

            // ### ENTITY SECTION ###
            // Set Humain
            int humanCount = int.Parse(Console.ReadLine());
            List<Human> Humans = new List<Human>(humanCount);

            for (int i = 0; i < humanCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int humanId = int.Parse(inputs[0]);
                int humanX = int.Parse(inputs[1]);
                int humanY = int.Parse(inputs[2]);
                Humans.Add(new Human(humanId, humanX, humanY));
            }

            // Set Zombie
            int zombieCount = int.Parse(Console.ReadLine());
            List<Zombie> Zombies = new List<Zombie>(zombieCount);
            for (int i = 0; i < zombieCount; i++)
            {
                inputs = Console.ReadLine().Split(' '); 
                int zombieId = int.Parse(inputs[0]);
                int zombieX = int.Parse(inputs[1]);
                int zombieY = int.Parse(inputs[2]);
                int zombieXNext = int.Parse(inputs[3]);
                int zombieYNext = int.Parse(inputs[4]);
                Zombies.Add(new Zombie(zombieId, zombieX, zombieY, zombieXNext, zombieYNext));
            }

            // Definir la cible a aller attaquer
            Zombie target = Zombies.First();
            Human protect = null;
            Human closest = Humans.Last();

            foreach (Human human in Humans){
                CanSaveHuman(human, Zombies, x, y);
                HumanInDanger(human, Zombies);
                closest = ClosestHuman(closest, human, x, y);
                Console.Error.WriteLine($"Human ID: {human.id}, HumanCanSave: {human.Save}, HumanIndanger: {human.Indanger} \n ClosestHuman: {closest.id}");
                if ( closest.Indanger == 1 && closest.Save == 1 )  {
                    protect = closest;
                }
                foreach (Zombie zombie in Zombies){
                    if (zombie.x_next == human.x && zombie.y_next == human.y){
                        target = zombie;
                    }else if ( Distance(x,y,zombie.x,zombie.y) < Distance(closest.x,closest.y,target.x,target.y)){
                        target = zombie;
                    }
                }
            }
            
            // Se rapprocher de la cible
            if (protect is not null){
                x = protect.x;
                y = protect.y;
            } else {
                x = target.x;
                y = target.y; 
            }
            Console.WriteLine($"{x} {y}"); // Your destination coordinates
        }
    }
}
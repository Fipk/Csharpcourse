using System;

namespace DesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            GameManager firstManager;

            Console.WriteLine("Hello");

            NormalType normal = new NormalType();
            normal.SetName("Normal");
            FireType fire = new FireType();
            fire.SetName("Fire");

            TypeGroup typeGroup = new TypeGroup();
            typeGroup.Add(normal);
            typeGroup.Add(fire);

            typeGroup.Display();
        }

    }


    //Singleton
    /*public class GameManager
    {
        private static GameManager instance;
        private GameManager()
        {
            Console.WriteLine("GameManager instiantate");
        }

        public static GameManager InstantiateManager()
        {
            if (instance != null)
            {
                return instance;
            }
            return new GameManager();
        }
    }*/

    // Composite
    public abstract class Type
    {
        public string name { get; set; }


        public void SetName(string m_name)
        {
            this.name = m_name;
        }

        public string GetName() { return this.name; }
        public virtual void Display()
        {
            Console.WriteLine();
        }

        public virtual void Mafonction()
        {

        }
    }

    public class NormalType : Type
    {
        public override void Display()
        {

            Console.WriteLine("Je suis de type " + name + ", je fais partie de la class Normal");
        }
    }

    public class FireType : Type
    {
        public override void Display()
        {
            Console.WriteLine("Je suis de type " + name + ", je fais partie de la class Fire");
        }
    }

    public class TypeGroup : Type
    {
        List<Type> types = new List<Type>();

        public void Add(Type toAdd) { types.Add(toAdd); }
        public void Remove(Type toRemove) { types.Remove(toRemove); }

        public override void Display() 
        {
            Console.WriteLine("Groupe type: ");
            foreach (Type type in types) type.Display();
        }
    }


    // GameLoop
    public class InputManager
    {
        public void Update()
        {
            // On attend de savoir ce que veut faire le joueur
        }
    }

    public class GameManager
    {
        public void Update()
        {
            // On applique les choix du joueurs et donc ce qui en découle
        }

    }

    public class RendererManager
    {
        public void Update()
        {
            // On rend visuellement ce qui a changé pour la prochaine itération
        }
    }

    public class GameInstance
    {
        public GameInstance() { }

        public void Run()
        {
            InputManager inputManager = new InputManager();
            GameManager gameManager = new GameManager();
            RendererManager rendererManager = new RendererManager();


            inputManager.Update();
            gameManager.Update();
            rendererManager.Update();
        }
    }
}

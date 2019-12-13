using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Olio_harjoitus.Classes;

namespace WindowsFormsApp1.Olio_Harjoitus
{
    class Program
    {
        public static void JMR(string[] args)
        {

            // Onko kyseessä uusi pelihahmo vai aikaisemmin pelattu
            bool newPlayer = true, mainMenu = true;
            string playerName = "";
            Player player = new Player();
            int playerX = 10, playerY = 10;

            while (mainMenu)
            {
                // Päävalikko
                Console.Clear();
                Console.WriteLine("*********************************");
                Console.WriteLine("1. Play");
                //Console.WriteLine("2. Load a map"); // Kehitysidea: käyttäjä saa itse valita pelattavan kartan
                Console.WriteLine("2. Load previous player character");
                Console.WriteLine("0. Exit game");

                while (mainMenu)
                {
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.D1: // Aloitetaan peli, luodaan ensin hahmo mikäli vanhaa hahmoa ei ole ladattu
                            if (newPlayer)
                            {
                                Console.Write("\nGive a name for your new character: ");
                                playerName = Console.ReadLine();
                                // Luodaan pelaaja-olio
                                player = new Player(playerName, '@', ConsoleColor.White, playerX, playerY, 36, 10);  // Kehitysidea: Pelaajan X ja Y koordinaatit voisi arpoa
                            }
                            mainMenu = false;
                            break;
                        case ConsoleKey.D2: // Ladataan pelaaja-olio tiedostosta
                            player = DeserializePlayer();
                            if (player != null)
                                newPlayer = false;
                            break;
                        case ConsoleKey.D0:
                            Environment.Exit(0);
                            return;
                        default:
                            break;
                    }
                }

                // Pelisilmukka
                gameLoop(player);
                mainMenu = true;
            }
        }      

        private static void gameLoop(Player player)
        {
            // Asetetaan console-ikkunan koko, luodaan olio consoleWindow
            int windowWidth = 100, windowHeight = 30, messageBufferSize = 5;
            ConsoleWindow consoleWindow = new ConsoleWindow(windowWidth, windowHeight, messageBufferSize);            

            // Kehykset
            consoleWindow.DrawBorders();

            // Alustetaan ja piirretään kartta
            // Kehitysidea: Käyttäjä voi ladata haluamanssa karttatiedoston
            //consoleWindow.InitMap();
            consoleWindow.InitMapFromFile("map_default_98x23.txt");
            consoleWindow.DrawMap();
            consoleWindow.AddMessage("Welcome! Press H for help.");            

            // Luodaan viholliset ja lisätään viholliset-listaan
            List<Character> enemies = CreateEnemiesFromFile();

            // Pelisilmukka
            while (true)
            {
                // Otetaan tileBelow talteen pelialueelta (kartalta)
                player.TileBelow = consoleWindow.GetMapTile(player.X, player.Y);

                // Piirretään pelaaja-olio
                consoleWindow.DrawTile(player.X, player.Y, player);

                // Otetaan tileBelow talteen kaikkien vihollisten osalta (kartalta)
                foreach (Character enemy in enemies)
                {
                    enemy.TileBelow = consoleWindow.GetMapTile(enemy.X, enemy.Y);
                }

                // Piirretään viholliset
                foreach (Character enemy in enemies)
                {
                    consoleWindow.DrawTile(enemy.X, enemy.Y, enemy);
                }

                // Viestien kirjoitus alalaiden viestialueelle
                consoleWindow.WriteMessages();

                // Pelaajan statuksen kirjoitus alalaiden status-alueelle
                consoleWindow.WritePlayerStatus(player);

                // Odotetaan käyttäjän inputtia:
                // Nuolinäppäimet liikuttaa hahmoa.
                // ESC sulkee sovelluksen.
                // O avaa oven halutusta suunnasta (Open).
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (player.Move(0, -1, consoleWindow, enemies))
                            consoleWindow.AddMessage(player.Name + " moves north.");
                        break;
                    case ConsoleKey.DownArrow:
                        if (player.Move(0, 1, consoleWindow, enemies))
                            consoleWindow.AddMessage(player.Name + " moves south.");
                        break;
                    case ConsoleKey.LeftArrow:
                        if (player.Move(-1, 0, consoleWindow, enemies))
                            consoleWindow.AddMessage(player.Name + " moves west.");
                        break;
                    case ConsoleKey.RightArrow:
                        if (player.Move(1, 0, consoleWindow, enemies))
                            consoleWindow.AddMessage(player.Name + " moves east.");
                        break;
                    case ConsoleKey.O:
                        player.Open(consoleWindow);
                        break;
                    case ConsoleKey.H:
                        consoleWindow.AddMessage("Use arrow keys to move.");
                        consoleWindow.AddMessage("Press O to open doors.");
                        consoleWindow.AddMessage("Walk towards enemies to attack them.");
                        break;
                    case ConsoleKey.Escape:
                        // Pelin lopettaminen, tallennetaan pelaaja-olion tilanne
                        player.SerializePlayer();
                        // Rajapinnan toteuttamista harjoituksen vuoksi, tuhotaan characterit ja player
                        player.Destroy();
                        foreach (Character enemy in enemies)
                        {
                            enemy.Destroy();
                        }
                        return;
                    default:
                        break;
                }

                // Liikutellaan vihollisia
                Random random = new Random();
                foreach (Character enemy in enemies)
                {
                    int seed = random.Next(1000);
                    enemy.Move(consoleWindow, seed);
                }
            }
        }        

        private static List<Character> CreateEnemiesFromFile()
        {
            //Esimerkki uuden vihollisen luomisesta:
            //Character goblin = new Character("Goblin", 'g', ConsoleColor.Green, 31, 14, 1);

            // Lista vihollisia varten
            List<Character> enemies = new List<Character>();
            string[] fields;
            string name;
            char chr;
            ConsoleColor color;
            int x, y, health, money;

            // Luetaan viholliset tiedostosta rivi kerrallaan
            foreach (string line in File.ReadAllLines("enemies.txt"))
            {
                // Pilkotaan rivit puolipisteellä taulukon alkioiksi
                fields = line.Split(';');
                name = fields[0];
                chr = Char.Parse(fields[1]);
                color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), fields[2]);
                x = int.Parse(fields[3]);
                y = int.Parse(fields[4]);
                health = int.Parse(fields[5]);
                money = int.Parse(fields[6]);

                // Lisätään listaan uusi character-olio pilkottujen tietojen perusteella
                enemies.Add(new Character(name, chr, color, x, y, health, money));
            }

            return enemies;
        }

        private static Player DeserializePlayer()
        {
            // Metodi jossa hoidetaan pelaaja-olion lataaminen tiedostosta
            Player player = null;
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                FileStream fs = File.Open("player.dat", FileMode.Open);

                try
                {
                    using (fs)
                    {
                        player = (Player)bf.Deserialize(fs);
                        Console.WriteLine("Character named {0} is now loaded!", player.Name);
                    }
                }
                catch
                {
                    Console.WriteLine("Error loading previous character!");
                }
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine("File named player.dat not found!");
            }

            return player;
        }
    }
}

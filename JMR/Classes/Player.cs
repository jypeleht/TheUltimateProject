using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Olio_harjoitus.Interface;

namespace Olio_harjoitus.Classes
{
    [Serializable]
    class Player : Character, IDestroyable
    {
        private int _attackPower;
				
        public Player() : base()
        {
            _attackPower = 0;
        }
		
        public Player(string name, char chr, ConsoleColor color, int x, int y, int health, int attackPower) : base(name, chr, color, x, y, health, 0)
        {
            _attackPower = attackPower;
        }  
        
        public int AttackPower
        {
            get => _attackPower;
            set => _attackPower = value;
        }

        // Metodi pelaajan hyökkäämiselle
        public void Attack(Character enemy, ConsoleWindow consoleWindow, List<Character> characters)
        {
            consoleWindow.AddMessage(Name + " attacks " + enemy.Name + "!");
            // Yksinkertainen taistelumekaniikka; vähennetään vihollisen elämäpisteistä pelaajan hyökkäysvoiman verran pisteitä
            enemy.Health -= _attackPower;

            // Kuoliko vihu?
            if (enemy.Health <= 0)
            {
                consoleWindow.AddMessage(enemy.Name + " dies! " + Name + " loots " + enemy.Money + " coins.");
                Money += enemy.Money;
                // Poistetaan vihollinen listalta
                characters.Remove(enemy);
                // Korvataan kartan tile vihollisen ruumiilla
                consoleWindow.SetMapTile(enemy.X, enemy.Y, new Tile(enemy.Name + " (dead)", enemy.Chr, ConsoleColor.DarkRed, true, true));
            }
            else
            {
                consoleWindow.AddMessage(enemy.Name + " suffers " + _attackPower + " damage.");
            }
        }
        
        // Metodi pelaajahahmon liikuttamiselle
        public bool Move(int changeX, int changeY, ConsoleWindow consoleWindow, List<Character> characters)
        {
            // Tarkastetaan ensin onko kohteessa seisomassa hahmo (character)?
            foreach (Character character in characters)
            {
                if (character.X == X + changeX && character.Y == Y + changeY)
                {
                    // Hyökätään!
                    Attack(character, consoleWindow, characters);
                    return false;
                }
            }

            // Ollaanko reunusten sisällä?            
            if (X + changeX > 0 && X + changeX < consoleWindow.Width - 2 && Y + changeY > 0 && Y + changeY < consoleWindow.Height - 7)  // TODO: 7 dynaamiseksi
            {
                // Kohderuutu
                Tile destination = consoleWindow.GetMapTile(X + changeX, Y + changeY);
                
                // Onko tile mihin ollaan siirtymässä käveltävissä?
                if (destination.isPassable)
                {
                    // Piirretään pelaajan alla oleva tile                    
                    consoleWindow.DrawTile(X, Y, TileBelow);

                    X += changeX;
                    Y += changeY;
                    return true;
                }
                else
                {
                    // Törmäys
                    consoleWindow.AddMessage(Name + " hits a " + destination.Name + ".");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Metodi jossa pelaaja yrittää avata ovea kartalta
        public void Open(ConsoleWindow consoleWindow)
        {
            // Kysytään käyttäjältä ensin oven suunta.
            consoleWindow.AddMessage("Direction?");
            consoleWindow.WriteMessages();
            
            int dirX = X, dirY = Y;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    dirY--;
                    break;
                case ConsoleKey.DownArrow:
                    dirY++;
                    break;
                case ConsoleKey.LeftArrow:
                    dirX--;
                    break;
                case ConsoleKey.RightArrow:
                    dirX++;
                    break;                
                default:
                    consoleWindow.AddMessage("Nevermind...");   // Käyttäjä ei antanut suuntaa, joten lopetetaan funktion suorittaminen
                    break;
            }

            // Onko käyttäjän antamassa suunnassa suljettu ovi?
            if (consoleWindow.GetMapTile(dirX, dirY).Name == "Closed door")
            {
                // Vaihdetaan suljettu ovi -> avoimeksi oveksi
                consoleWindow.SetMapTile(dirX, dirY, new Tile("Open door", '-', ConsoleColor.Gray, true, true));
                consoleWindow.AddMessage(Name + " opens a door.");
            }
            else
                consoleWindow.AddMessage("No closed door there!");
        }

        // Metodi pelaaja-olion sarjallistaminen player.dat -tiedostoon
        public void SerializePlayer()
        {
            // Tallenetaan pelaaja-olion tilanne sarjallistamalla
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("player.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                binaryFormatter.Serialize(fileStream, this);
            }
            catch
            {
                Console.WriteLine("Error when saving the character!");
            }
            finally
            {
                fileStream.Close();
            }
        }

        // Metodin ylikirjoittamista harjoituksen vuoksi
        public override string ToString()
        {
            return Chr + "";
        }
    }
}

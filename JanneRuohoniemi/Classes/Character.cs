using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olio_harjoitus.Interface;

namespace Olio_harjoitus.Classes
{
    [Serializable]
    class Character : Tile, IDestroyable
    {
        private Tile _tileBelow;
        private int _x, _y, _health, _money;
        
        public Character() : base()
        {
            _x = 0;
            _y = 0;
            _health = 0;
            _money = 0;
        }
		
        public Character(string name, char chr, ConsoleColor color, int x, int y, int health, int money) : base(name, chr, color, false, true)
        {
            _x = x;
            _y = y;
            _health = health;
            _money = money;
        }

        public Tile TileBelow
        {
            get => _tileBelow;
            set => _tileBelow = value;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public int Money
        {
            get => _money;
            set => _money = value;
        }

        public new void Destroy()
        {
            Name = "dead " + Name;            
            Color = ConsoleColor.Red;
            isPassable = true;
        }

        // Metodi hahmon liikuttamiselle
        public void Move(ConsoleWindow consoleWindow, int seed)
        {            
            // Arvotaan suunta
            Random random = new Random(seed);
            int direction = random.Next(4);
            int changeX = 0, changeY = 0;            

            // Liikutetaan hahmoa
            switch (direction)
            {
                case 0:
                    changeY--;
                    break;
                case 1:
                    changeX++;
                    break;
                case 2:
                    changeY++;
                    break;
                case 3:
                    changeX--;
                    break;
                default:
                    break;
            }

            // Tarkistetaan liikkeen oikeellisuus
            // Ollaanko reunusten sisällä? 
            if (_x + changeX > 0 && _x + changeX < consoleWindow.Width - 2 && _y + changeY > 0 && _y + changeY < consoleWindow.Height - 7)  // TODO: 7 dynaamiseksi
            {
                // TODO: Onko kohteessa seisomassa hahmo (character) tai pelaaja?
                // Jos on, Tile destination = character
                // else GetMapTile kuten alla

                Tile destination = consoleWindow.GetMapTile(_x + changeX, _y + changeY);
                // Onko tile mihin ollaan siirtymässä käveltävissä?
                if (destination.isPassable)
                {
                    // Piirretään hahmon alla oleva tile
                    consoleWindow.DrawTile(_x, _y, _tileBelow);

                    _x += changeX;
                    _y += changeY;
                }
                else
                {
                    // TODO: bufferi ei pysy tässä perässä, korjaa
                    //consoleWindow.AddMessage(Name + " hits a " + destination.Name + ".");
                }
            }
        }
    }
}

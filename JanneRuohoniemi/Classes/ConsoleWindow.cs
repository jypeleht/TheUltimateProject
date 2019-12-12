using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Olio_harjoitus.Classes
{
    class ConsoleWindow
    {
        // Privaattimuuttujat
        private int _width, _height, _messageBufferSize;
        private Tile[,] _map;
        private Queue<string> _messageBuffer;        
        private string[] _oldMessages;
		
        //Oletuskonstruktori
		public ConsoleWindow()
        {
            _width = 20;
            _height = 20;
            _messageBufferSize = 5;
            _messageBuffer = new Queue<string>();
            _oldMessages = new string[5];
            Console.SetWindowSize(20, 20);
            Console.SetBufferSize(20, 20);
        }
		
        // Konstruktori
        public ConsoleWindow(int width, int height, int messageBufferSize)
        {
            _width = width;
            _height = height;
            _messageBufferSize = messageBufferSize;
            _messageBuffer = new Queue<string>();            
            _oldMessages = new string[messageBufferSize];
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        // Metodi merkin piirtämiseen haluttuun kohtaan
        public void DrawChar(int x, int y, char chr, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);    // Koordinaatit
            Console.ForegroundColor = color;    // Väri
            Console.Write(chr);                 // Merkki
            Console.ResetColor();               // Värin resetointi
            Console.CursorVisible = false;      // Kursori piiloon
        }      
        
        // Metodi Tile-tyylisen olion kirjoittamiseen haluttuun kohtaan
        public void DrawTile(int x, int y, Tile tile)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = tile.Color;
            Console.Write(tile.Chr);
            Console.ResetColor();
            Console.CursorVisible = false;
        }
        
        // Metodi tekstin kirjoittamiseen haluttuun kohtaan
        public void DrawText(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);    
            Console.ForegroundColor = color;   
            Console.Write(text);               
            Console.ResetColor();              
            Console.CursorVisible = false;     
        }

        // Metodi kehysten piirtämiseen
        public void DrawBorders()
        {
            // Piirretään kehykset
            // Vaakasuorat
            for (int i = 0; i < _width-1; i++)
            {
                DrawChar(i, 0, '═', ConsoleColor.White);
                DrawChar(i, _height-7, '═', ConsoleColor.White);
                DrawChar(i, _height-1, '═', ConsoleColor.White);
            }
            // Pystysuorat
            for (int i = 1; i < _height-1; i++)
            {
                DrawChar(0, i, '║', ConsoleColor.White);
                DrawChar(_width-2, i, '║', ConsoleColor.White);
            }
            // Kulmapalat yms.  
            DrawChar(0, 0, '╔', ConsoleColor.White);
            DrawChar(_width-2, 0, '╗', ConsoleColor.White);
            DrawChar(0, _height-1, '╚', ConsoleColor.White);
            DrawChar(_width-2, _height-1, '╝', ConsoleColor.White);
            DrawChar(0, _height-7, '╠', ConsoleColor.White);
            DrawChar(_width - 2, _height-7, '╣', ConsoleColor.White);
        }

        // Oletuskartan alustaminen
        public void InitMap()
        {
            // Alustetaan kartta (kaksiulotteinen taulukko joka täytetään Tile-olioilla)
            _map = new Tile[_width-2, _height-7];
            for (int i = 1; i < _width-2; i++)
            {
                for (int j = 1; j < _height-7; j++)
                {
                    _map[i, j] = new Tile("Floor", '.', ConsoleColor.DarkGray, true, true);
                }
            }

            // Lisätään yksi seinä debuggausta varten
            _map[15, 15] = new Tile("Wall", '#', ConsoleColor.Gray, false, false);
        }

        // Kartan alustaminen tiedostosta
        public void InitMapFromFile(string mapFile)
        {
            // Alustetaan kartta kuten funktiossa InitMap, mutta luetaan kartta tiedostosta.
            string fileName = Path.GetFileName(mapFile);
            // Päätellään kartan koko tiedoston nimestä
            string[] separators = { "_", "x", "." };
            int count = 5;
            string[] strList = fileName.Split(separators, count, StringSplitOptions.RemoveEmptyEntries);

            int width = int.Parse(strList[2]);  // Tiedoston nimestä parsittu leveys
            int height = int.Parse(strList[3]);  // Tiedoston nimestä parsittu korkeus

            // Alustetaan kartta (kaksiulotteinen taulukko joka täytetään Tile-olioilla)
            _map = new Tile[width, height];

            // Käydään läpi kaikki tekstitiedoston rivit
            int i = 0, j = 0;
            foreach (string line in File.ReadAllLines(mapFile))
            {
                // Käydään läpi kaikki tekstirivin merkit
                foreach (char chr in line)
                {
                    // Luodaan kartta-taulukkoon uusi Tile-olio tiedostosta luetun merkin perusteella
                    switch (chr)
                    {
                        case '.':
                            _map[i, j] = new Tile("Floor", chr, ConsoleColor.DarkGray, true, true);
                            break;
                        case '#':
                            _map[i, j] = new Tile("Wall", chr, ConsoleColor.Gray, false, false);
                            break;
                        case '+':
                            _map[i, j] = new Tile("Closed door", chr, ConsoleColor.Gray, false, false);
                            break;
                        default:
                            break;
                    }
                    
                    i++;
                }
                j++;
                i = 0;
            }
        }
		
        // Metodi kartan piirtämiseen
        public void DrawMap()
        {
            // Käydään läpi kartta ja piirretään se konsoliin
            for (int i = 1; i < _width-2; i++)
            {
                for (int j = 1; j < _height-7; j++)
                {
                    DrawTile(i, j, _map[i, j]);
                }
            }
        }

        // Metodi tietyn Tile-olion palauttamiseen kartalta
        public Tile GetMapTile(int x, int y)
        {
            // Palauttaa Tilen halutusta kohtaa kartta-taulukkoa
            return _map[x, y];
        }

        // Metodi kartta-Tilen päivittämiseen
        public void SetMapTile(int x, int y, Tile tile)
        {
            // Asettaa korvaavan tilen haluttuun kohtaan kartta-taulukkoa
            _map[x, y] = tile;
            // Päivitetään merkki myös tulostukseen
            DrawTile(x, y, tile);
        }

        // Metodi viestin lisäämiseksi bufferiin
        public void AddMessage(string message)
        {
            // Otetaan vanhat viestit talteen            
            _messageBuffer.CopyTo(_oldMessages, 0);
            // Tyhjätään bufferia
            while(_messageBuffer.Count() >= _messageBufferSize)
            {
                _messageBuffer.Dequeue();
            }            
            _messageBuffer.Enqueue(message);
        }
		
        // Metodi viestien kirjoittamiseen
        public void WriteMessages()
        {            
            // Vanhojen viestien poisto messageAreasta
            int i = -6;
            foreach (string message in _oldMessages)
            {
                DrawText(1, _height + i, message, ConsoleColor.Black);
                i++;
            }

            // Uusien viestien kirjoittaminen messageAreaan
            i = -6;
            foreach (string message in _messageBuffer)
            {                
                DrawText(1, _height + i, message, ConsoleColor.White);
                i++;
            }            
        }
		
        // Metodi pelaajan statuksen kirjoittamiseen
        public void WritePlayerStatus(Player player)
        {
            DrawText(50, _height - 6, "Player: " + player.Name, ConsoleColor.White);
            DrawText(50, _height - 5, "Health: " + player.Health, ConsoleColor.White);
            DrawText(50, _height - 4, "Money: " + player.Money, ConsoleColor.White);
            DrawText(50, _height - 3, "Attack power: " + player.AttackPower, ConsoleColor.White);
        }
		
        public int Width
        {
            get => _width;
            set => _width = value;
        }
		
        public int Height
        {
            get => _height;
            set => _height = value;
        }
    }
}

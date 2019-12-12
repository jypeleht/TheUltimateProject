using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olio_harjoitus.Interface;

namespace Olio_harjoitus.Classes
{
    [Serializable]
    class Tile : IDestroyable
    {
        private string _name;           // Tilen nimi, voidaan käyttää mm. viesteissä.
        private char _chr;              // Merkki jolla tile piirretään pelimaailmaan.
        private ConsoleColor _color;    // Tilen väri.
        private bool _isPassable;       // Voiko tilen läpi kävellä.
        private bool _isTransparent;    // Voiko tilen läpi nähdä.
        private bool _isVisible;        // Onko tile näkyvissä pelaajalle.
        private bool _isVisibleChanged; // Onko tilen näkyvyystila muuttunut (optimointia varten).
        private bool _isVisibleChecked; // Onko tilen näkyvyyttä jo  tarkasteltu (optimointia varten).
        		
        public Tile()
        {
            _name = "";
            _chr = ' ';
            _color = ConsoleColor.Black;
            _isPassable = true;
            _isTransparent = true;
            _isVisible = false;
            _isVisibleChanged = false;
            _isVisibleChecked = false;
        }
		
        public Tile(string name, char chr, ConsoleColor color, bool isPassable, bool isTransparent)
        {
            _name = name;
            _chr = chr;
            _color = color;
            _isPassable = isPassable;
            _isTransparent = isTransparent;
            _isVisible = false;
            _isVisibleChanged = false;
            _isVisibleChecked = false;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public char Chr
        {
            get => _chr;
            set => _chr = value;
        }

        public ConsoleColor Color
        {
            get => _color;
            set => _color = value;
        }

        public bool isPassable
        {
            get => _isPassable;
            set => _isPassable = value;
        }

        public void Destroy()
        {
            _name = "void";
            _chr = ' ';
            _color = ConsoleColor.Black;
            _isPassable = true;
            _isTransparent = true;
            _isVisible = false;
            _isVisibleChanged = false;
            _isVisibleChecked = false;
        }
    }
}

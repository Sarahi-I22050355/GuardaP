using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuardaP
{
    internal class Contacto : Persona
    {
        private string telefono;
        private string correo;

        public string Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value.Replace(" ", "").Replace("-", "");
            }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public Contacto() : base()
        {
            telefono = string.Empty;
            correo = string.Empty;
        }
        public Contacto(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string telefono, string correo) : base(nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento)
        {
            this.telefono = telefono;
            this.correo = correo;
        }

        public override string ToString()
        {
            return base.ToString() + " " + telefono + correo;
        }
    }
}

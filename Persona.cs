using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardaP
{
    internal class Persona
    {
        protected string nombre;
        protected string apellidoPaterno;
        protected string apellidoMaterno;
        protected DateTime fechaNacimiento;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }
        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }
        /// <summary>
        /// propiedad fecha nacimiento con su set para validar la fecha por los años
        /// </summary>
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set {
                if (value > DateTime.Now || value.Year < DateTime.Now.Year - 100)
                {
                    throw new ArgumentException("La fecha de nacimiento ingresada no es válida.");
                }
                fechaNacimiento = value;
            }
        }

        public int Edad
        {
            get
            {
                int edad;
                edad = (DateTime.Now.Year - fechaNacimiento.Year);
                return edad;
            }

        }
        public Persona()
        {
            nombre = String.Empty;
            apellidoPaterno=String.Empty;
            apellidoMaterno=String.Empty;
            fechaNacimiento = DateTime.MinValue;
        }
        public Persona(string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNacimiento = fechaNacimiento;
        }

        public override string ToString()
        {
            return nombre.ToUpper() + " " + apellidoPaterno.ToUpper() + " " + apellidoMaterno.ToUpper() +  " " + Edad;
        }
    }
}

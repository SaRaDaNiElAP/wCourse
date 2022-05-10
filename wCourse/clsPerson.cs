using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wCourse
{
    class clsPerson
    {

        private string nombre, apellido, direccion, telefono, ciudad, comuna, rh;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        public string Comuna
        {
            get { return comuna; }
            set { comuna = value; }
        }
        public string RH
        {
            get { return rh; }
            set { rh = value; }
        }
    }
}

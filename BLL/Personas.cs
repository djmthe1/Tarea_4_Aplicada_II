using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Personas : ClaseMaestra
    {

        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public bool Sexo { get; set; }
        ConexionDb conexion = new ConexionDb();
        public PersonasTelefonos Telefono = new PersonasTelefonos();
        public List<PersonasTelefonos> telefonos { get; set; }

        public Personas(int personaId, string nombres, bool sexo)
        {
            this.PersonaId = personaId;
            this.Nombres = nombres;
            this.Sexo = sexo;
        }

        public Personas()
        {
            telefonos = new List<PersonasTelefonos>();
        }

        public void InsertarTelefono(int PersonaId, string TipoTelefono, string Telefono)
        {
            this.telefonos.Add(new PersonasTelefonos(PersonaId, TipoTelefono, Telefono));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            object identity;
            try
            {
                //obtengo el identity insertado en la tabla
                identity = conexion.ObtenerValor(String.Format("INSERT INTO Personas (Nombres, Sexo) VALUES ('{0}','{1}') SELECT @@Identity", this.Nombres, this.Sexo));

                //intento convertirlo a entero
                int.TryParse(identity.ToString(), out retorno);

                this.PersonaId = retorno;
                if (retorno > 0)
                {
                    foreach (PersonasTelefonos numeros in this.telefonos)
                    {
                        conexion.Ejecutar(String.Format("INSERT INTO PersonasTelefonos (PersonaId, TipoTelefono, Telefono) VALUES ({0},'{1}','{2}')", retorno, numeros.TipoTelefono, numeros.Telefono));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("UPDATE Personas SET Nombres='{0}', Sexo='{1}' WHERE PersonaId={2}", this.Nombres, this.Sexo, this.PersonaId));
                if (retorno)
                {
                    conexion.Ejecutar(String.Format("DELETE FROM PersonasTelefonos WHERE PersonaId={0}", this.PersonaId));
                    foreach (PersonasTelefonos numeros in this.telefonos)
                    {
                        conexion.Ejecutar(String.Format("INSERT INTO PersonasTelefonos (PersonaId, TipoTelefono, Telefono) VALUES ({0},'{1}','{2}')", retorno, numeros.TipoTelefono, numeros.Telefono));
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("DELETE FROM Personas WHERE PersonaId={0}", this.PersonaId));
                if (retorno)
                    conexion.Ejecutar(String.Format("DELETE FROM PersonasTelefonos WHERE PersonaId={0}", this.PersonaId));
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dtTelefonos = new DataTable();

            dt = conexion.ObtenerDatos("SELECT * FROM Personas WHERE PersonaId=" + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                this.PersonaId = (int)dt.Rows[0]["PersonaId"];
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Sexo = (bool)dt.Rows[0]["Sexo"];

                dtTelefonos = conexion.ObtenerDatos(String.Format("SELECT * FROM PersonasTelefonos WHERE PersonaId=" + IdBuscado));

                foreach (DataRow row in dtTelefonos.Rows)
                {
                    this.InsertarTelefono((int)dtTelefonos.Rows[0]["PersonaId"], row["TipoTelefono"].ToString(), row["Telefono"].ToString());
                }
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenar = "";
            if (!Orden.Equals(""))
                ordenar = " orden by  " + Orden;
            return conexion.ObtenerDatos(("SELECT " + Campos + " FROM Personas WHERE " + Condicion + ordenar));
        }
    }
}

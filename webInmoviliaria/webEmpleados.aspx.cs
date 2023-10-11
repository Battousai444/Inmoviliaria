using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases.BaseDatos;

namespace WEB.webInmoviliaria
{
    public partial class webEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        private void LlenarGrid()
        {
            clsEmpleados oCliente = new clsEmpleados();
            oCliente.grdEmpleados = grdEmpleados;
            if (!oCliente.LlenarGrid())
            {
                lblError.Text = oCliente.Error;
            }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Documento, Nombre, PrimerApellido, SegundoApellido, Direccion, Correo;


            Documento = txtDocumento.Text;
            Nombre = txtNombre.Text;
            PrimerApellido = txtPrimerApellido.Text;
            SegundoApellido = txtSegundoApellido.Text;
            Direccion = txtDireccion.Text;
            Correo = txtCorreo.Text;

            clsEmpleados oCliente = new clsEmpleados();

            oCliente.Documento = Documento;
            oCliente.Nombre = Nombre;
            oCliente.PrimerApellido = PrimerApellido;
            oCliente.SegundoApellido = SegundoApellido;
            oCliente.Direccion = Direccion;
            oCliente.Correo = Correo;

            if (oCliente.Insertar())
            {
                lblError.Text = "Se ingresó al empleado con el documento: " + Documento + " a la base de datos";
                LlenarGrid();

            }
            else
            {
                lblError.Text = oCliente.Error;
            }

        }

            protected void btnActualizar_Click(object sender, EventArgs e)
            {
            string Documento, Nombre, PrimerApellido, SegundoApellido, Direccion, Correo;
            

            Documento = txtDocumento.Text;
            Nombre = txtNombre.Text;
            PrimerApellido = txtPrimerApellido.Text;
            SegundoApellido = txtSegundoApellido.Text;
            Direccion = txtDireccion.Text;
            Correo = txtCorreo.Text;

            clsEmpleados oCliente = new clsEmpleados();

            oCliente.Documento = Documento;
            oCliente.Nombre = Nombre;
            oCliente.PrimerApellido = PrimerApellido;
            oCliente.SegundoApellido = SegundoApellido;
            oCliente.Direccion = Direccion;
            oCliente.Correo = Correo;

            if (oCliente.Actualizar())
            {
                lblError.Text = "Se actualizaron los datos del empleado de documento: " + Documento + " a la base de datos";
                LlenarGrid();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

            protected void btnBorrar_Click(object sender, EventArgs e)
            {
            string Documento;
            Documento = txtDocumento.Text;
            

            clsEmpleados oCliente = new clsEmpleados();

            oCliente.Documento = Documento;
           

            if (oCliente.Eliminar())
            {
                lblError.Text = "se eliminaron los datos del empleado con el documento: " + Documento + " en la base de datos";
                LlenarGrid();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

            protected void btnConsultar_Click(object sender, EventArgs e)
            {
            string Documento;

            Documento = txtDocumento.Text;

            clsEmpleados oCliente = new clsEmpleados();

            oCliente.Documento = Documento;

            if (oCliente.Consultar())
            {
                txtNombre.Text = oCliente.Nombre;
                txtPrimerApellido.Text = oCliente.PrimerApellido;
                txtSegundoApellido.Text = oCliente.SegundoApellido;
                txtDireccion.Text = oCliente.Direccion;
                txtCorreo.Text = oCliente.Correo;

                lblError.Text = "Se consultó la información";
            }
            else
            {
                lblError.Text = oCliente.Error;

                txtNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";
                txtDireccion.Text = "";
                txtCorreo.Text = "";
            }


        }

        protected void grdEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Documento, Nombre, Direccion, Correo;

            //documento =grdClientes.SelectedRow.cells[]
            Documento = grdEmpleados.SelectedRow.Cells[1].Text;
            Nombre = grdEmpleados.SelectedRow.Cells[2].Text;
            Direccion = grdEmpleados.SelectedRow.Cells[3].Text;
            Correo = grdEmpleados.SelectedRow.Cells[4].Text;

            //para navegar a otras paginas de utilizan el objeto Response, con el metodo .Redirect()
            //como esta en la misma carpeta se llama solo con el nombre
            //para los parametros, se utiliza el simbolo de interrogacion, para indicar que empiezan los parametros, los
            //cuales tiene un nombre y un valor, asignados por el simbolo "=" y si es mas de un parametro se conecta cone l simboplo9de "&"
            string sURL = "webTelefonoEmpleado.aspx?Documento=" + Documento + "&Nombre=" + Nombre +
                "&Direccion=" + Direccion + "&Correo=" + Correo;
            Response.Redirect(sURL);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases.BaseDatos;

namespace WEB.webInmoviliaria
{
    public partial class webRegistrarResidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarComboDeCombos();
        }
        private void LlenarComboDeCombos()
        {
            clsCombosResidencias oCombos = new clsCombosResidencias();
            oCombos.cboAmueblacion = dropAmueblado ;
            oCombos.cboGarage = dropGarage;
            oCombos.cboInternet = dropInternet;
            oCombos.cboPatio = dropPatio;
            oCombos.cboPisina = dropPisina;
            oCombos.cboTerraza = dropTerraza;
            oCombos.cboTipoResidencia = dropTipoResidencia;
            oCombos.cboUbicacion = dropUbicacion;

            if (oCombos.LlenarComboGarage() == false)
            {
                lblError.Text = oCombos.Error;
            }
            if (oCombos.LlenarComboIntenet() == false)
            {
                lblError.Text = oCombos.Error;
            }
            if (oCombos.LlenarComboUbicacion() == false)
            {
                lblError.Text = oCombos.Error;
            }
            if (oCombos.LlenarComboPatio() == false)
            {
                lblError.Text = oCombos.Error;
            }
            if (oCombos.LlenarComboTipoResidencia() == false)
            {
                lblError.Text = oCombos.Error;
            }
            if (oCombos.LlenarComboAmueblado() == false)
            {
                lblError.Text = oCombos.Error;
            }
            if (oCombos.LlenarComboPisina() == false)
            {
                lblError.Text = oCombos.Error;
            }
            if (oCombos.LlenarComboTerraza() == false)
            {
                lblError.Text = oCombos.Error;
            }

        }
        private void LlenarGrid()
        {
            clsResidencias oRedsidencias = new clsResidencias();
            oRedsidencias.grdResidencias = grdResidencias;
            if (!oRedsidencias.LlenarGrid())
            {
                lblError.Text = oRedsidencias.Error;
            }
        }


        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Direccion, Tamaño, estado ;
            Int32  ubicacion, garage, amueblado, pisina, internet, patio, terraza, tipoResidencia, precio;

            Direccion = txtDireccion.Text;
            Tamaño = txtTamaño.Text;
            estado = "DESOCUPADO";
            ubicacion = Convert.ToInt32(dropUbicacion.SelectedValue);
            garage = Convert.ToInt32(dropGarage.SelectedValue);
            amueblado = Convert.ToInt32(dropAmueblado.SelectedValue);
            pisina = Convert.ToInt32(dropPisina.SelectedValue);
            internet = Convert.ToInt32(dropInternet.SelectedValue);
            patio = Convert.ToInt32(dropPatio.SelectedValue);
            terraza = Convert.ToInt32(dropTerraza.SelectedValue);
            tipoResidencia = Convert.ToInt32(dropTipoResidencia.SelectedValue);
            precio = Convert.ToInt32(txtPrecio.Text);

            clsResidencias oResidencias = new clsResidencias();

            oResidencias.Direccion = Direccion;
            oResidencias.Tamaño = Tamaño;
            oResidencias.Estado = estado;
            oResidencias.codUbicacion = ubicacion;
            oResidencias.codGarage = garage;
            oResidencias.codAmueblado = amueblado;
            oResidencias.codPisina = pisina;
            oResidencias.codInternet = internet;
            oResidencias.codPatio = patio;
            oResidencias.codterraza = terraza;
            oResidencias.codTipoResidencia = tipoResidencia;
            oResidencias.precio = precio;
            if (oResidencias.Insertar())
            {
                lblError.Text = "Se ingresó la residencia con direccion: " + Direccion + " a la base de datos";
                LlenarGrid();

            }
            else
            {
                lblError.Text = oResidencias.Error;
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Direccion, Tamaño, estado;
            Int32 ubicacion, garage, amueblado, pisina, internet, patio, terraza, tipoResidencia, precio, codigo;

            Direccion = txtDireccion.Text;
            Tamaño = txtTamaño.Text;
            estado = "DESOCUPADO";
            codigo = Convert.ToInt32(lblCodigo.Text);
            ubicacion = Convert.ToInt32(dropUbicacion.SelectedValue);
            garage = Convert.ToInt32(dropGarage.SelectedValue);
            amueblado = Convert.ToInt32(dropAmueblado.SelectedValue);
            pisina = Convert.ToInt32(dropPisina.SelectedValue);
            internet = Convert.ToInt32(dropInternet.SelectedValue);
            patio = Convert.ToInt32(dropPatio.SelectedValue);
            terraza = Convert.ToInt32(dropTerraza.SelectedValue);
            tipoResidencia = Convert.ToInt32(dropTipoResidencia.SelectedValue);
            precio = Convert.ToInt32(txtPrecio.Text);

            clsResidencias oResidencias = new clsResidencias();

            oResidencias.codigo_Residencia = codigo;
            oResidencias.Direccion = Direccion;
            oResidencias.Tamaño = Tamaño;
            oResidencias.Estado = estado;
            oResidencias.codUbicacion = ubicacion;
            oResidencias.codGarage = garage;
            oResidencias.codAmueblado = amueblado;
            oResidencias.codPisina = pisina;
            oResidencias.codInternet = internet;
            oResidencias.codPatio = patio;
            oResidencias.codterraza = terraza;
            oResidencias.codTipoResidencia = tipoResidencia;
            oResidencias.precio = precio;
            if (oResidencias.Actualizar())
            {
                lblError.Text = "se actualizo la residencia con el codigo: " + codigo + " en la base de datos";
                LlenarGrid();

            }
            else
            {
                lblError.Text = oResidencias.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 codigo;

            codigo = Convert.ToInt32(lblCodigo.Text);

            clsResidencias oResidencias = new clsResidencias();

            if (oResidencias.Eliminar())
            {
                lblError.Text = "se eliminaron los datos de la residencia con el codigo: " + codigo + " en la base de datos";
                LlenarGrid();
            }
            else
            {
                lblError.Text = oResidencias.Error;
            }

        }

        protected void grdResidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCodigo.Text = grdResidencias.SelectedRow.Cells[1].Text;
            txtDireccion.Text = grdResidencias.SelectedRow.Cells[2].Text;
            txtTamaño.Text = grdResidencias.SelectedRow.Cells[3].Text;
            dropAmueblado.SelectedValue = grdResidencias.SelectedRow.Cells[4].Text;
            dropGarage.SelectedValue = grdResidencias.SelectedRow.Cells[5].Text;
            dropInternet.SelectedValue = grdResidencias.SelectedRow.Cells[6].Text;
            dropPatio.SelectedValue = grdResidencias.SelectedRow.Cells[7].Text;
            dropPisina.SelectedValue = grdResidencias.SelectedRow.Cells[8].Text;
            dropTerraza.SelectedValue = grdResidencias.SelectedRow.Cells[9].Text;
            dropTipoResidencia.SelectedValue = grdResidencias.SelectedRow.Cells[10].Text;
            dropUbicacion.SelectedValue = grdResidencias.SelectedRow.Cells[11].Text;
            txtPrecio.Text = grdResidencias.SelectedRow.Cells[12].Text;

        }
    }
}